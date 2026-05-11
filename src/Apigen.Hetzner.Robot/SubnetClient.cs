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
/// Client for subnet operations
/// </summary>
public partial class SubnetClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal SubnetClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all subnets of specific server
  /// Operation: GET /subnet
  /// </summary>
  public async Task<List<SubnetGetByServerIpResponse>> ListAsync(SubnetGetByServerIpRequest? request = null)
  {
    string url = "subnet".BuildUrl(request: request);

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
    List<SubnetGetByServerIpResponse>? result = JsonSerializer.Deserialize<List<SubnetGetByServerIpResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<SubnetGetByServerIpResponse>();
  }


  /// <summary>
  /// Get subnet
  /// Operation: GET /subnet/{ip}
  /// </summary>
  public async Task<SubnetGetResponse> GetAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "subnet/{ip}".BuildUrl(pathParams);

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
    SubnetGetResponse? result = JsonSerializer.Deserialize<SubnetGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new SubnetGetResponse();
  }


  /// <summary>
  /// Set traffic warning limits for subnet
  /// Operation: POST /subnet/{ip}
  /// </summary>
  public async Task<SubnetSetTrafficWarningLimitsResponse> SubnetSetTrafficWarningLimitsAsync(string ip, Apigen.Hetzner.Robot.Models.SubnetSetTrafficWarningLimitsRequest subnetSetTrafficWarningLimitsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "subnet/{ip}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = subnetSetTrafficWarningLimitsRequest.ToFormUrlEncodedContent();
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
    SubnetSetTrafficWarningLimitsResponse? result = JsonSerializer.Deserialize<SubnetSetTrafficWarningLimitsResponse>(responseContent, JsonConfig.Default);
    return result ?? new SubnetSetTrafficWarningLimitsResponse();
  }


  /// <summary>
  /// Get the mac address of a ipv6 subnet
  /// Operation: GET /subnet/{ip}/mac
  /// </summary>
  public async Task<SubnetMacGetResponse> SubnetMacGetAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "subnet/{ip}/mac".BuildUrl(pathParams);

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
    SubnetMacGetResponse? result = JsonSerializer.Deserialize<SubnetMacGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new SubnetMacGetResponse();
  }


  /// <summary>
  /// Set the mac address of a ipv6 subnet
  /// Operation: PUT /subnet/{ip}/mac
  /// </summary>
  public async Task<SubnetMacSetResponse> SubnetMacSetAsync(string ip, Apigen.Hetzner.Robot.Models.SubnetMacSetRequest subnetMacSetRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "subnet/{ip}/mac".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "PUT", url);
    FormUrlEncodedContent content = subnetMacSetRequest.ToFormUrlEncodedContent();
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
    SubnetMacSetResponse? result = JsonSerializer.Deserialize<SubnetMacSetResponse>(responseContent, JsonConfig.Default);
    return result ?? new SubnetMacSetResponse();
  }


  /// <summary>
  /// Reset the mac address of a ipv6 subnet to the
  /// Operation: DELETE /subnet/{ip}/mac
  /// </summary>
  public async Task<SubnetMacResetResponse> SubnetMacResetAsync(string ip)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["ip"] = ip
    };
    string url = "subnet/{ip}/mac".BuildUrl(pathParams);

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
    SubnetMacResetResponse? result = JsonSerializer.Deserialize<SubnetMacResetResponse>(responseContent, JsonConfig.Default);
    return result ?? new SubnetMacResetResponse();
  }


}
