using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.Hetzner.Api.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public partial class HetznerApiClient
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for Storage Boxes operations
  /// </summary>
  public StorageBoxesClient StorageBoxes { get; }

  /// <summary>
  /// Client for Storage Box Actions operations
  /// </summary>
  public StorageBoxActionsClient StorageBoxActions { get; }

  /// <summary>
  /// Client for Storage Box Subaccounts operations
  /// </summary>
  public StorageBoxSubaccountsClient StorageBoxSubaccounts { get; }

  /// <summary>
  /// Client for Storage Box Subaccount Actions operations
  /// </summary>
  public StorageBoxSubaccountActionsClient StorageBoxSubaccountActions { get; }

  /// <summary>
  /// Client for Storage Box Snapshots operations
  /// </summary>
  public StorageBoxSnapshotsClient StorageBoxSnapshots { get; }

  /// <summary>
  /// Client for Storage Box Types operations
  /// </summary>
  public StorageBoxTypesClient StorageBoxTypes { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public HetznerApiClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    StorageBoxes = new StorageBoxesClient(_httpClient, _logger);
    StorageBoxActions = new StorageBoxActionsClient(_httpClient, _logger);
    StorageBoxSubaccounts = new StorageBoxSubaccountsClient(_httpClient, _logger);
    StorageBoxSubaccountActions = new StorageBoxSubaccountActionsClient(_httpClient, _logger);
    StorageBoxSnapshots = new StorageBoxSnapshotsClient(_httpClient, _logger);
    StorageBoxTypes = new StorageBoxTypesClient(_httpClient, _logger);
  }

  private HetznerApiClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    StorageBoxes = new StorageBoxesClient(_httpClient, _logger);
    StorageBoxActions = new StorageBoxActionsClient(_httpClient, _logger);
    StorageBoxSubaccounts = new StorageBoxSubaccountsClient(_httpClient, _logger);
    StorageBoxSubaccountActions = new StorageBoxSubaccountActionsClient(_httpClient, _logger);
    StorageBoxSnapshots = new StorageBoxSnapshotsClient(_httpClient, _logger);
    StorageBoxTypes = new StorageBoxTypesClient(_httpClient, _logger);
  }

  /// <summary>
  /// Create client with Bearer token authentication
  /// </summary>
  public static HetznerApiClient WithBearer(string bearerToken, string baseUrl = "https://api.hetzner.com/v1", ILogger? logger = null)
  {
    HttpClient httpClient = CreateTokenAuthHttpClient(bearerToken, baseUrl, "Authorization", true);
    return new HetznerApiClient(httpClient, true, logger);
  }

  private static HttpClient CreateTokenAuthHttpClient(string apiToken, string baseUrl, string headerName, bool useBearer)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    if (useBearer)
    {
      client.DefaultRequestHeaders.Add(headerName, $"Bearer {apiToken}");
    }
    else
    {
      client.DefaultRequestHeaders.Add(headerName, apiToken);
    }

    return client;
  }

  private static HttpClient CreateBasicAuthHttpClient(string username, string password, string baseUrl)
  {
    // Ensure baseUrl ends with / for proper Uri combining with relative paths
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    HttpClient client = new() { BaseAddress = new Uri(normalizedBaseUrl) };

    string credentials = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{username}:{password}"));
    client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");

    return client;
  }

  private static HttpClient CreateCookieAuthHttpClient(string token, string cookieName, string baseUrl)
  {
    string normalizedBaseUrl = baseUrl.EndsWith("/") ? baseUrl : baseUrl + "/";
    System.Net.CookieContainer cookies = new();
    cookies.Add(new Uri(normalizedBaseUrl), new System.Net.Cookie(cookieName, token));
    HttpClientHandler handler = new() { CookieContainer = cookies };
    HttpClient client = new(handler) { BaseAddress = new Uri(normalizedBaseUrl) };

    return client;
  }

  /// <summary>
  /// Dispose resources
  /// </summary>
  public void Dispose()
  {
    if (_disposeHttpClient)
    {
      _httpClient?.Dispose();
    }
  }
}
