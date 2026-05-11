using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Client for Storage Box Subaccount Actions operations
/// </summary>
public partial class StorageBoxSubaccountActionsClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal StorageBoxSubaccountActionsClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Change Home Directory
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/change_home_directory
  /// </summary>
  public async Task<JsonElement> ChangeStorageBoxSubaccountHomeDirectoryAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.ChangeStorageBoxSubaccountHomeDirectoryRequest changeStorageBoxSubaccountHomeDirectoryRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["subaccount_id"] = subaccountId
    };
    string url = "storage_boxes/{id}/subaccounts/{subaccount_id}/actions/change_home_directory".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(changeStorageBoxSubaccountHomeDirectoryRequest, JsonConfig.Default);
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
  /// Reset Password
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/reset_subaccount_password
  /// </summary>
  public async Task<JsonElement> ResetStorageBoxSubaccountPasswordAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.ResetStorageBoxSubaccountPasswordRequest resetStorageBoxSubaccountPasswordRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["subaccount_id"] = subaccountId
    };
    string url = "storage_boxes/{id}/subaccounts/{subaccount_id}/actions/reset_subaccount_password".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(resetStorageBoxSubaccountPasswordRequest, JsonConfig.Default);
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
  /// Update Access Settings
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/update_access_settings
  /// </summary>
  public async Task<JsonElement> UpdateStorageBoxSubaccountAccessSettingsAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.UpdateStorageBoxSubaccountAccessSettingsRequest updateStorageBoxSubaccountAccessSettingsRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["subaccount_id"] = subaccountId
    };
    string url = "storage_boxes/{id}/subaccounts/{subaccount_id}/actions/update_access_settings".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    string json = JsonSerializer.Serialize(updateStorageBoxSubaccountAccessSettingsRequest, JsonConfig.Default);
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
