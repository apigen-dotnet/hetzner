using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Interface for Storage Boxes operations
/// </summary>
public partial interface IStorageBoxesClient
{
  /// <summary>
  /// List Storage Boxes
  /// Operation: GET /storage_boxes
  /// </summary>
  Task<JsonElement> ListStorageBoxesAsync(ListStorageBoxesRequest? request = null);

  /// <summary>
  /// Create a Storage Box
  /// Operation: POST /storage_boxes
  /// </summary>
  Task<JsonElement> CreateStorageBoxAsync(Apigen.Hetzner.Api.Models.CreateStorageBoxRequest createStorageBoxRequest);

  /// <summary>
  /// Get a Storage Box
  /// Operation: GET /storage_boxes/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Storage Box
  /// Operation: PUT /storage_boxes/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Api.Models.UpdateStorageBoxRequest updateStorageBoxRequest);

  /// <summary>
  /// Delete a Storage Box
  /// Operation: DELETE /storage_boxes/{id}
  /// </summary>
  Task<JsonElement> DeleteAsync(int id);

  /// <summary>
  /// List folders of a Storage Box
  /// Operation: GET /storage_boxes/{id}/folders
  /// </summary>
  Task<JsonElement> ListStorageBoxFoldersAsync(int id, ListStorageBoxFoldersRequest? request = null);

}
