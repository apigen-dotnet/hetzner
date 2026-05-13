using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Floating IP Actions operations
/// </summary>
public partial interface IFloatingIpActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /floating_ips/actions
  /// </summary>
  Task<JsonElement> ListFloatingIpsActionsAsync(ListFloatingIpsActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action
  /// Operation: GET /floating_ips/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// List Actions for a Floating IP
  /// Operation: GET /floating_ips/{id}/actions
  /// </summary>
  Task<JsonElement> ListFloatingIpActionsAsync(int id, ListFloatingIpActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Assign a Floating IP to a Server
  /// Operation: POST /floating_ips/{id}/actions/assign
  /// </summary>
  Task<JsonElement> AssignFloatingIpAsync(int id, Apigen.Hetzner.Cloud.Models.AssignFloatingIpRequest assignFloatingIpRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change reverse DNS records for a Floating IP
  /// Operation: POST /floating_ips/{id}/actions/change_dns_ptr
  /// </summary>
  Task<JsonElement> ChangeFloatingIpDnsPtrAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeFloatingIpDnsPtrRequest changeFloatingIpDnsPtrRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change Floating IP Protection
  /// Operation: POST /floating_ips/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeFloatingIpProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeFloatingIpProtectionRequest changeFloatingIpProtectionRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Unassign a Floating IP
  /// Operation: POST /floating_ips/{id}/actions/unassign
  /// </summary>
  Task<JsonElement> UnassignFloatingIpAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action for a Floating IP
  /// Operation: GET /floating_ips/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId, CancellationToken cancellationToken = default);

}
