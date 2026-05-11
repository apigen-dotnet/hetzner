using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Request parameters for List folders of a Storage Box
/// Operation: GET /storage_boxes/{id}/folders
/// </summary>
public partial class ListStorageBoxFoldersRequest : BaseRequest
{
  /// <summary>
  /// Relative path for which the listing is to be made.
  /// </summary>
  [JsonPropertyName("path")]
  public string? Path { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Path != null)
      queryParams["path"] = Path;

    return queryParams.ToQueryString();
  }
}
