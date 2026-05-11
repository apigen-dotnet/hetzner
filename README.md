# Apigen.Hetzner

Generated C# clients for Hetzner's public REST APIs.

| Package | API | Base URL | Auth |
|---|---|---|---|
| `Apigen.Hetzner.Cloud` | Hetzner Cloud | `https://api.hetzner.cloud/v1` | Bearer token |
| `Apigen.Hetzner.Api` | Hetzner (DNS etc.) | `https://api.hetzner.com/v1` | Bearer token |
| `Apigen.Hetzner.Robot` | Robot Webservice | `https://robot-ws.your-server.de` | HTTP Basic |
| `Apigen.Hetzner` | umbrella meta-package | — | — |

## Installation

```bash
dotnet add package Apigen.Hetzner            # all three
dotnet add package Apigen.Hetzner.Cloud      # just Cloud
dotnet add package Apigen.Hetzner.Api        # just unified API
dotnet add package Apigen.Hetzner.Robot      # just Robot
```

## Usage

```csharp
using Apigen.Hetzner.Cloud;
using Apigen.Hetzner.Api;
using Apigen.Hetzner.Robot;

var cloud = HetznerCloudClient.WithBearer(Environment.GetEnvironmentVariable("HCLOUD_TOKEN")!);
var api   = HetznerApiClient.WithBearer(Environment.GetEnvironmentVariable("HETZNER_TOKEN")!);
var robot = HetznerRobotClient.WithBasic(
    user:     Environment.GetEnvironmentVariable("ROBOT_WS_USER")!,
    password: Environment.GetEnvironmentVariable("ROBOT_WS_PASSWORD")!);

var cloudServers     = await cloud.Servers.GetAllAsync();
var dnsZones         = await api.Zones.ListAsync();
var dedicatedServers = await robot.Server.GetAllAsync();
```

Each client is independent — they don't share state, configuration, or tokens.

## Why three clients?

Hetzner has three distinct public REST APIs, hosted on three different domains,
authenticated with three different credential systems, and documented in three
different places. Mixing them into a single client would force users to manage
three tokens behind one façade with no real benefit, so each is its own
strongly-typed surface and the `Apigen.Hetzner` package simply bundles them as
a convenience.

There is also a Hetzner Domain Registration interface, but it is **email-only**
and not exposed via any HTTP API; it is not part of this package.

## Source specs

| Source | How it is produced |
|---|---|
| `specs/cloud.spec.json` | Downloaded from <https://docs.hetzner.cloud/cloud.spec.json>. Official OpenAPI 3.0.3. |
| `specs/api.spec.json` | Downloaded from <https://docs.hetzner.cloud/hetzner.spec.json>. Official OpenAPI 3.0.3. |
| `specs/robot.spec.yaml` | **Generated** by `tools/build_robot_spec.py` from Hetzner's official [PHP reference client](https://robot.your-server.de/downloads/robot-client.zip) (paths, HTTP verbs, path/query/body params) enriched with response schemas extracted from the [community.hrobot Ansible collection](https://github.com/ansible-collections/community.hrobot). |

The Robot spec is reverse-engineered because Hetzner does not publish an
OpenAPI document for the Robot Webservice. The script is deterministic and
re-runnable; see `tools/build_robot_spec.py` for details.

## Regeneration

From the repo root:

```bash
# Regenerate the Robot spec from the latest PHP client and Ansible modules:
python3 hetzner/tools/build_robot_spec.py

# Then regenerate all three .NET clients via the project-wide generator:
./generate-all.sh hetzner
```

## License

MIT — see [LICENSE](LICENSE).

The community.hrobot Ansible collection is GPL-3.0; only its YAML schema
metadata is read at spec-build time. No GPL-licensed code is shipped in any
NuGet package.
