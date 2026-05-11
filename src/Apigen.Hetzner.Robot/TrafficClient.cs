using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Client for traffic operations
/// </summary>
public partial class TrafficClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal TrafficClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get traffic for single ips and subnets
  /// Operation: POST /traffic
  /// </summary>
  public async Task<TrafficGetResponse> CreateAsync()
  {
    string url = "traffic";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    HttpResponseMessage response = await _httpClient.PostAsync(url, null);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    TrafficGetResponse? result = JsonSerializer.Deserialize<TrafficGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new TrafficGetResponse();
  }


}
