using System.Text.Json;
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
  Task<JsonElement> ListZonesAsync(ListZonesRequest? request = null);

  /// <summary>
  /// Create a Zone
  /// Operation: POST /zones
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateZoneRequest createZoneRequest);

  /// <summary>
  /// Get a Zone
  /// Operation: GET /zones/{id_or_name}
  /// </summary>
  Task<JsonElement> GetAsync(string idOrName);

  /// <summary>
  /// Update a Zone
  /// Operation: PUT /zones/{id_or_name}
  /// </summary>
  Task<JsonElement> UpdateAsync(string idOrName, Apigen.Hetzner.Cloud.Models.UpdateZoneRequest updateZoneRequest);

  /// <summary>
  /// Delete a Zone
  /// Operation: DELETE /zones/{id_or_name}
  /// </summary>
  Task<JsonElement> DeleteAsync(string idOrName);

  /// <summary>
  /// Export a Zone file
  /// Operation: GET /zones/{id_or_name}/zonefile
  /// </summary>
  Task<JsonElement> GetZoneZonefileAsync(string idOrName);

}
