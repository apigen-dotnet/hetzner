using System.Text.Json;
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
  Task<JsonElement> ListFloatingIpsAsync(ListFloatingIpsRequest? request = null);

  /// <summary>
  /// Create a Floating IP
  /// Operation: POST /floating_ips
  /// </summary>
  Task<JsonElement> CreateFloatingIpAsync(Apigen.Hetzner.Cloud.Models.CreateFloatingIpRequest createFloatingIpRequest);

  /// <summary>
  /// Get a Floating IP
  /// Operation: GET /floating_ips/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Floating IP
  /// Operation: PUT /floating_ips/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateFloatingIpRequest updateFloatingIpRequest);

  /// <summary>
  /// Delete a Floating IP
  /// Operation: DELETE /floating_ips/{id}
  /// </summary>
  Task DeleteAsync(int id);

}
