using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Request parameters for Get all ssh public keys
/// Operation: GET /key
/// </summary>
public partial class KeyGetAllRequest : BaseRequest
{
  /// <summary>
  /// Additional ad-hoc query parameters as accepted by Hetzner.
  /// </summary>
  [JsonPropertyName("query")]
  public string? Query { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Query != null)
      queryParams["query"] = Query;

    return queryParams.ToQueryString();
  }
}
