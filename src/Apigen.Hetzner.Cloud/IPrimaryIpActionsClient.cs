using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Primary IP Actions operations
/// </summary>
public partial interface IPrimaryIpActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /primary_ips/actions
  /// </summary>
  Task<JsonElement> ListPrimaryIpsActionsAsync(ListPrimaryIpsActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /primary_ips/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Primary IP
  /// Operation: GET /primary_ips/{id}/actions
  /// </summary>
  Task<JsonElement> ListPrimaryIpActionsAsync(int id, ListPrimaryIpActionsRequest? request = null);

  /// <summary>
  /// Get an Action for a Primary IP
  /// Operation: GET /primary_ips/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

  /// <summary>
  /// Assign a Primary IP to a resource
  /// Operation: POST /primary_ips/{id}/actions/assign
  /// </summary>
  Task<JsonElement> AssignPrimaryIpAsync(int id, Apigen.Hetzner.Cloud.Models.AssignPrimaryIpRequest assignPrimaryIpRequest);

  /// <summary>
  /// Change reverse DNS records for a Primary IP
  /// Operation: POST /primary_ips/{id}/actions/change_dns_ptr
  /// </summary>
  Task<JsonElement> ChangePrimaryIpDnsPtrAsync(int id, Apigen.Hetzner.Cloud.Models.ChangePrimaryIpDnsPtrRequest changePrimaryIpDnsPtrRequest);

  /// <summary>
  /// Change Primary IP Protection
  /// Operation: POST /primary_ips/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangePrimaryIpProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangePrimaryIpProtectionRequest changePrimaryIpProtectionRequest);

  /// <summary>
  /// Unassign a Primary IP from a resource
  /// Operation: POST /primary_ips/{id}/actions/unassign
  /// </summary>
  Task<JsonElement> UnassignPrimaryIpAsync(int id);

}
