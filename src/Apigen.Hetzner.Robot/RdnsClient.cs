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
/// Client for rdns operations
/// </summary>
public partial class RdnsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal RdnsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get rdns entry for ip
  /// Operation: GET /rdns/{ip}
  /// </summary>
  public async Task<RdnsGetResponse> GetAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "rdns/{ip}".BuildUrl(pathParams);

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
    RdnsGetResponse? result = JsonSerializer.Deserialize<RdnsGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new RdnsGetResponse();
  }


  /// <summary>
  /// Create rdns entry for ip
  /// Operation: PUT /rdns/{ip}
  /// </summary>
  public async Task<RdnsCreateResponse> UpdateAsync(string ip, Apigen.Hetzner.Robot.Models.RdnsCreateRequest rdnsCreateRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "rdns/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    FormUrlEncodedContent content = rdnsCreateRequest.ToFormUrlEncodedContent();
    string formBody = await content.ReadAsStringAsync();
    HttpClientLog.LogTraceRequestBody(_logger, "PUT", "application/x-www-form-urlencoded", formBody);
    HttpResponseMessage response = await _httpClient.PutAsync(url, content);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "PUT", url, durationMs);

    string responseContent;
    try
    {
      response.EnsureSuccessStatusCode();
      responseContent = await response.Content.ReadAsStringAsync();
    }
    catch (HttpRequestException ex)
    {
      responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "PUT", url, responseContent, ex);
      throw;
    }

    HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
    RdnsCreateResponse? result = JsonSerializer.Deserialize<RdnsCreateResponse>(responseContent, JsonConfig.Default);
    return result ?? new RdnsCreateResponse();
  }


  /// <summary>
  /// Update rdns entry for ip
  /// Operation: POST /rdns/{ip}
  /// </summary>
  public async Task<RdnsUpdateResponse> RdnsUpdateAsync(string ip, Apigen.Hetzner.Robot.Models.RdnsUpdateRequest rdnsUpdateRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "rdns/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = rdnsUpdateRequest.ToFormUrlEncodedContent();
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
    RdnsUpdateResponse? result = JsonSerializer.Deserialize<RdnsUpdateResponse>(responseContent, JsonConfig.Default);
    return result ?? new RdnsUpdateResponse();
  }


  /// <summary>
  /// Delete rdns entry for ip
  /// Operation: DELETE /rdns/{ip}
  /// </summary>
  public async Task DeleteAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "rdns/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "DELETE", url);
    HttpResponseMessage response = await _httpClient.DeleteAsync(url);
    long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
    HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "DELETE", url, durationMs);

    try
    {
      response.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      string responseContent = await response.Content.ReadAsStringAsync();
      HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "DELETE", url, responseContent, ex);
      throw;
    }
  }


}
