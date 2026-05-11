# Apigen.Hetzner

Generated C# clients for Hetzner's three public REST APIs, bundled as one umbrella package.

```bash
# Everything at once:
dotnet add package Apigen.Hetzner

# Or just the part you need:
dotnet add package Apigen.Hetzner.Cloud
dotnet add package Apigen.Hetzner.Api
dotnet add package Apigen.Hetzner.Robot
```

## Why three clients?

The three APIs are unrelated services with different base URLs, different
credentials, and different documentation. They are not interchangeable.

| Client | Endpoint | Auth | Credential source |
|---|---|---|---|
| `Apigen.Hetzner.Cloud` | `api.hetzner.cloud/v1` | Bearer token | Cloud Console → Project → API tokens |
| `Apigen.Hetzner.Api` | `api.hetzner.com/v1` | Bearer token | Hetzner Console → Security → API tokens |
| `Apigen.Hetzner.Robot` | `robot-ws.your-server.de` | HTTP Basic | Robot panel → Settings → Web service user |

Tokens are not shared between them.

## Usage

```csharp
using Apigen.Hetzner.Cloud;
using Apigen.Hetzner.Api;
using Apigen.Hetzner.Robot;

var cloud = HetznerCloudClient.WithBearer("hcloud-token-here");
var api   = HetznerApiClient.WithBearer("hetzner-account-token-here");
var robot = HetznerRobotClient.WithBasic("#ws+user", "ws-password");

// Each client has its own typed API surface generated from OpenAPI.
var servers = await cloud.Servers.GetAllAsync();
var zones   = await api.Zones.ListAsync();
var hosts   = await robot.Server.GetAllAsync();
```

## Versioning

`major.minor` tracks the upstream Hetzner API generation; `patch` is the client revision.

## Source

- Repository: <https://github.com/apigen-dotnet/hetzner>
- Generator: <https://github.com/apigen-dotnet/generator>
- Cloud OpenAPI: <https://docs.hetzner.cloud/cloud.spec.json>
- API OpenAPI: <https://docs.hetzner.cloud/hetzner.spec.json>
- Robot reference: <https://robot.hetzner.com/doc/webservice/en.html> (HTML) and the [official PHP client](https://robot.your-server.de/downloads/robot-client.zip)
- Robot response schemas: [community.hrobot Ansible collection](https://github.com/ansible-collections/community.hrobot) (LGPL-3.0 — used only for schema extraction)

## License

MIT
