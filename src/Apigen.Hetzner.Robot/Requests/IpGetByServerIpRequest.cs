using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Request parameters for Get all single ips of specific server
/// Operation: GET /ip
/// </summary>
public partial class IpGetByServerIpRequest : BaseRequest
{
  /// <summary>
  /// Server main ip
  /// </summary>
  [JsonPropertyName("server_ip")]
  public string? ServerIp { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (ServerIp != null)
      queryParams["server_ip"] = ServerIp;

    return queryParams.ToQueryString();
  }
}
