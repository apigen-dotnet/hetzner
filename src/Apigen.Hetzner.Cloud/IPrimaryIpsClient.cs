using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Primary IPs operations
/// </summary>
public partial interface IPrimaryIpsClient
{
  /// <summary>
  /// List Primary IPs
  /// Operation: GET /primary_ips
  /// </summary>
  Task<JsonElement> ListPrimaryIpsAsync(ListPrimaryIpsRequest? request = null);

  /// <summary>
  /// Create a Primary IP
  /// Operation: POST /primary_ips
  /// </summary>
  Task<JsonElement> CreatePrimaryIpAsync(Apigen.Hetzner.Cloud.Models.CreatePrimaryIpRequest createPrimaryIpRequest);

  /// <summary>
  /// Get a Primary IP
  /// Operation: GET /primary_ips/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Primary IP
  /// Operation: PUT /primary_ips/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdatePrimaryIpRequest updatePrimaryIpRequest);

  /// <summary>
  /// Delete a Primary IP
  /// Operation: DELETE /primary_ips/{id}
  /// </summary>
  Task DeleteAsync(int id);

}
