using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Request parameters for List Placement Groups
/// Operation: GET /placement_groups
/// </summary>
public partial class ListPlacementGroupsRequest : BaseRequest
{
  /// <summary>
  /// Sort resources by field and direction. May be used multiple times.
  /// 
  /// For more information, see &quot;[Sorting](#description/sorting)&quot;.
  /// 
  /// </summary>
  [JsonPropertyName("sort")]
  public string[]? Sort { get; set; }

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
  /// Filter resources by labels.
  /// 
  /// The response will only contain resources matching the label selector.
  /// For more information, see &quot;[Label Selector](#description/label-selector)&quot;.
  /// 
  /// </summary>
  [JsonPropertyName("label_selector")]
  public string? LabelSelector { get; set; }

  /// <summary>
  /// Filter resources by type. May be used multiple times.
  /// 
  /// The response will only contain the resources with the specified type.
  /// 
  /// </summary>
  [JsonPropertyName("type")]
  public string[]? Type { get; set; }

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

    if (Sort != null)
      queryParams["sort"] = Sort;
    if (Name != null)
      queryParams["name"] = Name;
    if (LabelSelector != null)
      queryParams["label_selector"] = LabelSelector;
    if (Type != null)
      queryParams["type"] = Type;
    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;

    return queryParams.ToQueryString();
  }
}
