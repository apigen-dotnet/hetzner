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
/// Client for ip operations
/// </summary>
public partial class IpClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal IpClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all single ips of specific server
  /// Operation: GET /ip
  /// </summary>
  public async Task<List<IpGetByServerIpResponse>> ListAsync(IpGetByServerIpRequest? request = null)
  {
    string url = "ip".BuildUrl(request: request);

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
    List<IpGetByServerIpResponse>? result = JsonSerializer.Deserialize<List<IpGetByServerIpResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<IpGetByServerIpResponse>();
  }


  /// <summary>
  /// Get ip
  /// Operation: GET /ip/{ip}
  /// </summary>
  public async Task<IpGetResponse> GetAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "ip/{ip}".BuildUrl(pathParams);

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
    IpGetResponse? result = JsonSerializer.Deserialize<IpGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new IpGetResponse();
  }


  /// <summary>
  /// Set traffic warning limits for single ip
  /// Operation: POST /ip/{ip}
  /// </summary>
  public async Task<IpSetTrafficWarningLimitsResponse> IpSetTrafficWarningLimitsAsync(string ip, Apigen.Hetzner.Robot.Models.IpSetTrafficWarningLimitsRequest ipSetTrafficWarningLimitsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "ip/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = ipSetTrafficWarningLimitsRequest.ToFormUrlEncodedContent();
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
    IpSetTrafficWarningLimitsResponse? result = JsonSerializer.Deserialize<IpSetTrafficWarningLimitsResponse>(responseContent, JsonConfig.Default);
    return result ?? new IpSetTrafficWarningLimitsResponse();
  }


  /// <summary>
  /// Get separate mac for a single ip
  /// Operation: GET /ip/{ip}/mac
  /// </summary>
  public async Task<SeparateMacGetResponse> SeparateMacGetAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "ip/{ip}/mac".BuildUrl(pathParams);

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
    SeparateMacGetResponse? result = JsonSerializer.Deserialize<SeparateMacGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new SeparateMacGetResponse();
  }


  /// <summary>
  /// Create separate mac for a single ip
  /// Operation: PUT /ip/{ip}/mac
  /// </summary>
  public async Task<SeparateMacCreateResponse> SeparateMacCreateAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "ip/{ip}/mac".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    HttpResponseMessage response = await _httpClient.PutAsync(url, null);
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
    SeparateMacCreateResponse? result = JsonSerializer.Deserialize<SeparateMacCreateResponse>(responseContent, JsonConfig.Default);
    return result ?? new SeparateMacCreateResponse();
  }


  /// <summary>
  /// Delete separate mac for a single ip
  /// Operation: DELETE /ip/{ip}/mac
  /// </summary>
  public async Task<SeparateMacDeleteResponse> SeparateMacDeleteAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "ip/{ip}/mac".BuildUrl(pathParams);

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
    SeparateMacDeleteResponse? result = JsonSerializer.Deserialize<SeparateMacDeleteResponse>(responseContent, JsonConfig.Default);
    return result ?? new SeparateMacDeleteResponse();
  }


}
