using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Request parameters for Get multiple Actions
/// Operation: GET /actions
/// </summary>
public partial class GetActionsRequest : BaseRequest
{
  /// <summary>
  /// Filter the actions by ID. May be used multiple times.
  /// 
  /// The response will only contain actions matching the specified IDs.
  /// 
  /// </summary>
  [JsonPropertyName("id")]
  public string[]? Id { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Id != null)
      queryParams["id"] = Id;

    return queryParams.ToQueryString();
  }
}
