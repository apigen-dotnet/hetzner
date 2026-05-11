using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Apigen.Hetzner.Cloud.Models;
using Microsoft.Extensions.Logging;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Main API client for accessing all resources
/// </summary>
public partial class HetznerCloudClient
{
  private readonly HttpClient _httpClient;
  private readonly bool _disposeHttpClient;
  private readonly ILogger? _logger;

  /// <summary>
  /// Client for Actions operations
  /// </summary>
  public ActionsClient Actions { get; }

  /// <summary>
  /// Client for Certificates operations
  /// </summary>
  public CertificatesClient Certificates { get; }

  /// <summary>
  /// Client for Certificate Actions operations
  /// </summary>
  public CertificateActionsClient CertificateActions { get; }

  /// <summary>
  /// Client for Data Centers operations
  /// </summary>
  public DataCentersClient DataCenters { get; }

  /// <summary>
  /// Client for Firewalls operations
  /// </summary>
  public FirewallsClient Firewalls { get; }

  /// <summary>
  /// Client for Firewall Actions operations
  /// </summary>
  public FirewallActionsClient FirewallActions { get; }

  /// <summary>
  /// Client for Floating IPs operations
  /// </summary>
  public FloatingIpsClient FloatingIps { get; }

  /// <summary>
  /// Client for Floating IP Actions operations
  /// </summary>
  public FloatingIpActionsClient FloatingIpActions { get; }

  /// <summary>
  /// Client for Images operations
  /// </summary>
  public ImagesClient Images { get; }

  /// <summary>
  /// Client for Image Actions operations
  /// </summary>
  public ImageActionsClient ImageActions { get; }

  /// <summary>
  /// Client for ISOs operations
  /// </summary>
  public ISOsClient ISOs { get; }

  /// <summary>
  /// Client for Load Balancer Types operations
  /// </summary>
  public LoadBalancerTypesClient LoadBalancerTypes { get; }

  /// <summary>
  /// Client for Load Balancers operations
  /// </summary>
  public LoadBalancersClient LoadBalancers { get; }

  /// <summary>
  /// Client for Load Balancer Actions operations
  /// </summary>
  public LoadBalancerActionsClient LoadBalancerActions { get; }

  /// <summary>
  /// Client for Locations operations
  /// </summary>
  public LocationsClient Locations { get; }

  /// <summary>
  /// Client for Networks operations
  /// </summary>
  public NetworksClient Networks { get; }

  /// <summary>
  /// Client for Network Actions operations
  /// </summary>
  public NetworkActionsClient NetworkActions { get; }

  /// <summary>
  /// Client for Placement Groups operations
  /// </summary>
  public PlacementGroupsClient PlacementGroups { get; }

  /// <summary>
  /// Client for Pricing operations
  /// </summary>
  public PricingClient Pricing { get; }

  /// <summary>
  /// Client for Primary IPs operations
  /// </summary>
  public PrimaryIpsClient PrimaryIps { get; }

  /// <summary>
  /// Client for Primary IP Actions operations
  /// </summary>
  public PrimaryIpActionsClient PrimaryIpActions { get; }

  /// <summary>
  /// Client for Server Types operations
  /// </summary>
  public ServerTypesClient ServerTypes { get; }

  /// <summary>
  /// Client for Servers operations
  /// </summary>
  public ServersClient Servers { get; }

  /// <summary>
  /// Client for Server Actions operations
  /// </summary>
  public ServerActionsClient ServerActions { get; }

  /// <summary>
  /// Client for SSH Keys operations
  /// </summary>
  public SshKeysClient SshKeys { get; }

  /// <summary>
  /// Client for Volumes operations
  /// </summary>
  public VolumesClient Volumes { get; }

  /// <summary>
  /// Client for Volume Actions operations
  /// </summary>
  public VolumeActionsClient VolumeActions { get; }

  /// <summary>
  /// Client for Zones operations
  /// </summary>
  public ZonesClient Zones { get; }

  /// <summary>
  /// Client for Zone Actions operations
  /// </summary>
  public ZoneActionsClient ZoneActions { get; }

  /// <summary>
  /// Client for Zone RRSets operations
  /// </summary>
  public ZoneRRSetsClient ZoneRRSets { get; }

  /// <summary>
  /// Client for Zone RRSet Actions operations
  /// </summary>
  public ZoneRRSetActionsClient ZoneRRSetActions { get; }

  /// <summary>
  /// Initialize client with a pre-configured HttpClient
  /// </summary>
  /// <param name="httpClient">Pre-configured HttpClient with base address, auth headers, etc.</param>
  /// <param name="logger">Optional logger for request/response logging</param>
  public HetznerCloudClient(HttpClient httpClient, ILogger? logger = null)
  {
    _httpClient = httpClient;
    _disposeHttpClient = false;
    _logger = logger;

    Actions = new ActionsClient(_httpClient, _logger);
    Certificates = new CertificatesClient(_httpClient, _logger);
    CertificateActions = new CertificateActionsClient(_httpClient, _logger);
    DataCenters = new DataCentersClient(_httpClient, _logger);
    Firewalls = new FirewallsClient(_httpClient, _logger);
    FirewallActions = new FirewallActionsClient(_httpClient, _logger);
    FloatingIps = new FloatingIpsClient(_httpClient, _logger);
    FloatingIpActions = new FloatingIpActionsClient(_httpClient, _logger);
    Images = new ImagesClient(_httpClient, _logger);
    ImageActions = new ImageActionsClient(_httpClient, _logger);
    ISOs = new ISOsClient(_httpClient, _logger);
    LoadBalancerTypes = new LoadBalancerTypesClient(_httpClient, _logger);
    LoadBalancers = new LoadBalancersClient(_httpClient, _logger);
    LoadBalancerActions = new LoadBalancerActionsClient(_httpClient, _logger);
    Locations = new LocationsClient(_httpClient, _logger);
    Networks = new NetworksClient(_httpClient, _logger);
    NetworkActions = new NetworkActionsClient(_httpClient, _logger);
    PlacementGroups = new PlacementGroupsClient(_httpClient, _logger);
    Pricing = new PricingClient(_httpClient, _logger);
    PrimaryIps = new PrimaryIpsClient(_httpClient, _logger);
    PrimaryIpActions = new PrimaryIpActionsClient(_httpClient, _logger);
    ServerTypes = new ServerTypesClient(_httpClient, _logger);
    Servers = new ServersClient(_httpClient, _logger);
    ServerActions = new ServerActionsClient(_httpClient, _logger);
    SshKeys = new SshKeysClient(_httpClient, _logger);
    Volumes = new VolumesClient(_httpClient, _logger);
    VolumeActions = new VolumeActionsClient(_httpClient, _logger);
    Zones = new ZonesClient(_httpClient, _logger);
    ZoneActions = new ZoneActionsClient(_httpClient, _logger);
    ZoneRRSets = new ZoneRRSetsClient(_httpClient, _logger);
    ZoneRRSetActions = new ZoneRRSetActionsClient(_httpClient, _logger);
  }

  private HetznerCloudClient(HttpClient httpClient, bool disposeHttpClient, ILogger? logger)
  {
    _httpClient = httpClient;
    _disposeHttpClient = disposeHttpClient;
    _logger = logger;

    Actions = new ActionsClient(_httpClient, _logger);
    Certificates = new CertificatesClient(_httpClient, _logger);
    CertificateActions = new CertificateActionsClient(_httpClient, _logger);
    DataCenters = new DataCentersClient(_httpClient, _logger);
    Firewalls = new FirewallsClient(_httpClient, _logger);
    FirewallActions = new FirewallActionsClient(_httpClient, _logger);
    FloatingIps = new FloatingIpsClient(_httpClient, _logger);
    FloatingIpActions = new FloatingIpActionsClient(_httpClient, _logger);
    Images = new ImagesClient(_httpClient, _logger);
    ImageActions = new ImageActionsClient(_httpClient, _logger);
    ISOs = new ISOsClient(_httpClient, _logger);
    LoadBalancerTypes = new LoadBalancerTypesClient(_httpClient, _logger);
    LoadBalancers = new LoadBalancersClient(_httpClient, _logger);
    LoadBalancerActions = new LoadBalancerActionsClient(_httpClient, _logger);
    Locations = new LocationsClient(_httpClient, _logger);
    Networks = new NetworksClient(_httpClient, _logger);
    NetworkActions = new NetworkActionsClient(_httpClient, _logger);
    PlacementGroups = new PlacementGroupsClient(_httpClient, _logger);
    Pricing = new PricingClient(_httpClient, _logger);
    PrimaryIps = new PrimaryIpsClient(_httpClient, _logger);
    PrimaryIpActions = new PrimaryIpActionsClient(_httpClient, _logger);
    ServerTypes = new ServerTypesClient(_httpClient, _logger);
    Servers = new ServersClient(_httpClient, _logger);
    ServerActions = new ServerActionsClient(_httpClient, _logger);
    SshKeys = new SshKeysClient(_httpClient, _logger);
    Volumes = new VolumesClient(_httpClient, _logger);
    VolumeActions = new VolumeActionsClient(_httpClient, _logger);
    Zones = new ZonesClient(_httpClient, _logger);
    ZoneActions = new ZoneActionsClient(_httpClient, _logger);
    ZoneRRSets = new ZoneRRSetsClient(_httpClient, _logger);
    ZoneRRSetActions = new ZoneRRSetActionsClient(_httpClient, _logger);
  }

  /// <summary>
  /// Create client with Bearer token authentication
  /// </summary>
  public static HetznerCloudClient WithBearer(string bearerToken, string baseUrl = "https://api.hetzner.cloud/v1", ILogger? logger = null)
  {
    HttpClient httpClient = CreateTokenAuthHttpClient(bearerToken, baseUrl, "Authorization", true);
    return new HetznerCloudClient(httpClient, true, logger);
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
