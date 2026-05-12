#!/usr/bin/env python3
"""Build an OpenAPI 3.0 spec for the Hetzner Robot Webservice.

Hetzner does not publish an OpenAPI document for the Robot Webservice. This
script reverse-engineers one from two authoritative Hetzner sources:

1. **`RobotClient.class.php`** — Hetzner's official PHP reference client.
   Source of truth for paths, HTTP verbs, path parameters, query parameters
   and request-body field names. Distributed at
   <https://robot.your-server.de/downloads/robot-client.zip>.

2. **<https://robot.hetzner.com/doc/webservice/en.html>** — Hetzner's
   official HTML reference documentation. Source of truth for response-body
   schemas (derived from the JSON response examples) and human-readable
   endpoint and field descriptions.

The output is `specs/robot.spec.yaml`, an OpenAPI 3.0.3 document. The script
is deterministic and re-runnable; pass `--refresh` to re-download the HTML
docs.

Run from anywhere:

    python3 hetzner/tools/build_robot_spec.py
"""
from __future__ import annotations

import argparse
import html as htmllib
import json
import re
import sys
import textwrap
import urllib.request
from dataclasses import dataclass, field
from pathlib import Path
from typing import Any

try:
    import yaml
except ImportError:
    sys.stderr.write("PyYAML is required: pip install pyyaml\n")
    sys.exit(1)

try:
    from bs4 import BeautifulSoup
except ImportError:
    sys.stderr.write("beautifulsoup4 is required: pip install beautifulsoup4\n")
    sys.exit(1)

HERE = Path(__file__).resolve().parent
HETZNER_DIR = HERE.parent
PHP_PATH = HERE / "RobotClient.class.php"
CACHE_DIR = HERE / "cache"
HTML_DOCS_URL = "https://robot.hetzner.com/doc/webservice/en.html"
HTML_DOCS_PATH = CACHE_DIR / "robot-docs.html"
OUTPUT_PATH = HETZNER_DIR / "specs" / "robot.spec.yaml"
SERVER_URL = "https://robot-ws.your-server.de"


# ---------- helpers ----------------------------------------------------------

def camel_to_snake(name: str) -> str:
    out = re.sub(r"(.)([A-Z][a-z]+)", r"\1_\2", name)
    out = re.sub(r"([a-z0-9])([A-Z])", r"\1_\2", out)
    return out.lower()


def php_type_to_openapi(php_type: str) -> dict[str, Any]:
    php_type = php_type.strip().lstrip("?")
    if php_type in ("int", "integer"):
        return {"type": "integer"}
    if php_type in ("bool", "boolean"):
        return {"type": "boolean"}
    if php_type in ("float", "double", "number"):
        return {"type": "number"}
    if php_type == "array":
        return {"type": "array", "items": {}}
    if php_type == "object":
        return {"type": "object"}
    return {"type": "string"}


# ---------- JSON example → OpenAPI schema -----------------------------------

_DATE_RE = re.compile(r"^\d{4}-\d{2}-\d{2}$")
_DATETIME_RE = re.compile(r"^\d{4}-\d{2}-\d{2}[T ]\d{2}:\d{2}:\d{2}")
_IPV4_RE = re.compile(r"^\d{1,3}(\.\d{1,3}){3}$")
# Strict: must contain `::` somewhere (compressed-zero notation) to qualify
# as IPv6. This avoids matching MAC addresses (which are hex+colons too).
_IPV6_RE = re.compile(r"^[0-9a-fA-F:]+::[0-9a-fA-F:]*$")
# An "identifier-like" key (snake_case, camelCase, UPPER_SNAKE). Used to
# detect dictionaries whose keys are *values* (IPs, UUIDs, numbers) rather
# than property names — in which case we emit `additionalProperties` instead
# of named properties.
_IDENTIFIER_KEY_RE = re.compile(r"^[A-Za-z_][A-Za-z0-9_]*$")


def infer_schema(value: Any) -> dict[str, Any]:
    """Infer an OpenAPI schema from a JSON example value.

    Pragmatic: returns the tightest schema that describes the example.
    Lists are inferred as `array` of merged item schemas; objects as
    `object` with `properties`. `null` values yield `nullable: true` with
    no type constraint (caller may set type from context).
    """
    if value is None:
        return {"nullable": True}
    if isinstance(value, bool):
        return {"type": "boolean"}
    if isinstance(value, int):
        return {"type": "integer"}
    if isinstance(value, float):
        return {"type": "number"}
    if isinstance(value, str):
        schema: dict[str, Any] = {"type": "string"}
        if _DATE_RE.match(value):
            schema["format"] = "date"
        elif _DATETIME_RE.match(value):
            schema["format"] = "date-time"
        elif _IPV4_RE.match(value):
            schema["format"] = "ipv4"
        elif _IPV6_RE.match(value):
            schema["format"] = "ipv6"
        return schema
    if isinstance(value, list):
        if not value:
            return {"type": "array", "items": {}}
        items_schema = merge_schemas([infer_schema(v) for v in value])
        return {"type": "array", "items": items_schema}
    if isinstance(value, dict):
        # Distinguish "record" (keys are property names) from "map" (keys are
        # data values like IPs/UUIDs). If every key looks like an identifier,
        # treat as a record. Otherwise treat the value as a homogeneous map.
        keys = list(value.keys())
        if keys and all(_IDENTIFIER_KEY_RE.match(k) for k in keys):
            props: dict[str, Any] = {}
            for k, v in value.items():
                props[k] = infer_schema(v)
            return {"type": "object", "properties": props}
        # Map shape: emit additionalProperties with the merged value schema.
        if value:
            values_schema = merge_schemas([infer_schema(v) for v in value.values()])
            return {"type": "object", "additionalProperties": values_schema or True}
        return {"type": "object", "additionalProperties": True}
    return {}


def merge_schemas(schemas: list[dict[str, Any]]) -> dict[str, Any]:
    """Merge a list of inferred schemas into one. Used for array items where
    elements may vary slightly (e.g. one element has a nullable field).
    """
    if not schemas:
        return {}
    if len(schemas) == 1:
        return schemas[0]

    types = {s.get("type") for s in schemas if "type" in s}
    nullable = any(s.get("nullable") for s in schemas)

    if len(types) == 1:
        t = next(iter(types))
        if t == "object":
            # Merge properties — union of keys; per-key merge schemas.
            all_keys: dict[str, list[dict[str, Any]]] = {}
            for s in schemas:
                for k, v in (s.get("properties") or {}).items():
                    all_keys.setdefault(k, []).append(v)
            merged_props = {k: merge_schemas(v) for k, v in all_keys.items()}
            out: dict[str, Any] = {"type": "object", "properties": merged_props}
            if nullable:
                out["nullable"] = True
            return out
        if t == "array":
            items = merge_schemas([s.get("items", {}) for s in schemas])
            return {"type": "array", "items": items, **({"nullable": True} if nullable else {})}
        merged = {"type": t}
        if nullable:
            merged["nullable"] = True
        # Preserve format if all agree
        formats = {s.get("format") for s in schemas if s.get("format")}
        if len(formats) == 1:
            merged["format"] = next(iter(formats))
        return merged

    # Heterogeneous — fall back to no constraint.
    out = {}
    if nullable:
        out["nullable"] = True
    return out


# ---------- PHP parsing ------------------------------------------------------

@dataclass
class Endpoint:
    operation_id: str
    http_verb: str                                   # uppercase: GET, POST, PUT, DELETE
    url_template: str
    path_params: list[dict[str, Any]] = field(default_factory=list)
    query_params: list[dict[str, Any]] = field(default_factory=list)
    body_fields: list[dict[str, Any]] = field(default_factory=list)
    has_arbitrary_query: bool = False
    summary: str = ""
    description: str = ""


@dataclass
class PhpParam:
    name: str
    php_type: str = ""
    doc_type: str = ""
    description: str = ""
    optional: bool = False
    default: str | None = None


@dataclass
class PhpMethod:
    name: str
    summary: str
    description: str
    params: list[PhpParam]
    body: str

    @property
    def php_name_snake(self) -> str:
        return camel_to_snake(self.name)


# Match a doc block followed by `public function`, refusing to span across
# another `function` keyword. We achieve that with a negated-class inside the
# docblock content.
_PHPDOC_BLOCK = re.compile(
    # Signature may itself contain `()` in default values, e.g.
    # `array $authorizedKeys = array()`. Allow one level of nested parens.
    r"/\*\*((?:(?!\*/).)*?)\*/\s*public function (\w+)\s*\(((?:[^()]|\([^()]*\))*)\)\s*\{(.*?)^  \}",
    re.DOTALL | re.MULTILINE,
)


def _parse_phpdoc(doc: str) -> tuple[str, str, dict[str, tuple[str, str]]]:
    """Return (summary, description, {param_name: (type, description)})."""
    summary_lines: list[str] = []
    desc_lines: list[str] = []
    params: dict[str, tuple[str, str]] = {}
    for raw in doc.splitlines():
        line = raw.strip().lstrip("*").strip()
        if not line:
            continue
        m = re.match(r"@param\s+([\w|\\?]+)\s+\$(\w+)\s*(.*)", line)
        if m:
            params[m.group(2)] = (m.group(1), m.group(3).strip())
            continue
        if line.startswith("@"):
            continue
        if not summary_lines:
            summary_lines.append(line)
        else:
            desc_lines.append(line)
    return " ".join(summary_lines).strip(), " ".join(desc_lines).strip(), params


def _parse_php_signature(sig: str, doc_params: dict[str, tuple[str, str]]) -> list[PhpParam]:
    sig = sig.strip()
    if not sig:
        return []

    # Split top-level commas only.
    parts: list[str] = []
    depth = 0
    cur = ""
    for ch in sig:
        if ch == "(":
            depth += 1
        elif ch == ")":
            depth -= 1
        if ch == "," and depth == 0:
            parts.append(cur.strip())
            cur = ""
        else:
            cur += ch
    if cur.strip():
        parts.append(cur.strip())

    out: list[PhpParam] = []
    for part in parts:
        m = re.match(r"(?:(\??\w+)\s+)?\$(\w+)(?:\s*=\s*(.+))?$", part)
        if not m:
            continue
        php_type = (m.group(1) or "").strip()
        name = m.group(2)
        default = m.group(3)
        doc_type, doc_desc = doc_params.get(name, ("", ""))
        out.append(PhpParam(
            name=name,
            php_type=php_type,
            doc_type=doc_type,
            description=doc_desc,
            optional=default is not None or php_type.startswith("?"),
            default=default,
        ))
    return out


@dataclass
class _BodyParse:
    http_verb: str = ""
    url_template: str = ""
    path_params_in_order: list[str] = field(default_factory=list)  # snake_case
    query_params: list[str] = field(default_factory=list)          # snake_case
    body_fields: list[tuple[str, str]] = field(default_factory=list)  # (field, php_var)
    has_arbitrary_query: bool = False
    # Params that appear inside `if ($x) { $url .= '/' . $x; }` — i.e. optional
    # path segments. Used to decide whether to split this method into two
    # operations (one with, one without).
    conditional_path_vars: list[str] = field(default_factory=list)


def _parse_method_body(body: str) -> _BodyParse:
    info = _BodyParse()

    # HTTP verb
    verb_match = re.search(r"\$this->(get|post|put|delete)\s*\(", body)
    if not verb_match:
        return info
    info.http_verb = verb_match.group(1).upper()

    # Detect conditional `if ($x) { $url .= '/' . $x ... }` blocks BEFORE
    # concatenating fragments. These mark `$x` as an optional path segment.
    cond_re = re.compile(
        r"if\s*\(\s*\$(\w+)(?:\s*!==?\s*null)?\s*\)\s*\{\s*\$url\s*\.=\s*'/'\s*\.\s*\$\1\s*;?\s*\}",
        re.DOTALL,
    )
    for m in cond_re.finditer(body):
        info.conditional_path_vars.append(camel_to_snake(m.group(1)))

    # Collect URL construction fragments in source order.
    fragments: list[str] = []
    found_base = False
    for line in body.splitlines():
        s = line.strip()
        if re.match(r"\$this->(get|post|put|delete)\s*\(", s):
            break
        m_init = re.match(r"\$url\s*=\s*(.+?);?\s*$", s)
        m_app = re.match(r"\$url\s*\.=\s*(.+?);?\s*$", s)
        if m_init:
            rhs = m_init.group(1)
            rhs = re.sub(r"^\s*\$this->baseUrl\s*\.\s*", "", rhs)
            fragments.append(rhs)
            found_base = True
        elif m_app and found_base:
            fragments.append(m_app.group(1))

    if not fragments:
        return info
    url_expr = " . ".join(fragments)

    # Strip PHP function calls — their inner $vars aren't literal path/query
    # keys (e.g. http_build_query($q) → arbitrary query string).
    url_expr = re.sub(r"\b\w+\s*\([^()]*\)", "<call>", url_expr)

    tokens = re.findall(r"'([^']*)'|\$(\w+)", url_expr)
    path_pieces: list[str] = []
    query_pieces: list[str] = []
    query_section = False
    for lit, var in tokens:
        if lit:
            if "?" in lit and not query_section:
                p, q = lit.split("?", 1)
                path_pieces.append(p)
                query_section = True
                if q:
                    query_pieces.append(q)
            elif query_section:
                query_pieces.append(lit)
            else:
                path_pieces.append(lit)
        elif var:
            snake = camel_to_snake(var)
            if query_section:
                query_pieces.append("{" + snake + "}")
                if snake not in info.query_params:
                    info.query_params.append(snake)
            else:
                path_pieces.append("{" + snake + "}")
                if snake not in info.path_params_in_order:
                    info.path_params_in_order.append(snake)
    info.url_template = "".join(path_pieces) or "/"

    # Request body
    body_call = re.search(
        r"\$this->(?:post|put|delete)\s*\(\s*\$url\s*,\s*(array\s*\(.*?\)|\[.*?\])\s*\)",
        body,
        re.DOTALL,
    )
    if body_call:
        info.body_fields = _parse_php_array(body_call.group(1))

    # Arbitrary query
    if re.search(r"http_build_query\s*\(\s*\$\w+\b", body):
        info.has_arbitrary_query = True

    return info


def _parse_php_array(text: str) -> list[tuple[str, str]]:
    """Parse `array('k' => $v, 'k2' => $v2)` or `['k' => $v]`."""
    inner = text.strip()
    if inner.startswith("array"):
        inner = inner[len("array"):].strip()
    if inner.startswith("(") and inner.endswith(")"):
        inner = inner[1:-1]
    elif inner.startswith("[") and inner.endswith("]"):
        inner = inner[1:-1]
    out: list[tuple[str, str]] = []
    for m in re.finditer(r"'([^']+)'\s*=>\s*\$(\w+)", inner):
        out.append((m.group(1), m.group(2)))
    return out


def parse_php_client(path: Path) -> list[Endpoint]:
    text = path.read_text()
    endpoints: list[Endpoint] = []

    for match in _PHPDOC_BLOCK.finditer(text):
        doc_text, name, sig, body = match.groups()
        if name == "__construct":
            continue
        summary, description, doc_params = _parse_phpdoc(doc_text)
        sig_params = _parse_php_signature(sig, doc_params)
        body_info = _parse_method_body(body)
        if not body_info.http_verb or not body_info.url_template:
            continue

        # Helper to convert a PHP variable name to a param dict.
        def build_param(var_snake: str, location: str) -> dict[str, Any]:
            sig_p = _find_param(sig_params, var_snake)
            php_type = (sig_p.php_type or sig_p.doc_type) if sig_p else "string"
            schema = php_type_to_openapi(php_type)
            param: dict[str, Any] = {
                "name": var_snake,
                "in": location,
                "required": location == "path",
                "schema": schema,
            }
            if sig_p and sig_p.description:
                param["description"] = sig_p.description
            return param

        path_params = [build_param(p, "path") for p in body_info.path_params_in_order]
        query_params = [build_param(p, "query") for p in body_info.query_params]

        body_fields: list[dict[str, Any]] = []
        for field_name, php_var in body_info.body_fields:
            sig_p = _find_param(sig_params, php_var)
            php_type = (sig_p.php_type or sig_p.doc_type) if sig_p else "string"
            schema = php_type_to_openapi(php_type)
            if sig_p and sig_p.description:
                schema["description"] = sig_p.description
            body_fields.append({
                "name": field_name,
                "required": not (sig_p and sig_p.optional),
                "schema": schema,
            })

        primary = Endpoint(
            operation_id=name,
            http_verb=body_info.http_verb,
            url_template=body_info.url_template,
            path_params=path_params,
            query_params=query_params,
            body_fields=body_fields,
            has_arbitrary_query=body_info.has_arbitrary_query,
            summary=summary,
            description=description,
        )
        endpoints.append(primary)

        # Split path-conditional operations. When a function has
        #   `if ($x) { $url .= '/' . $x; }`
        # and `$x` is optional with default null, the method models BOTH a
        # collection URL and a single-resource URL. Emit a second endpoint
        # for the collection (without the path segment).
        if body_info.conditional_path_vars:
            for cond_var in body_info.conditional_path_vars:
                sig_p = _find_param(sig_params, cond_var)
                if not sig_p or not sig_p.optional:
                    continue
                # Strip the segment from the path & path_params.
                stripped_url = primary.url_template.replace("/{" + cond_var + "}", "")
                if stripped_url == primary.url_template:
                    continue
                collection_op_id = _collection_operation_id(name)
                # Avoid emitting a duplicate operationId.
                if any(e.operation_id == collection_op_id and e.http_verb == primary.http_verb
                       for e in endpoints):
                    continue
                collection_summary = primary.summary
                if collection_summary and not collection_summary.lower().endswith("list"):
                    collection_summary = collection_summary + " (collection)"
                collection = Endpoint(
                    operation_id=collection_op_id,
                    http_verb=primary.http_verb,
                    url_template=stripped_url,
                    path_params=[p for p in path_params if p["name"] != cond_var],
                    query_params=query_params,
                    body_fields=body_fields,
                    has_arbitrary_query=primary.has_arbitrary_query,
                    summary=collection_summary,
                    description=primary.description,
                )
                endpoints.append(collection)

    return endpoints


def _collection_operation_id(php_name: str) -> str:
    """Derive a collection (list-all) operationId from a single-item PHP name."""
    # serverGet → serverGetAll (matches Hetzner's own naming for `serverGetAll`).
    if php_name.endswith("Get"):
        return php_name + "All"
    return php_name + "All"


def _find_param(params: list[PhpParam], name: str) -> PhpParam | None:
    snake = name.lower()
    for p in params:
        if camel_to_snake(p.name).lower() == snake:
            return p
        if p.name.lower() == snake:
            return p
    return None


# ---------- HTML docs scraping ----------------------------------------------

@dataclass
class HtmlEndpoint:
    verb: str
    path_template: str      # path with {curly-braces} placeholders
    section_id: str
    description: str = ""
    response_example: Any | None = None     # parsed JSON value
    input_fields: dict[str, str] = field(default_factory=dict)  # field → description


def ensure_html_docs(refresh: bool = False) -> Path:
    CACHE_DIR.mkdir(parents=True, exist_ok=True)
    if not HTML_DOCS_PATH.exists() or refresh:
        print(f"  fetching {HTML_DOCS_URL} ...", file=sys.stderr)
        with urllib.request.urlopen(HTML_DOCS_URL) as resp:
            HTML_DOCS_PATH.write_bytes(resp.read())
    return HTML_DOCS_PATH


_H2_ENDPOINT_RE = re.compile(r"^([A-Z]+)\s+(/\S+)$")


def _normalise_html_path(path: str) -> str:
    """Convert `/server/{server-number}` (HTML style with hyphens) to
    `/server/{server_number}` (PHP/OpenAPI style with underscores)."""
    def replace(m: re.Match) -> str:
        return "{" + m.group(1).replace("-", "_") + "}"
    return re.sub(r"\{([^}]+)\}", replace, path)


def parse_html_docs(html_path: Path) -> dict[tuple[str, str], HtmlEndpoint]:
    soup = BeautifulSoup(html_path.read_text(), "html.parser")
    by_key: dict[tuple[str, str], HtmlEndpoint] = {}

    for h2 in soup.find_all("h2"):
        text = h2.get_text(strip=True)
        m = _H2_ENDPOINT_RE.match(text)
        if not m:
            continue
        verb = m.group(1).upper()
        if verb not in {"GET", "POST", "PUT", "DELETE", "PATCH"}:
            continue
        path = _normalise_html_path(m.group(2))
        section_id = h2.get("id", "")

        # Collect siblings until the next h2 — that's this endpoint's section.
        section_nodes: list[Any] = []
        for sib in h2.next_siblings:
            if getattr(sib, "name", None) in ("h2", "h1"):
                break
            section_nodes.append(sib)

        ep = HtmlEndpoint(verb=verb, path_template=path, section_id=section_id)

        # Iterate sections: each <h3> introduces a sub-block.
        current_section = ""
        for node in section_nodes:
            name = getattr(node, "name", None)
            if name == "h3":
                current_section = node.get_text(strip=True).lower()
                continue

            if current_section == "description" and name == "p":
                if not ep.description:
                    ep.description = node.get_text(" ", strip=True)

            if current_section in ("output", "") and name is not None:
                # Look for JSON code blocks (highlighted as `json`).
                for code in node.find_all("pre", class_=re.compile(r"json"), limit=1):
                    raw = code.get_text("")
                    parsed = _try_parse_json(raw)
                    if parsed is not None and ep.response_example is None:
                        ep.response_example = parsed
                        break
                # Some pages embed the pre directly without wrapping div.find.
                if name == "pre" and "json" in (node.get("class") or []):
                    parsed = _try_parse_json(node.get_text(""))
                    if parsed is not None and ep.response_example is None:
                        ep.response_example = parsed

            if current_section == "input" and name == "table":
                for row in node.find_all("tr"):
                    cells = row.find_all("td")
                    if len(cells) >= 2:
                        ep.input_fields[cells[0].get_text(strip=True)] = \
                            cells[1].get_text(" ", strip=True)

        # As a final pass, try harder to find the JSON example anywhere in the section.
        if ep.response_example is None:
            for node in section_nodes:
                if getattr(node, "name", None) is None:
                    continue
                for code in node.find_all("pre", class_=re.compile(r"json")):
                    parsed = _try_parse_json(code.get_text(""))
                    if parsed is not None:
                        ep.response_example = parsed
                        break
                if ep.response_example is not None:
                    break

        by_key[(verb, path)] = ep

    return by_key


def _try_parse_json(text: str) -> Any | None:
    text = htmllib.unescape(text).strip()
    if not text:
        return None
    try:
        return json.loads(text)
    except json.JSONDecodeError:
        # Some examples contain things like /* comment */ — strip & retry.
        stripped = re.sub(r"/\*.*?\*/", "", text, flags=re.DOTALL)
        try:
            return json.loads(stripped)
        except json.JSONDecodeError:
            return None


# ---------- Path-param name unification -------------------------------------

def unify_path_param_names(endpoints: list[Endpoint]) -> None:
    """OpenAPI rejects two paths that differ only by parameter name. For each
    structural path signature, the first endpoint seen claims the canonical
    parameter names; subsequent endpoints are rewritten to match.
    """
    canonical: dict[str, list[str]] = {}
    for ep in endpoints:
        if not ep.path_params:
            continue
        slots: list[str] = []
        normalised_segments: list[str] = []
        for seg in ep.url_template.split("/"):
            if seg.startswith("{") and seg.endswith("}"):
                slots.append(seg[1:-1])
                normalised_segments.append("{}")
            else:
                normalised_segments.append(seg)
        normalised = "/".join(normalised_segments)

        if normalised not in canonical:
            canonical[normalised] = slots
            continue

        canon = canonical[normalised]
        if canon == slots:
            continue
        rename = {old: new for old, new in zip(slots, canon) if old != new}
        if not rename:
            continue

        new_url_segments: list[str] = []
        slot_idx = 0
        for seg in ep.url_template.split("/"):
            if seg.startswith("{") and seg.endswith("}"):
                new_url_segments.append("{" + canon[slot_idx] + "}")
                slot_idx += 1
            else:
                new_url_segments.append(seg)
        ep.url_template = "/".join(new_url_segments)
        for p in ep.path_params:
            if p["name"] in rename:
                p["name"] = rename[p["name"]]


# ---------- OpenAPI emission -------------------------------------------------

def _path_shape(path: str) -> str:
    """Reduce a path template to its structural shape, with all {param}
    placeholders replaced by a positional marker. Used to match endpoints
    across sources that use different parameter names (e.g. PHP `{id}` vs
    HTML `{storagebox-id}`)."""
    return re.sub(r"\{[^}]+\}", "{}", path)


def _operation_to_class_name(op_id: str, suffix: str = "Response") -> str:
    # serverGet → ServerGetResponse;  failoverGetAll → FailoverGetAllResponse
    pascal = op_id[:1].upper() + op_id[1:]
    return pascal + suffix


def _register_schema(
    preferred_name: str,
    op_id: str,
    schema: dict[str, Any],
    components: dict[str, dict[str, Any]],
) -> str:
    """Register `schema` in `components` and return the chosen name.

    If `preferred_name` is already in use with the same shape, reuse it.
    If it's in use with a different shape, fall back to an operation-scoped
    name `<OpId><PreferredName>` to disambiguate. Numeric suffixes are
    avoided because they're meaningless to consumers.
    """
    if preferred_name not in components:
        components[preferred_name] = schema
        return preferred_name
    if components[preferred_name] == schema:
        return preferred_name
    # Conflict — disambiguate by prefixing with the operation name.
    scoped = _operation_to_class_name(op_id, suffix="") + _pascal(preferred_name)
    if scoped not in components:
        components[scoped] = schema
    elif components[scoped] != schema:
        # Last-resort numeric suffix — should be rare.
        n = 2
        while f"{scoped}{n}" in components and components[f"{scoped}{n}"] != schema:
            n += 1
        scoped = f"{scoped}{n}"
        components.setdefault(scoped, schema)
    return scoped


def _unwrap_response(
    schema: dict[str, Any],
    op_id: str,
) -> tuple[dict[str, Any], str | None]:
    """If `schema` is a single-property wrapper that Hetzner conventionally
    uses around its real payload (e.g. `{"server": {...}}` or
    `{"servers": [{...}]}`), unwrap it.

    Returns `(inner_schema, preferred_name)`. `preferred_name` is the
    PascalCase form of the wrapper key (singularised for arrays), suitable
    for naming the inner type. If no unwrap applies, returns the input
    unchanged and `preferred_name=None`.
    """
    if (
        schema.get("type") != "object"
        or not isinstance(schema.get("properties"), dict)
        or len(schema["properties"]) != 1
    ):
        return schema, None
    key, inner = next(iter(schema["properties"].items()))
    if not isinstance(inner, dict):
        return schema, None

    if inner.get("type") == "object" and isinstance(inner.get("properties"), dict):
        return inner, _pascal(key)

    if inner.get("type") == "array" and isinstance(inner.get("items"), dict):
        items = inner["items"]
        if items.get("type") == "object" and isinstance(items.get("properties"), dict):
            # Array wrapper: return the array schema with items renamed via the
            # singularised key.
            return inner, _singular(_pascal(key))

    return schema, None


def _pascal(name: str) -> str:
    parts = re.split(r"[_\-\s]+", name)
    return "".join(p[:1].upper() + p[1:] for p in parts if p)


def _extract_nested_schemas(
    schema: dict[str, Any],
    base_name: str,
    component_schemas: dict[str, dict[str, Any]],
    *,
    prefer_property_name: bool = False,
) -> dict[str, Any]:
    """Walk a schema tree. Each object-with-properties gets extracted into
    components.schemas and replaced in-place with a $ref.

    Naming strategy:
    - Top-level call uses `base_name` (e.g. `ServerGetResponse`).
    - Nested object properties get named after the property itself
      (`{server: {...}}` → inner schema is `Server`, not
      `ServerGetResponseServer`). This matches Hetzner's response-wrapping
      convention where every response is `{singular_key: object}` or
      `{plural_key: [object]}`.
    - Array items are singularised forms of their parent's property name.
    - Identical shapes deduplicate to a single component; differing shapes
      collide and get numeric suffixes (`Server`, `Server2`, ...).
    """
    if not isinstance(schema, dict):
        return schema

    t = schema.get("type")

    if t == "array" and isinstance(schema.get("items"), dict):
        items = schema["items"]
        if items.get("type") == "object" and items.get("properties"):
            item_name = _singular(base_name) or base_name + "Item"
            schema["items"] = _extract_nested_schemas(items, item_name, component_schemas,
                                                     prefer_property_name=False)
        else:
            schema["items"] = _extract_nested_schemas(items, base_name, component_schemas)
        return schema

    if t == "object" and isinstance(schema.get("properties"), dict):
        new_props: dict[str, Any] = {}
        for prop_name, prop_schema in schema["properties"].items():
            # Nested property objects/arrays use the property's own name as
            # their type name (e.g. `server`, `cancellation_reason`).
            nested_base = _pascal(prop_name)
            if not nested_base:
                nested_base = base_name + _pascal(prop_name)
            new_props[prop_name] = _extract_nested_schemas(
                prop_schema, nested_base, component_schemas, prefer_property_name=True,
            )
        schema["properties"] = new_props

        # Use property-name-derived schema name for nested objects; fall back
        # to the prefixed name on collision with a different shape.
        unique_name = base_name
        n = 2
        while unique_name in component_schemas and component_schemas[unique_name] != schema:
            unique_name = f"{base_name}{n}"
            n += 1
        component_schemas[unique_name] = schema
        return {"$ref": f"#/components/schemas/{unique_name}"}

    return schema


def _singular(name: str) -> str:
    """Naive English singularisation. `Servers` → `Server`; `Boxes` → `Box`."""
    if name.endswith("ies"):
        return name[:-3] + "y"
    if name.endswith("ses") or name.endswith("xes"):
        return name[:-2]
    if name.endswith("s") and not name.endswith("ss"):
        return name[:-1]
    return name


def build_openapi(
    endpoints: list[Endpoint],
    html_endpoints: dict[tuple[str, str], HtmlEndpoint],
) -> dict[str, Any]:
    # Index HTML endpoints by structural shape so we can match across
    # parameter-name differences.
    html_by_shape: dict[tuple[str, str], HtmlEndpoint] = {
        (verb, _path_shape(path)): ep
        for (verb, path), ep in html_endpoints.items()
    }

    unify_path_param_names(endpoints)

    # Build component schemas as we go. The Error schema is seeded first so
    # later schema-name dedup doesn't clobber it.
    component_schemas: dict[str, dict[str, Any]] = {
        "Error": {
            "type": "object",
            "properties": {
                "error": {
                    "type": "object",
                    "properties": {
                        "status": {"type": "integer"},
                        "code": {"type": "string"},
                        "message": {"type": "string"},
                        "missing": {
                            "type": "array",
                            "items": {"type": "string"},
                            "nullable": True,
                        },
                        "invalid": {
                            "type": "array",
                            "items": {"type": "string"},
                            "nullable": True,
                        },
                    },
                },
            },
        },
    }

    paths: dict[str, dict[str, Any]] = {}
    enriched = 0
    described = 0
    for ep in endpoints:
        path_item = paths.setdefault(ep.url_template, {})
        verb_lower = ep.http_verb.lower()

        operation: dict[str, Any] = {"operationId": ep.operation_id}
        html_ep = html_endpoints.get((ep.http_verb, ep.url_template)) \
            or html_by_shape.get((ep.http_verb, _path_shape(ep.url_template)))

        if html_ep and html_ep.description:
            operation["summary"] = ep.summary or _first_sentence(html_ep.description)
            operation["description"] = html_ep.description
            described += 1
        elif ep.summary:
            operation["summary"] = ep.summary
            if ep.description:
                operation["description"] = ep.description

        operation["tags"] = [_tag_for(ep.url_template)]

        parameters: list[dict[str, Any]] = []
        for p in ep.path_params:
            parameters.append(p)
        for p in ep.query_params:
            parameters.append(p)
        if ep.has_arbitrary_query:
            parameters.append({
                "name": "query",
                "in": "query",
                "required": False,
                "description": "Additional ad-hoc query parameters as accepted by Hetzner.",
                "schema": {"type": "object", "additionalProperties": True},
                "style": "form",
                "explode": True,
            })
        if parameters:
            operation["parameters"] = parameters

        if ep.body_fields and verb_lower in {"post", "put", "delete"}:
            props: dict[str, Any] = {}
            required: list[str] = []
            for bf in ep.body_fields:
                schema = bf["schema"]
                if html_ep and bf["name"] in html_ep.input_fields:
                    desc = html_ep.input_fields[bf["name"]]
                    if "description" not in schema:
                        schema = {**schema, "description": desc}
                props[bf["name"]] = schema
                if bf["required"]:
                    required.append(bf["name"])
            body_schema: dict[str, Any] = {"type": "object", "properties": props}
            if required:
                body_schema["required"] = required
            operation["requestBody"] = {
                "required": True,
                "content": {
                    "application/x-www-form-urlencoded": {"schema": body_schema},
                },
            }

        # Response schema from HTML example, or generic fallback.
        response_schema: dict[str, Any] = {"type": "object", "additionalProperties": True}
        if html_ep and html_ep.response_example is not None:
            inferred = infer_schema(html_ep.response_example)
            response_name = _operation_to_class_name(ep.operation_id)
            response_schema = _extract_nested_schemas(inferred, response_name, component_schemas)
            enriched += 1

        success_code = "204" if verb_lower == "delete" and not html_ep else "200"
        if html_ep and html_ep.response_example is None and verb_lower == "delete":
            success_code = "204"

        operation["responses"] = {
            success_code: {
                "description": "Success",
                **({"content": {"application/json": {"schema": response_schema}}}
                   if success_code != "204" else {}),
            },
            "default": {
                "description": "Error",
                "content": {
                    "application/json": {"schema": {"$ref": "#/components/schemas/Error"}},
                },
            },
        }

        path_item[verb_lower] = operation

    print(f"   {enriched}/{len(endpoints)} operations enriched with response schema "
          f"from HTML docs", file=sys.stderr)
    print(f"   {described}/{len(endpoints)} operations got descriptions from HTML docs",
          file=sys.stderr)

    spec: dict[str, Any] = {}
    spec["openapi"] = "3.0.3"
    spec["info"] = {
        "title": "Hetzner Robot Webservice",
        "version": "1.0.0",
        "description": textwrap.dedent(f"""\
            Reverse-engineered OpenAPI specification for the Hetzner Robot
            Webservice ({SERVER_URL}).

            Paths, HTTP verbs, path parameters, query parameters and request
            bodies are derived from Hetzner's official PHP reference client.
            Response schemas and endpoint descriptions are derived from
            Hetzner's official HTML reference documentation.

            Authentication is HTTP Basic using a Web Service user created in
            the Robot panel (Settings → Web service and app settings). Note
            that this is a separate user account from the main Robot login.
            """),
        "license": {
            "name": "Hetzner Robot Webservice documentation",
            "url": "https://robot.hetzner.com/doc/webservice/en.html",
        },
    }
    spec["servers"] = [{"url": SERVER_URL}]
    spec["security"] = [{"BasicAuth": []}]
    spec["paths"] = paths
    spec["components"] = {
        "securitySchemes": {
            "BasicAuth": {"type": "http", "scheme": "basic"},
        },
        "schemas": component_schemas,
    }
    print(f"   {len(component_schemas)} component schemas extracted", file=sys.stderr)
    return spec


def _tag_for(path: str) -> str:
    parts = path.strip("/").split("/")
    return parts[0] if parts else "default"


def _first_sentence(text: str) -> str:
    m = re.search(r"^(.*?[.!?])(\s|$)", text)
    return m.group(1) if m else text


# ---------- main -------------------------------------------------------------

def main() -> int:
    ap = argparse.ArgumentParser(description=__doc__.splitlines()[0])
    ap.add_argument("--refresh", action="store_true",
                    help="Force re-download of the HTML docs")
    args = ap.parse_args()

    if not PHP_PATH.exists():
        print(f"ERROR: {PHP_PATH} not found.", file=sys.stderr)
        return 1

    print(f"== Parsing PHP client: {PHP_PATH.name}", file=sys.stderr)
    endpoints = parse_php_client(PHP_PATH)
    print(f"   {len(endpoints)} operations extracted "
          f"(includes path-split variants)", file=sys.stderr)

    print("== Fetching HTML docs", file=sys.stderr)
    html_path = ensure_html_docs(refresh=args.refresh)
    html_endpoints = parse_html_docs(html_path)
    print(f"   {len(html_endpoints)} endpoint sections found in HTML",
          file=sys.stderr)

    spec = build_openapi(endpoints, html_endpoints)

    OUTPUT_PATH.parent.mkdir(parents=True, exist_ok=True)
    with OUTPUT_PATH.open("w") as f:
        yaml.safe_dump(spec, f, sort_keys=False, allow_unicode=True,
                       default_flow_style=False, width=120)
    print(f"== Wrote {OUTPUT_PATH.relative_to(HETZNER_DIR.parent)}", file=sys.stderr)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
