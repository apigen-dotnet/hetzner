using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Interface for Storage Box Snapshots operations
/// </summary>
public partial interface IStorageBoxSnapshotsClient
{
  /// <summary>
  /// List Snapshots
  /// Operation: GET /storage_boxes/{id}/snapshots
  /// </summary>
  Task<JsonElement> ListStorageBoxSnapshotsAsync(int id, ListStorageBoxSnapshotsRequest? request = null);

  /// <summary>
  /// Create a Snapshot
  /// Operation: POST /storage_boxes/{id}/snapshots
  /// </summary>
  Task<JsonElement> CreateStorageBoxSnapshotAsync(int id, Apigen.Hetzner.Api.Models.CreateStorageBoxSnapshotRequest createStorageBoxSnapshotRequest);

  /// <summary>
  /// Get a Snapshot
  /// Operation: GET /storage_boxes/{id}/snapshots/{snapshot_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int snapshotId);

  /// <summary>
  /// Update a Snapshot
  /// Operation: PUT /storage_boxes/{id}/snapshots/{snapshot_id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, int snapshotId, Apigen.Hetzner.Api.Models.UpdateStorageBoxSnapshotRequest updateStorageBoxSnapshotRequest);

  /// <summary>
  /// Delete a Snapshot
  /// Operation: DELETE /storage_boxes/{id}/snapshots/{snapshot_id}
  /// </summary>
  Task<JsonElement> DeleteAsync(int id, int snapshotId);

}
