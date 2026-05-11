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
/// Client for firewall operations
/// </summary>
public partial class FirewallClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal FirewallClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get firewall of server
  /// Operation: GET /firewall/{server_number}/{port}
  /// </summary>
  public async Task<JsonElement> GetAsync(string serverNumber, string port)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber,
      ["port"] = port
    };
    string url = "firewall/{server_number}/{port}".BuildUrl(pathParams);

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
    JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
    return result;
  }


  /// <summary>
  /// Craete new firewall or update existing firewall from template
  /// Operation: POST /firewall/{server_number}/{port}
  /// </summary>
  public async Task<JsonElement> FirewallCreateOrUpdateFromTemplateAsync(string serverNumber, string port, Apigen.Hetzner.Robot.Models.FirewallCreateOrUpdateFromTemplateRequest firewallCreateOrUpdateFromTemplateRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber,
      ["port"] = port
    };
    string url = "firewall/{server_number}/{port}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = firewallCreateOrUpdateFromTemplateRequest.ToFormUrlEncodedContent();
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
  /// Delete firewall
  /// Operation: DELETE /firewall/{server_number}/{port}
  /// </summary>
  public async Task DeleteAsync(string serverNumber, string port)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber,
      ["port"] = port
    };
    string url = "firewall/{server_number}/{port}".BuildUrl(pathParams);

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
  /// Get all existing firewall templates
  /// Operation: GET /firewall/template
  /// </summary>
  public async Task<List<FirewallTemplateGetAllResponse>> FirewallTemplateGetAllAsync()
  {
    string url = "firewall/template";

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
    List<FirewallTemplateGetAllResponse>? result = JsonSerializer.Deserialize<List<FirewallTemplateGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<FirewallTemplateGetAllResponse>();
  }


  /// <summary>
  /// Create a new firewall template
  /// Operation: POST /firewall/template
  /// </summary>
  public async Task<FirewallTemplateCreateResponse> FirewallTemplateCreateAsync(Apigen.Hetzner.Robot.Models.FirewallTemplateCreateRequest firewallTemplateCreateRequest)
  {
    string url = "firewall/template";

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = firewallTemplateCreateRequest.ToFormUrlEncodedContent();
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
    FirewallTemplateCreateResponse? result = JsonSerializer.Deserialize<FirewallTemplateCreateResponse>(responseContent, JsonConfig.Default);
    return result ?? new FirewallTemplateCreateResponse();
  }


  /// <summary>
  /// Get a specific firewall template by ID
  /// Operation: GET /firewall/template/{template_id}
  /// </summary>
  public async Task<FirewallTemplateGetResponse> GetAsync(string templateId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["template_id"] = templateId
    };
    string url = "firewall/template/{template_id}".BuildUrl(pathParams);

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
    FirewallTemplateGetResponse? result = JsonSerializer.Deserialize<FirewallTemplateGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new FirewallTemplateGetResponse();
  }


  /// <summary>
  /// Update a existing firewall template name
  /// Operation: POST /firewall/template/{template_id}
  /// </summary>
  public async Task<FirewallTemplateUpdateNameResponse> FirewallTemplateUpdateNameAsync(int templateId, Apigen.Hetzner.Robot.Models.FirewallTemplateUpdateNameRequest firewallTemplateUpdateNameRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["template_id"] = templateId
    };
    string url = "firewall/template/{template_id}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = firewallTemplateUpdateNameRequest.ToFormUrlEncodedContent();
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
    FirewallTemplateUpdateNameResponse? result = JsonSerializer.Deserialize<FirewallTemplateUpdateNameResponse>(responseContent, JsonConfig.Default);
    return result ?? new FirewallTemplateUpdateNameResponse();
  }


  /// <summary>
  /// Delete a firewall template
  /// Operation: DELETE /firewall/template/{template_id}
  /// </summary>
  public async Task DeleteAsync(int templateId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["template_id"] = templateId
    };
    string url = "firewall/template/{template_id}".BuildUrl(pathParams);

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
