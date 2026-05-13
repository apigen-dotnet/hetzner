using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Firewalls operations
/// </summary>
public partial interface IFirewallsClient
{
  /// <summary>
  /// List Firewalls
  /// Operation: GET /firewalls
  /// </summary>
  Task<JsonElement> ListFirewallsAsync(ListFirewallsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a Firewall
  /// Operation: POST /firewalls
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateFirewallRequest createFirewallRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Firewall
  /// Operation: GET /firewalls/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a Firewall
  /// Operation: PUT /firewalls/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateFirewallRequest updateFirewallRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a Firewall
  /// Operation: DELETE /firewalls/{id}
  /// </summary>
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);

}
