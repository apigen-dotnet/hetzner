using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Request parameters for List Snapshots
/// Operation: GET /storage_boxes/{id}/snapshots
/// </summary>
public partial class ListStorageBoxSnapshotsRequest : BaseRequest
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
  /// Filter resources by labels.
  /// 
  /// The response will only contain resources matching the label selector.
  /// For more information, see &quot;[Label Selector](#description/label-selector)&quot;.
  /// 
  /// </summary>
  [JsonPropertyName("label_selector")]
  public string? LabelSelector { get; set; }

  /// <summary>
  /// Sort resources by field and direction. May be used multiple times.
  /// 
  /// For more information, see &quot;[Sorting](#description/sorting)&quot;.
  /// 
  /// </summary>
  [JsonPropertyName("sort")]
  public string[]? Sort { get; set; }

  /// <summary>
  /// Filter wether a [Storage Box Snapshot](#tag/storage-box-snapshots) is automatic.
  /// 
  /// </summary>
  [JsonPropertyName("is_automatic")]
  public bool? IsAutomatic { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Name != null)
      queryParams["name"] = Name;
    if (LabelSelector != null)
      queryParams["label_selector"] = LabelSelector;
    if (Sort != null)
      queryParams["sort"] = Sort;
    if (IsAutomatic != null)
      queryParams["is_automatic"] = IsAutomatic;

    return queryParams.ToQueryString();
  }
}
