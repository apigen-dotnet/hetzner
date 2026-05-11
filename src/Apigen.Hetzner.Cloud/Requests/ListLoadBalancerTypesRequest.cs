using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Request parameters for List Load Balancer Types
/// Operation: GET /load_balancer_types
/// </summary>
public partial class ListLoadBalancerTypesRequest : BaseRequest
{
  /// <summary>
  /// Filter resources by their name.
  /// 
  /// The response will only contain the resources
  /// matching exactly the specified name.
  /// 
  /// </summary>
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  /// <summary>
  /// Page number to return. For more information, see &quot;[Pagination](#description/pagination)&quot;.
  /// </summary>
  [JsonPropertyName("page")]
  public int? Page { get; set; }

  /// <summary>
  /// Maximum number of entries returned per page. For more information, see &quot;[Pagination](#description/pagination)&quot;.
  /// </summary>
  [JsonPropertyName("per_page")]
  public int? PerPage { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Name != null)
      queryParams["name"] = Name;
    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;

    return queryParams.ToQueryString();
  }
}
