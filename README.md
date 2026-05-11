# Apigen.Hetzner

Single NuGet package with three generated C# clients for Hetzner's public REST APIs.

```bash
dotnet add package Apigen.Hetzner
```

## What's inside

| Client | API | Base URL | Auth |
|---|---|---|---|
| `Apigen.Hetzner.Cloud` | Hetzner Cloud | `https://api.hetzner.cloud/v1` | Bearer token |
| `Apigen.Hetzner.Api` | Hetzner (DNS etc.) | `https://api.hetzner.com/v1` | Bearer token |
| `Apigen.Hetzner.Robot` | Robot Webservice | `https://robot-ws.your-server.de` | HTTP Basic |

One `.nupkg`, no transitive package dependencies. All three client DLLs plus their
model DLLs are bundled inside.

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

var cloudServers     = await cloud.Servers.ListServersAsync();
var dnsZones         = await api.Zones.ListAsync();
var dedicatedServers = await robot.Server.GetAllAsync();
var serverDetail     = (await robot.Server.GetAsync("321")).Server;
```

Each client is independent — they don't share state, configuration, or tokens.

## Why three clients in one package?

Hetzner exposes three distinct public REST APIs, hosted on three different
domains, authenticated with three different credential systems, and documented
in three different places. They are not interchangeable, so each gets its own
strongly-typed C# surface. They are shipped together as one package for
convenience: `dotnet add package Apigen.Hetzner` and you have all three.

A fourth Hetzner interface — Domain Registration — is **email-only** with no
public HTTP API, so it is not part of this package.

## Source specs

| Source | How it is produced |
|---|---|
| `specs/cloud.spec.json` | Downloaded from <https://docs.hetzner.cloud/cloud.spec.json>. Official OpenAPI 3.0.3. |
| `specs/api.spec.json` | Downloaded from <https://docs.hetzner.cloud/hetzner.spec.json>. Official OpenAPI 3.0.3. |
| `specs/robot.spec.yaml` | **Generated** by `tools/build_robot_spec.py` from Hetzner's official [PHP reference client](https://robot.your-server.de/downloads/robot-client.zip) (paths, HTTP verbs, path/query/body params) and Hetzner's official [HTML documentation](https://robot.hetzner.com/doc/webservice/en.html) (response schemas inferred from JSON examples, plus human-readable descriptions). 95 operations, 76 with typed response schemas. |

The Robot spec is reverse-engineered because Hetzner does not publish an
OpenAPI document for the Robot Webservice. The script is deterministic and
re-runnable.

## Regeneration

From the repo root:

```bash
# Regenerate the Robot spec from the latest PHP client and HTML docs:
python3 tools/build_robot_spec.py --refresh

# Then regenerate all three .NET clients:
dotnet run --project ../generator/src/Apigen.Generator -- --config specs/cloud.toml
dotnet run --project ../generator/src/Apigen.Generator -- --config specs/api.toml
dotnet run --project ../generator/src/Apigen.Generator -- --config specs/robot.toml
```

## License

MIT — see [LICENSE](LICENSE).
