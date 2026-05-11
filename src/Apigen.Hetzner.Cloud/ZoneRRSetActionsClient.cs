using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Client for Zone RRSet Actions operations
/// </summary>
public partial class ZoneRRSetActionsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ZoneRRSetActionsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Change an RRSet&apos;s Protection
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/change_protection
  /// </summary>
  public async Task<JsonElement> ChangeZoneRrsetProtectionAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.ChangeZoneRrsetProtectionRequest changeZoneRrsetProtectionRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id_or_name"] = idOrName,
      ["rr_name"] = rrName,
      ["rr_type"] = rrType
    };
    string url = "zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/change_protection".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(changeZoneRrsetProtectionRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
  /// Change an RRSet&apos;s TTL
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/change_ttl
  /// </summary>
  public async Task<JsonElement> ChangeZoneRrsetTtlAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.ChangeZoneRrsetTtlRequest changeZoneRrsetTtlRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id_or_name"] = idOrName,
      ["rr_name"] = rrName,
      ["rr_type"] = rrType
    };
    string url = "zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/change_ttl".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(changeZoneRrsetTtlRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
  /// Set Records of an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/set_records
  /// </summary>
  public async Task<JsonElement> SetZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.SetZoneRrsetRecordsRequest setZoneRrsetRecordsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id_or_name"] = idOrName,
      ["rr_name"] = rrName,
      ["rr_type"] = rrType
    };
    string url = "zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/set_records".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(setZoneRrsetRecordsRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
  /// Add Records to an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/add_records
  /// </summary>
  public async Task<JsonElement> AddZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.AddZoneRrsetRecordsRequest addZoneRrsetRecordsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id_or_name"] = idOrName,
      ["rr_name"] = rrName,
      ["rr_type"] = rrType
    };
    string url = "zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/add_records".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(addZoneRrsetRecordsRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
  /// Remove Records from an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/remove_records
  /// </summary>
  public async Task<JsonElement> RemoveZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.RemoveZoneRrsetRecordsRequest removeZoneRrsetRecordsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id_or_name"] = idOrName,
      ["rr_name"] = rrName,
      ["rr_type"] = rrType
    };
    string url = "zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/remove_records".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(removeZoneRrsetRecordsRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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
  /// Update Records of an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/update_records
  /// </summary>
  public async Task<JsonElement> UpdateZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.UpdateZoneRrsetRecordsRequest updateZoneRrsetRecordsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id_or_name"] = idOrName,
      ["rr_name"] = rrName,
      ["rr_type"] = rrType
    };
    string url = "zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/update_records".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(updateZoneRrsetRecordsRequest, JsonConfig.Default);
    HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
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


}
