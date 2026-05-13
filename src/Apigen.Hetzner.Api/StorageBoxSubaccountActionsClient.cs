using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
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
  public async Task<JsonElement> ChangeStorageBoxSubaccountHomeDirectoryAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.ChangeStorageBoxSubaccountHomeDirectoryRequest changeStorageBoxSubaccountHomeDirectoryRequest, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["subaccount_id"] = subaccountId
    };
    string url = "storage_boxes/{id}/subaccounts/{subaccount_id}/actions/change_home_directory".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(changeStorageBoxSubaccountHomeDirectoryRequest, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorBody, null);
        throw new ApiException(response.StatusCode, "POST", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
      return result;
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "POST", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "POST", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "POST", url, ex);
      throw;
    }
  }


  /// <summary>
  /// Reset Password
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/reset_subaccount_password
  /// </summary>
  public async Task<JsonElement> ResetStorageBoxSubaccountPasswordAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.ResetStorageBoxSubaccountPasswordRequest resetStorageBoxSubaccountPasswordRequest, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["subaccount_id"] = subaccountId
    };
    string url = "storage_boxes/{id}/subaccounts/{subaccount_id}/actions/reset_subaccount_password".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(resetStorageBoxSubaccountPasswordRequest, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorBody, null);
        throw new ApiException(response.StatusCode, "POST", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
      return result;
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "POST", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "POST", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "POST", url, ex);
      throw;
    }
  }


  /// <summary>
  /// Update Access Settings
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/update_access_settings
  /// </summary>
  public async Task<JsonElement> UpdateStorageBoxSubaccountAccessSettingsAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.UpdateStorageBoxSubaccountAccessSettingsRequest updateStorageBoxSubaccountAccessSettingsRequest, CancellationToken cancellationToken = default)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["id"] = id,
      ["subaccount_id"] = subaccountId
    };
    string url = "storage_boxes/{id}/subaccounts/{subaccount_id}/actions/update_access_settings".BuildUrl(pathParams);

    try
    {
      long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
      HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
      string json = JsonSerializer.Serialize(updateStorageBoxSubaccountAccessSettingsRequest, JsonConfig.Default);
      HttpClientLog.LogTraceRequestBody(_logger, "POST", "application/json", json);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
      HttpResponseMessage response = await _httpClient.PostAsync(url, content, cancellationToken);
      long durationMs = (long)System.Diagnostics.Stopwatch.GetElapsedTime(startTimestamp).TotalMilliseconds;
      HttpClientLog.LogDebugRequestCompleted(_logger, (int)response.StatusCode, "POST", url, durationMs);

      if (!response.IsSuccessStatusCode)
      {
        string errorBody = await response.Content.ReadAsStringAsync(cancellationToken);
        HttpClientLog.LogErrorRequestFailed(_logger, (int)response.StatusCode, "POST", url, errorBody, null);
        throw new ApiException(response.StatusCode, "POST", url, errorBody, response.Headers, response.Content.Headers);
      }

      string responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
      HttpClientLog.LogTraceResponseBody(_logger, url, responseContent);
      JsonElement result = JsonSerializer.Deserialize<JsonElement>(responseContent, JsonConfig.Default);
      return result;
    }
    catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
    {
      HttpClientLog.LogDebugRequestCancelled(_logger, "POST", url);
      throw;
    }
    catch (OperationCanceledException ex)
    {
      HttpClientLog.LogErrorRequestTimeout(_logger, "POST", url, ex);
      throw;
    }
    catch (HttpRequestException ex) when (ex is not ApiException)
    {
      HttpClientLog.LogErrorTransportFailure(_logger, "POST", url, ex);
      throw;
    }
  }


}
