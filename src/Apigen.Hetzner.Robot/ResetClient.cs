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
/// Client for reset operations
/// </summary>
public partial class ResetClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ResetClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get server reset
  /// Operation: GET /reset/{server_number}
  /// </summary>
  public async Task<ResetGetResponse> GetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "reset/{server_number}".BuildUrl(pathParams);

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
    ResetGetResponse? result = JsonSerializer.Deserialize<ResetGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new ResetGetResponse();
  }


  /// <summary>
  /// Execute server reset
  /// Operation: POST /reset/{server_number}
  /// </summary>
  public async Task<ResetExecuteResponse> ResetExecuteAsync(string serverNumber, Apigen.Hetzner.Robot.Models.ResetExecuteRequest resetExecuteRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "reset/{server_number}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = resetExecuteRequest.ToFormUrlEncodedContent();
    string formBody = await content.ReadAsStringAsync();
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/x-www-form-urlencoded", formBody);
    HttpResponseMessage response = await _httpClient.PostAsync(url, content);
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
    ResetExecuteResponse? result = JsonSerializer.Deserialize<ResetExecuteResponse>(responseContent, JsonConfig.Default);
    return result ?? new ResetExecuteResponse();
  }


  /// <summary>
  /// Get server reset (collection)
  /// Operation: GET /reset
  /// </summary>
  public async Task<List<ResetGetAllResponse>> ListAsync()
  {
    string url = "reset";

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
    List<ResetGetAllResponse>? result = JsonSerializer.Deserialize<List<ResetGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<ResetGetAllResponse>();
  }


}
