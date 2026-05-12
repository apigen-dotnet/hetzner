using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.Hetzner.Robot.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public partial class HetznerRobotClient : IDisposable
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for failover operations
  /// </summary>
  public FailoverClient Failover { get; }

  /// <summary>
  /// Client for reset operations
  /// </summary>
  public ResetClient Reset { get; }

  /// <summary>
  /// Client for boot operations
  /// </summary>
  public BootClient Boot { get; }

  /// <summary>
  /// Client for wol operations
  /// </summary>
  public WolClient Wol { get; }

  /// <summary>
  /// Client for rdns operations
  /// </summary>
  public RdnsClient Rdns { get; }

  /// <summary>
  /// Client for server operations
  /// </summary>
  public ServerClient Server { get; }

  /// <summary>
  /// Client for ip operations
  /// </summary>
  public IpClient Ip { get; }

  /// <summary>
  /// Client for subnet operations
  /// </summary>
  public SubnetClient Subnet { get; }

  /// <summary>
  /// Client for traffic operations
  /// </summary>
  public TrafficClient Traffic { get; }

  /// <summary>
  /// Client for key operations
  /// </summary>
  public KeyClient Key { get; }

  /// <summary>
  /// Client for order operations
  /// </summary>
  public OrderClient Order { get; }

  /// <summary>
  /// Client for storagebox operations
  /// </summary>
  public StorageboxClient Storagebox { get; }

  /// <summary>
  /// Client for firewall operations
  /// </summary>
  public FirewallClient Firewall { get; }

  /// <summary>
  /// Client for vswitch operations
  /// </summary>
  public VswitchClient Vswitch { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public HetznerRobotClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    Failover = new FailoverClient(_httpClient, _logger);
    Reset = new ResetClient(_httpClient, _logger);
    Boot = new BootClient(_httpClient, _logger);
    Wol = new WolClient(_httpClient, _logger);
    Rdns = new RdnsClient(_httpClient, _logger);
    Server = new ServerClient(_httpClient, _logger);
    Ip = new IpClient(_httpClient, _logger);
    Subnet = new SubnetClient(_httpClient, _logger);
    Traffic = new TrafficClient(_httpClient, _logger);
    Key = new KeyClient(_httpClient, _logger);
    Order = new OrderClient(_httpClient, _logger);
    Storagebox = new StorageboxClient(_httpClient, _logger);
    Firewall = new FirewallClient(_httpClient, _logger);
    Vswitch = new VswitchClient(_httpClient, _logger);
  }

  private HetznerRobotClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    Failover = new FailoverClient(_httpClient, _logger);
    Reset = new ResetClient(_httpClient, _logger);
    Boot = new BootClient(_httpClient, _logger);
    Wol = new WolClient(_httpClient, _logger);
    Rdns = new RdnsClient(_httpClient, _logger);
    Server = new ServerClient(_httpClient, _logger);
    Ip = new IpClient(_httpClient, _logger);
    Subnet = new SubnetClient(_httpClient, _logger);
    Traffic = new TrafficClient(_httpClient, _logger);
    Key = new KeyClient(_httpClient, _logger);
    Order = new OrderClient(_httpClient, _logger);
    Storagebox = new StorageboxClient(_httpClient, _logger);
    Firewall = new FirewallClient(_httpClient, _logger);
    Vswitch = new VswitchClient(_httpClient, _logger);
  }

  /// <summary>
  /// Create client with Basic Authentication
  /// </summary>
  public static HetznerRobotClient WithBasicAuth(string username, string password, string baseUrl = "https://robot-ws.your-server.de", ILogger? logger = null)
  {
    HttpClient httpClient = CreateBasicAuthHttpClient(username, password, baseUrl);
    return new HetznerRobotClient(httpClient, true, logger);
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
