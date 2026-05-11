using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Request parameters for List ISOs
/// Operation: GET /isos
/// </summary>
public partial class ListIsosRequest : BaseRequest
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
  /// Filter resources by cpu architecture.
  /// 
  /// The response will only contain the resources with the specified cpu architecture.
  /// 
  /// </summary>
  [JsonPropertyName("architecture")]
  public string? Architecture { get; set; }

  /// <summary>
  /// Include Images with wildcard architecture (architecture is null). Architecture filter must be specified.
  /// </summary>
  [JsonPropertyName("include_architecture_wildcard")]
  public bool? IncludeArchitectureWildcard { get; set; }

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
    if (Architecture != null)
      queryParams["architecture"] = Architecture;
    if (IncludeArchitectureWildcard != null)
      queryParams["include_architecture_wildcard"] = IncludeArchitectureWildcard;
    if (Page != null)
      queryParams["page"] = Page;
    if (PerPage != null)
      queryParams["per_page"] = PerPage;

    return queryParams.ToQueryString();
  }
}
