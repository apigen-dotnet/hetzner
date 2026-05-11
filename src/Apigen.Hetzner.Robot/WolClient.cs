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
/// Client for wol operations
/// </summary>
public partial class WolClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal WolClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get Wake On Lan data
  /// Operation: GET /wol/{server_number}
  /// </summary>
  public async Task<WolGetResponse> GetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "wol/{server_number}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "GET", url);
    HttpResponseMessage response = await _httpClient.GetAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "GET", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "GET", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    WolGetResponse? result = JsonSerializer.Deserialize<WolGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new WolGetResponse();
  }


  /// <summary>
  /// Send Wake On Lan packet to server
  /// Operation: POST /wol/{server_number}
  /// </summary>
  public async Task<WolSendResponse> WolSendAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "wol/{server_number}".BuildUrl(pathParams);

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
    WolSendResponse? result = JsonSerializer.Deserialize<WolSendResponse>(responseContent, JsonConfig.Default);
    return result ?? new WolSendResponse();
  }


}
