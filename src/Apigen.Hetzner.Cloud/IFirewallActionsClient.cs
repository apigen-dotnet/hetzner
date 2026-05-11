using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Firewall Actions operations
/// </summary>
public partial interface IFirewallActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /firewalls/actions
  /// </summary>
  Task<JsonElement> ListFirewallsActionsAsync(ListFirewallsActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /firewalls/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Firewall
  /// Operation: GET /firewalls/{id}/actions
  /// </summary>
  Task<JsonElement> ListFirewallActionsAsync(int id, ListFirewallActionsRequest? request = null);

  /// <summary>
  /// Apply to Resources
  /// Operation: POST /firewalls/{id}/actions/apply_to_resources
  /// </summary>
  Task<JsonElement> ApplyFirewallToResourcesAsync(int id, Apigen.Hetzner.Cloud.Models.ApplyFirewallToResourcesRequest applyFirewallToResourcesRequest);

  /// <summary>
  /// Remove from Resources
  /// Operation: POST /firewalls/{id}/actions/remove_from_resources
  /// </summary>
  Task<JsonElement> RemoveFirewallFromResourcesAsync(int id, Apigen.Hetzner.Cloud.Models.RemoveFirewallFromResourcesRequest removeFirewallFromResourcesRequest);

  /// <summary>
  /// Set Rules
  /// Operation: POST /firewalls/{id}/actions/set_rules
  /// </summary>
  Task<JsonElement> SetFirewallRulesAsync(int id, Apigen.Hetzner.Cloud.Models.SetFirewallRulesRequest setFirewallRulesRequest);

  /// <summary>
  /// Get an Action for a Firewall
  /// Operation: GET /firewalls/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

}
