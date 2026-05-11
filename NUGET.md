# Apigen.Hetzner

One NuGet package, three generated C# clients for Hetzner's public REST APIs.

```bash
dotnet add package Apigen.Hetzner
```

## What's inside

| Client | Endpoint | Auth | Credential source |
|---|---|---|---|
| `Apigen.Hetzner.Cloud` | `api.hetzner.cloud/v1` | Bearer token | Cloud Console → Project → API tokens |
| `Apigen.Hetzner.Api` | `api.hetzner.com/v1` | Bearer token | Hetzner Console → Security → API tokens |
| `Apigen.Hetzner.Robot` | `robot-ws.your-server.de` | HTTP Basic | Robot panel → Settings → Web service user |

The three APIs are unrelated services with different base URLs, different
credentials and different documentation. Tokens are not shared between them.

## Usage

```csharp
using Apigen.Hetzner.Cloud;
using Apigen.Hetzner.Api;
using Apigen.Hetzner.Robot;

var cloud = HetznerCloudClient.WithBearer("hcloud-token");
var api   = HetznerApiClient.WithBearer("hetzner-account-token");
var robot = HetznerRobotClient.WithBasic("#ws+user", "ws-password");

var cloudServers     = await cloud.Servers.ListServersAsync();
var dnsZones         = await api.Zones.ListAsync();
var dedicatedServers = await robot.Server.GetAllAsync();
var serverDetail     = (await robot.Server.GetAsync("321")).Server;
Console.WriteLine(serverDetail.ServerIp);
```

## Versioning

`major.minor` tracks the upstream Hetzner API generation; `patch` is the client revision.

## Source

- Repository: <https://github.com/apigen-dotnet/hetzner>
- Generator: <https://github.com/apigen-dotnet/generator>
- Cloud OpenAPI: <https://docs.hetzner.cloud/cloud.spec.json>
- API OpenAPI: <https://docs.hetzner.cloud/hetzner.spec.json>
- Robot reference: <https://robot.hetzner.com/doc/webservice/en.html> (HTML) and the [official PHP client](https://robot.your-server.de/downloads/robot-client.zip).
  The Robot OpenAPI spec is reverse-engineered by `tools/build_robot_spec.py`.

## License

MIT
