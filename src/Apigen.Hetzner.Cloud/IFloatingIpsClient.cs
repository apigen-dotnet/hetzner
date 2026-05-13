using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Floating IPs operations
/// </summary>
public partial interface IFloatingIpsClient
{
  /// <summary>
  /// List Floating IPs
  /// Operation: GET /floating_ips
  /// </summary>
  Task<JsonElement> ListFloatingIpsAsync(ListFloatingIpsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a Floating IP
  /// Operation: POST /floating_ips
  /// </summary>
  Task<JsonElement> CreateFloatingIpAsync(Apigen.Hetzner.Cloud.Models.CreateFloatingIpRequest createFloatingIpRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Floating IP
  /// Operation: GET /floating_ips/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a Floating IP
  /// Operation: PUT /floating_ips/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateFloatingIpRequest updateFloatingIpRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a Floating IP
  /// Operation: DELETE /floating_ips/{id}
  /// </summary>
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);

}
