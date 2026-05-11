using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Interface for Storage Box Types operations
/// </summary>
public partial interface IStorageBoxTypesClient
{
  /// <summary>
  /// List Storage Box Types
  /// Operation: GET /storage_box_types
  /// </summary>
  Task<JsonElement> ListStorageBoxTypesAsync(ListStorageBoxTypesRequest? request = null);

  /// <summary>
  /// Get a Storage Box Type
  /// Operation: GET /storage_box_types/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

}
