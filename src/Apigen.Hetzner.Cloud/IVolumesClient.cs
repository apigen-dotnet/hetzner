using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Volumes operations
/// </summary>
public partial interface IVolumesClient
{
  /// <summary>
  /// List Volumes
  /// Operation: GET /volumes
  /// </summary>
  Task<JsonElement> ListVolumesAsync(ListVolumesRequest? request = null);

  /// <summary>
  /// Create a Volume
  /// Operation: POST /volumes
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateVolumeRequest createVolumeRequest);

  /// <summary>
  /// Get a Volume
  /// Operation: GET /volumes/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Volume
  /// Operation: PUT /volumes/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateVolumeRequest updateVolumeRequest);

  /// <summary>
  /// Delete a Volume
  /// Operation: DELETE /volumes/{id}
  /// </summary>
  Task DeleteAsync(int id);

}
