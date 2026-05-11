using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Request parameters for Get Metrics for a Server
/// Operation: GET /servers/{id}/metrics
/// </summary>
public partial class GetServerMetricsRequest : BaseRequest
{
  /// <summary>
  /// Type of metrics to get.
  /// </summary>
  [JsonPropertyName("type")]
  public string[]? Type { get; set; }

  /// <summary>
  /// Start of period to get Metrics for (must be in [RFC3339](https://datatracker.ietf.org/doc/html/rfc3339#section-5.6) format).
  /// </summary>
  [JsonPropertyName("start")]
  public string? Start { get; set; }

  /// <summary>
  /// End of period to get Metrics for (must be in [RFC3339](https://datatracker.ietf.org/doc/html/rfc3339#section-5.6) format).
  /// </summary>
  [JsonPropertyName("end")]
  public string? End { get; set; }

  /// <summary>
  /// Resolution of results in seconds.
  /// </summary>
  [JsonPropertyName("step")]
  public string? Step { get; set; }

  public override string ToQueryString()
  {
    Dictionary<string, object> queryParams = new Dictionary<string, object>();

    if (Type != null)
      queryParams["type"] = Type;
    if (Start != null)
      queryParams["start"] = Start;
    if (End != null)
      queryParams["end"] = End;
    if (Step != null)
      queryParams["step"] = Step;

    return queryParams.ToQueryString();
  }
}
