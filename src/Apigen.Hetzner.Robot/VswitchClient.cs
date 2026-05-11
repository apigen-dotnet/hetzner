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
/// Client for vswitch operations
/// </summary>
public partial class VswitchClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal VswitchClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Create a new vSwitch
  /// Operation: POST /vswitch
  /// </summary>
  public async Task<VswitchCreateResponse> CreateAsync()
  {
    string url = "vswitch";

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
    VswitchCreateResponse? result = JsonSerializer.Deserialize<VswitchCreateResponse>(responseContent, JsonConfig.Default);
    return result ?? new VswitchCreateResponse();
  }


  /// <summary>
  /// Change the VLAN id of a vSwitch
  /// Operation: POST /vswitch/{vswitch_id}
  /// </summary>
  public async Task<JsonElement> VswitchChangeVlanAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchChangeVlanRequest vswitchChangeVlanRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["vswitch_id"] = vswitchId
    };
    string url = "vswitch/{vswitch_id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = vswitchChangeVlanRequest.ToFormUrlEncodedContent();
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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// Cancel a vSwitch
  /// Operation: DELETE /vswitch/{vswitch_id}
  /// </summary>
  public async Task DeleteAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchCancelRequest vswitchCancelRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["vswitch_id"] = vswitchId
    };
    string url = "vswitch/{vswitch_id}".BuildUrl(pathParams);

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


  /// <summary>
  /// Add servers to a vSwitch
  /// Operation: POST /vswitch/{vswitch_id}/server
  /// </summary>
  public async Task<JsonElement> VswitchAddServersAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchAddServersRequest vswitchAddServersRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["vswitch_id"] = vswitchId
    };
    string url = "vswitch/{vswitch_id}/server".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = vswitchAddServersRequest.ToFormUrlEncodedContent();
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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// Remove servers from a vSwitch
  /// Operation: DELETE /vswitch/{vswitch_id}/server
  /// </summary>
  public async Task VswitchRemoveServersAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchRemoveServersRequest vswitchRemoveServersRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["vswitch_id"] = vswitchId
    };
    string url = "vswitch/{vswitch_id}/server".BuildUrl(pathParams);

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
