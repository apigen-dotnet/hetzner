using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Interface for Storage Box Actions operations
/// </summary>
public partial interface IStorageBoxActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /storage_boxes/actions
  /// </summary>
  Task<JsonElement> ListStorageBoxesActionsAsync(ListStorageBoxesActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action
  /// Operation: GET /storage_boxes/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// List Actions for a Storage Box
  /// Operation: GET /storage_boxes/{id}/actions
  /// </summary>
  Task<JsonElement> ListStorageBoxActionsAsync(int id, ListStorageBoxActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action for a Storage Box
  /// Operation: GET /storage_boxes/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change Protection
  /// Operation: POST /storage_boxes/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeStorageBoxProtectionAsync(int id, Apigen.Hetzner.Api.Models.ChangeStorageBoxProtectionRequest changeStorageBoxProtectionRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change Type
  /// Operation: POST /storage_boxes/{id}/actions/change_type
  /// </summary>
  Task<JsonElement> ChangeStorageBoxTypeAsync(int id, Apigen.Hetzner.Api.Models.ChangeStorageBoxTypeRequest changeStorageBoxTypeRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Reset Password
  /// Operation: POST /storage_boxes/{id}/actions/reset_password
  /// </summary>
  Task<JsonElement> ResetStorageBoxPasswordAsync(int id, Apigen.Hetzner.Api.Models.ResetStorageBoxPasswordRequest resetStorageBoxPasswordRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update Access Settings
  /// Operation: POST /storage_boxes/{id}/actions/update_access_settings
  /// </summary>
  Task<JsonElement> UpdateStorageBoxAccessSettingsAsync(int id, Apigen.Hetzner.Api.Models.UpdateStorageBoxAccessSettingsRequest updateStorageBoxAccessSettingsRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Rollback Snapshot
  /// Operation: POST /storage_boxes/{id}/actions/rollback_snapshot
  /// </summary>
  Task<JsonElement> RollbackStorageBoxSnapshotAsync(int id, Apigen.Hetzner.Api.Models.RollbackStorageBoxSnapshotRequest rollbackStorageBoxSnapshotRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Disable Snapshot Plan
  /// Operation: POST /storage_boxes/{id}/actions/disable_snapshot_plan
  /// </summary>
  Task<JsonElement> DisableStorageBoxSnapshotPlanAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Enable Snapshot Plan
  /// Operation: POST /storage_boxes/{id}/actions/enable_snapshot_plan
  /// </summary>
  Task<JsonElement> EnableStorageBoxSnapshotPlanAsync(int id, Apigen.Hetzner.Api.Models.EnableStorageBoxSnapshotPlanRequest enableStorageBoxSnapshotPlanRequest, CancellationToken cancellationToken = default);

}
