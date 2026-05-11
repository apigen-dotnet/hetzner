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
/// Client for failover operations
/// </summary>
public partial class FailoverClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal FailoverClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get failover
  /// Operation: GET /failover/{ip}
  /// </summary>
  public async Task<FailoverGetResponse> GetAsync(string ip, FailoverGetRequest? request = null)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "failover/{ip}".BuildUrl(pathParams, request);

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
    FailoverGetResponse? result = JsonSerializer.Deserialize<FailoverGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new FailoverGetResponse();
  }


  /// <summary>
  /// Route failover
  /// Operation: POST /failover/{ip}
  /// </summary>
  public async Task<FailoverRouteResponse> FailoverRouteAsync(string ip, Apigen.Hetzner.Robot.Models.FailoverRouteRequest failoverRouteRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "failover/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = failoverRouteRequest.ToFormUrlEncodedContent();
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
    FailoverRouteResponse? result = JsonSerializer.Deserialize<FailoverRouteResponse>(responseContent, JsonConfig.Default);
    return result ?? new FailoverRouteResponse();
  }


  /// <summary>
  /// Delete failover routing
  /// Operation: DELETE /failover/{ip}
  /// </summary>
  public async Task<FailoverDeleteResponse> DeleteAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "failover/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    FailoverDeleteResponse? result = JsonSerializer.Deserialize<FailoverDeleteResponse>(responseContent, JsonConfig.Default);
    return result ?? new FailoverDeleteResponse();
  }


  /// <summary>
  /// Get failover (collection)
  /// Operation: GET /failover
  /// </summary>
  public async Task<List<FailoverGetAllResponse>> ListAsync(FailoverGetAllRequest? request = null)
  {
    string url = "failover".BuildUrl(request: request);

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
    List<FailoverGetAllResponse>? result = JsonSerializer.Deserialize<List<FailoverGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<FailoverGetAllResponse>();
  }


}
