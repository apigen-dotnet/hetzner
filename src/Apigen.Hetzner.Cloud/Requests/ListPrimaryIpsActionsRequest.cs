using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Request parameters for List Actions
/// Operation: GET /primary_ips/actions
/// </summary>
public partial class ListPrimaryIpsActionsRequest : BaseRequest
{
  /// <summary>
  /// Filter the actions by ID. May be used multiple times.
  /// 
  /// The response will only contain actions matching the specified IDs.
  /// 
  /// </summary>
  [JsonPropertyName("id")]
  public string[]? Id { get; set; }

  /// <summary>
  /// Sort actions by field and direction. May be used multiple times.
  /// 
  /// For more information, see &quot;[Sorting](#description/sorting)&quot;.
  /// 
  /// </summary>
  [JsonPropertyName("sort")]
  public string[]? Sort { get; set; }

  /// <summary>
  /// Filter the actions by status. May be used multiple times.
  /// 
  /// The response will only contain actions matching the specified statuses.
  /// 
  /// </summary>
  [JsonPropertyName("status")]
  public string[]? Status { get; set; }

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

    if (Id != null)
      queryParams["id"] = Id;
    if (Sort != null)
      queryParams["sort"] = Sort;
    if (Status != null)
      queryParams["status"] = Status;
    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;

    return queryParams.ToQueryString();
  }
}
