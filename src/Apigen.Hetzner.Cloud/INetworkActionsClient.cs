using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Network Actions operations
/// </summary>
public partial interface INetworkActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /networks/actions
  /// </summary>
  Task<JsonElement> ListNetworksActionsAsync(ListNetworksActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /networks/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Network
  /// Operation: GET /networks/{id}/actions
  /// </summary>
  Task<JsonElement> ListNetworkActionsAsync(int id, ListNetworkActionsRequest? request = null);

  /// <summary>
  /// Add a route to a Network
  /// Operation: POST /networks/{id}/actions/add_route
  /// </summary>
  Task<JsonElement> AddNetworkRouteAsync(int id, Apigen.Hetzner.Cloud.Models.AddNetworkRouteRequest addNetworkRouteRequest);

  /// <summary>
  /// Add a subnet to a Network
  /// Operation: POST /networks/{id}/actions/add_subnet
  /// </summary>
  Task<JsonElement> AddNetworkSubnetAsync(int id, Apigen.Hetzner.Cloud.Models.AddNetworkSubnetRequest addNetworkSubnetRequest);

  /// <summary>
  /// Change IP range of a Network
  /// Operation: POST /networks/{id}/actions/change_ip_range
  /// </summary>
  Task<JsonElement> ChangeNetworkIpRangeAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeNetworkIpRangeRequest changeNetworkIpRangeRequest);

  /// <summary>
  /// Change Network Protection
  /// Operation: POST /networks/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeNetworkProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeNetworkProtectionRequest changeNetworkProtectionRequest);

  /// <summary>
  /// Delete a route from a Network
  /// Operation: POST /networks/{id}/actions/delete_route
  /// </summary>
  Task<JsonElement> DeleteNetworkRouteAsync(int id, Apigen.Hetzner.Cloud.Models.DeleteNetworkRouteRequest deleteNetworkRouteRequest);

  /// <summary>
  /// Delete a subnet from a Network
  /// Operation: POST /networks/{id}/actions/delete_subnet
  /// </summary>
  Task<JsonElement> DeleteNetworkSubnetAsync(int id, Apigen.Hetzner.Cloud.Models.DeleteNetworkSubnetRequest deleteNetworkSubnetRequest);

  /// <summary>
  /// Get an Action for a Network
  /// Operation: GET /networks/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

}
