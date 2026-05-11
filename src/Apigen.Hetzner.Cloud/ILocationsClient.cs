using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Locations operations
/// </summary>
public partial interface ILocationsClient
{
  /// <summary>
  /// List Locations
  /// Operation: GET /locations
  /// </summary>
  Task<JsonElement> ListLocationsAsync(ListLocationsRequest? request = null);

  /// <summary>
  /// Get a Location
  /// Operation: GET /locations/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

}
