using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Networks operations
/// </summary>
public partial interface INetworksClient
{
  /// <summary>
  /// List Networks
  /// Operation: GET /networks
  /// </summary>
  Task<JsonElement> ListNetworksAsync(ListNetworksRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a Network
  /// Operation: POST /networks
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateNetworkRequest createNetworkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Network
  /// Operation: GET /networks/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a Network
  /// Operation: PUT /networks/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateNetworkRequest updateNetworkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a Network
  /// Operation: DELETE /networks/{id}
  /// </summary>
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);

}
