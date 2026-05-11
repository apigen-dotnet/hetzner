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
/// Client for server operations
/// </summary>
public partial class ServerClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal ServerClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all servers
  /// Operation: GET /server
  /// </summary>
  public async Task<List<ServerGetAllResponse>> ListAsync()
  {
    string url = "server";

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
    List<ServerGetAllResponse>? result = JsonSerializer.Deserialize<List<ServerGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<ServerGetAllResponse>();
  }


  /// <summary>
  /// Get server by main ip
  /// Operation: GET /server/{server_number}
  /// </summary>
  public async Task<ServerGetResponse> GetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "server/{server_number}".BuildUrl(pathParams);

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
    ServerGetResponse? result = JsonSerializer.Deserialize<ServerGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new ServerGetResponse();
  }


  /// <summary>
  /// Update servername
  /// Operation: POST /server/{server_number}
  /// </summary>
  public async Task<ServernameUpdateResponse> ServernameUpdateAsync(string serverNumber, Apigen.Hetzner.Robot.Models.ServernameUpdateRequest servernameUpdateRequest)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "server/{server_number}".BuildUrl(pathParams);

    long startTimestamp = System.Diagnostics.Stopwatch.GetTimestamp();
    HttpClientLog.LogDebugRequestStarted(_logger, "POST", url);
    FormUrlEncodedContent content = servernameUpdateRequest.ToFormUrlEncodedContent();
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
    ServernameUpdateResponse? result = JsonSerializer.Deserialize<ServernameUpdateResponse>(responseContent, JsonConfig.Default);
    return result ?? new ServernameUpdateResponse();
  }


  /// <summary>
  /// Get cancellation data of a server
  /// Operation: GET /server/{server_number}/cancellation
  /// </summary>
  public async Task<ServerCancellationGetResponse> ServerCancellationGetAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "server/{server_number}/cancellation".BuildUrl(pathParams);

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
    ServerCancellationGetResponse? result = JsonSerializer.Deserialize<ServerCancellationGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new ServerCancellationGetResponse();
  }


  /// <summary>
  /// Cancel a server
  /// Operation: POST /server/{server_number}/cancellation
  /// </summary>
  public async Task<ServerCancelResponse> ServerCancelAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "server/{server_number}/cancellation".BuildUrl(pathParams);

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
    ServerCancelResponse? result = JsonSerializer.Deserialize<ServerCancelResponse>(responseContent, JsonConfig.Default);
    return result ?? new ServerCancelResponse();
  }


  /// <summary>
  /// Revoke a server cancellation
  /// Operation: DELETE /server/{server_number}/cancellation
  /// </summary>
  public async Task ServerCancellationDeleteAsync(string serverNumber)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["server_number"] = serverNumber
    };
    string url = "server/{server_number}/cancellation".BuildUrl(pathParams);

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
