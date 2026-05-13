using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Zones operations
/// </summary>
public partial interface IZonesClient
{
  /// <summary>
  /// List Zones
  /// Operation: GET /zones
  /// </summary>
  Task<JsonElement> ListZonesAsync(ListZonesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a Zone
  /// Operation: POST /zones
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateZoneRequest createZoneRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Zone
  /// Operation: GET /zones/{id_or_name}
  /// </summary>
  Task<JsonElement> GetAsync(string idOrName, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a Zone
  /// Operation: PUT /zones/{id_or_name}
  /// </summary>
  Task<JsonElement> UpdateAsync(string idOrName, Apigen.Hetzner.Cloud.Models.UpdateZoneRequest updateZoneRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a Zone
  /// Operation: DELETE /zones/{id_or_name}
  /// </summary>
  Task<JsonElement> DeleteAsync(string idOrName, CancellationToken cancellationToken = default);

  /// <summary>
  /// Export a Zone file
  /// Operation: GET /zones/{id_or_name}/zonefile
  /// </summary>
  Task<JsonElement> GetZoneZonefileAsync(string idOrName, CancellationToken cancellationToken = default);

}
