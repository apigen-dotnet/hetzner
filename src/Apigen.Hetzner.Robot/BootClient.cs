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
/// Client for boot operations
/// </summary>
public partial class BootClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal BootClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get current boot config
  /// Operation: GET /boot/{server_number}
  /// </summary>
  public async Task<BootGetResponse> GetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}".BuildUrl(pathParams);

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
    BootGetResponse? result = JsonSerializer.Deserialize<BootGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new BootGetResponse();
  }


  /// <summary>
  /// Get server rescue data
  /// Operation: GET /boot/{server_number}/rescue
  /// </summary>
  public async Task<RescueGetResponse> RescueGetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/rescue".BuildUrl(pathParams);

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
    RescueGetResponse? result = JsonSerializer.Deserialize<RescueGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new RescueGetResponse();
  }


  /// <summary>
  /// Deactivate rescue system for a server
  /// Operation: DELETE /boot/{server_number}/rescue
  /// </summary>
  public async Task<RescueDeactivateResponse> RescueDeactivateAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/rescue".BuildUrl(pathParams);

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
    RescueDeactivateResponse? result = JsonSerializer.Deserialize<RescueDeactivateResponse>(responseContent, JsonConfig.Default);
    return result ?? new RescueDeactivateResponse();
  }


  /// <summary>
  /// Get data of last rescue system activation
  /// Operation: GET /boot/{server_number}/rescue/last
  /// </summary>
  public async Task<RescueGetLastResponse> RescueGetLastAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/rescue/last".BuildUrl(pathParams);

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
    RescueGetLastResponse? result = JsonSerializer.Deserialize<RescueGetLastResponse>(responseContent, JsonConfig.Default);
    return result ?? new RescueGetLastResponse();
  }


  /// <summary>
  /// Get linux data
  /// Operation: GET /boot/{server_number}/linux
  /// </summary>
  public async Task<LinuxGetResponse> LinuxGetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/linux".BuildUrl(pathParams);

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
    LinuxGetResponse? result = JsonSerializer.Deserialize<LinuxGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new LinuxGetResponse();
  }


  /// <summary>
  /// Deactivate linux installation
  /// Operation: DELETE /boot/{server_number}/linux
  /// </summary>
  public async Task<LinuxDeactivateResponse> LinuxDeactivateAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/linux".BuildUrl(pathParams);

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
    LinuxDeactivateResponse? result = JsonSerializer.Deserialize<LinuxDeactivateResponse>(responseContent, JsonConfig.Default);
    return result ?? new LinuxDeactivateResponse();
  }


  /// <summary>
  /// Get data of last linux installation activation
  /// Operation: GET /boot/{server_number}/linux/last
  /// </summary>
  public async Task<LinuxGetLastResponse> LinuxGetLastAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/linux/last".BuildUrl(pathParams);

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
    LinuxGetLastResponse? result = JsonSerializer.Deserialize<LinuxGetLastResponse>(responseContent, JsonConfig.Default);
    return result ?? new LinuxGetLastResponse();
  }


  /// <summary>
  /// Get vnc data
  /// Operation: GET /boot/{server_number}/vnc
  /// </summary>
  public async Task<VncGetResponse> VncGetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/vnc".BuildUrl(pathParams);

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
    VncGetResponse? result = JsonSerializer.Deserialize<VncGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new VncGetResponse();
  }


  /// <summary>
  /// Activate vnc installation
  /// Operation: POST /boot/{server_number}/vnc
  /// </summary>
  public async Task<VncActivateResponse> VncActivateAsync(string serverNumber, Apigen.Hetzner.Robot.Models.VncActivateRequest vncActivateRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/vnc".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = vncActivateRequest.ToFormUrlEncodedContent();
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
    VncActivateResponse? result = JsonSerializer.Deserialize<VncActivateResponse>(responseContent, JsonConfig.Default);
    return result ?? new VncActivateResponse();
  }


  /// <summary>
  /// Deactivate vnc installation
  /// Operation: DELETE /boot/{server_number}/vnc
  /// </summary>
  public async Task<VncDeactivateResponse> VncDeactivateAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/vnc".BuildUrl(pathParams);

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
    VncDeactivateResponse? result = JsonSerializer.Deserialize<VncDeactivateResponse>(responseContent, JsonConfig.Default);
    return result ?? new VncDeactivateResponse();
  }


  /// <summary>
  /// Get windows data
  /// Operation: GET /boot/{server_number}/windows
  /// </summary>
  public async Task<WindowsGetResponse> WindowsGetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/windows".BuildUrl(pathParams);

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
    WindowsGetResponse? result = JsonSerializer.Deserialize<WindowsGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new WindowsGetResponse();
  }


  /// <summary>
  /// Activate windows installation
  /// Operation: POST /boot/{server_number}/windows
  /// </summary>
  public async Task<WindowsActivateResponse> WindowsActivateAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/windows".BuildUrl(pathParams);

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
    WindowsActivateResponse? result = JsonSerializer.Deserialize<WindowsActivateResponse>(responseContent, JsonConfig.Default);
    return result ?? new WindowsActivateResponse();
  }


  /// <summary>
  /// Deactivate windows installation
  /// Operation: DELETE /boot/{server_number}/windows
  /// </summary>
  public async Task<WindowsDeactivateResponse> WindowsDeactivateAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "boot/{server_number}/windows".BuildUrl(pathParams);

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
    WindowsDeactivateResponse? result = JsonSerializer.Deserialize<WindowsDeactivateResponse>(responseContent, JsonConfig.Default);
    return result ?? new WindowsDeactivateResponse();
  }


}
