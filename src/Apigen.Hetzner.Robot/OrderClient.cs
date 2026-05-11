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
/// Client for order operations
/// </summary>
public partial class OrderClient
{
  private readonly HttpClient _httpClient;
  private readonly ILogger? _logger;

  internal OrderClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _logger = logger;
  }

  /// <summary>
  /// Get all currently offered standard server products
  /// Operation: GET /order/server/product
  /// </summary>
  public async Task<List<OrderServerProductGetAllResponse>> OrderServerProductGetAllAsync()
  {
    string url = "order/server/product";

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
    List<OrderServerProductGetAllResponse>? result = JsonSerializer.Deserialize<List<OrderServerProductGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrderServerProductGetAllResponse>();
  }


  /// <summary>
  /// Get data of a specific standard server product
  /// Operation: GET /order/server/product/{product_id}
  /// </summary>
  public async Task<OrderServerProductGetResponse> GetAsync(string productId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["product_id"] = productId
    };
    string url = "order/server/product/{product_id}".BuildUrl(pathParams);

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
    OrderServerProductGetResponse? result = JsonSerializer.Deserialize<OrderServerProductGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new OrderServerProductGetResponse();
  }


  /// <summary>
  /// Get all standard server orders of the last 30 days
  /// Operation: GET /order/server/transaction
  /// </summary>
  public async Task<List<OrderServerTransactionGetAllResponse>> OrderServerTransactionGetAllAsync()
  {
    string url = "order/server/transaction";

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
    List<OrderServerTransactionGetAllResponse>? result = JsonSerializer.Deserialize<List<OrderServerTransactionGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrderServerTransactionGetAllResponse>();
  }


  /// <summary>
  /// Query the status of a specific server order
  /// Operation: GET /order/server/transaction/{transaction_id}
  /// </summary>
  public async Task<OrderServerTransactionGetResponse> GetOrderServerTransactionAsync(string transactionId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["transaction_id"] = transactionId
    };
    string url = "order/server/transaction/{transaction_id}".BuildUrl(pathParams);

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
    OrderServerTransactionGetResponse? result = JsonSerializer.Deserialize<OrderServerTransactionGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new OrderServerTransactionGetResponse();
  }


  /// <summary>
  /// Get all currently offered server market products
  /// Operation: GET /order/server_market/product
  /// </summary>
  public async Task<List<OrderServerMarketProductGetAllResponse>> OrderServerMarketProductGetAllAsync()
  {
    string url = "order/server_market/product";

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
    List<OrderServerMarketProductGetAllResponse>? result = JsonSerializer.Deserialize<List<OrderServerMarketProductGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrderServerMarketProductGetAllResponse>();
  }


  /// <summary>
  /// Get data of a specifi server market product
  /// Operation: GET /order/server_market/product/{product_id}
  /// </summary>
  public async Task<OrderServerMarketProductGetResponse> GetAsync(int productId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["product_id"] = productId
    };
    string url = "order/server_market/product/{product_id}".BuildUrl(pathParams);

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
    OrderServerMarketProductGetResponse? result = JsonSerializer.Deserialize<OrderServerMarketProductGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new OrderServerMarketProductGetResponse();
  }


  /// <summary>
  /// Get all server market orders of the last 30 days
  /// Operation: GET /order/server_market/transaction
  /// </summary>
  public async Task<List<OrderServerMarketTransactionGetAllResponse>> OrderServerMarketTransactionGetAllAsync()
  {
    string url = "order/server_market/transaction";

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
    List<OrderServerMarketTransactionGetAllResponse>? result = JsonSerializer.Deserialize<List<OrderServerMarketTransactionGetAllResponse>>(responseContent, JsonConfig.Default);
    return result ?? new List<OrderServerMarketTransactionGetAllResponse>();
  }


  /// <summary>
  /// Query the status of a specific server market order
  /// Operation: GET /order/server_market/transaction/{transaction_id}
  /// </summary>
  public async Task<OrderServerMarketTransactionGetResponse> GetOrderServerMarketTransactionAsync(int transactionId)
  {
    Dictionary<string, object> pathParams = new()
    {
      ["transaction_id"] = transactionId
    };
    string url = "order/server_market/transaction/{transaction_id}".BuildUrl(pathParams);

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
    OrderServerMarketTransactionGetResponse? result = JsonSerializer.Deserialize<OrderServerMarketTransactionGetResponse>(responseContent, JsonConfig.Default);
    return result ?? new OrderServerMarketTransactionGetResponse();
  }


}
