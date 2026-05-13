using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for storagebox operations
/// </summary>
public partial interface IStorageboxClient
{
  /// <summary>
  /// Get all snapshots from a Storage Box
  /// Operation: GET /storagebox/{id}/snapshot
  /// </summary>
  Task<List<StorageboxSnapshotGetResponse>> StorageboxSnapshotGetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Creates a new snapshot from a Storage Box
  /// Operation: POST /storagebox/{id}/snapshot
  /// </summary>
  Task<StorageboxSnapshotCreateResponse> StorageboxSnapshotCreateAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a snapshot from a Storage Box
  /// Operation: DELETE /storagebox/{id}/snapshot/{name}
  /// </summary>
  Task DeleteAsync(int id, string name, CancellationToken cancellationToken = default);

  /// <summary>
  /// Reverts a snapshot from a Storage Box
  /// Operation: POST /storagebox/{id}/snapshot/{name}
  /// </summary>
  Task<JsonElement> StorageboxSnapshotRevertAsync(int id, string name, CancellationToken cancellationToken = default);

  /// <summary>
  /// Set comment for a snapshot
  /// Operation: POST /storagebox/{id}/snapshot/{name}/comment
  /// </summary>
  Task<JsonElement> StorageboxSnapshotSetCommentAsync(int id, string name, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get Storage Box by id
  /// Operation: GET /storagebox/{id}
  /// </summary>
  Task<StorageboxGetResponse> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a Storage Box
  /// Operation: POST /storagebox/{id}
  /// </summary>
  Task<StorageboxUpdateResponse> StorageboxUpdateAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all Storage Boxes
  /// Operation: GET /storagebox
  /// </summary>
  Task<List<StorageboxGetAllResponse>> ListAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get directory listing of a StorageBox
  /// Operation: GET /storagebox/{id}/dir
  /// </summary>
  Task<JsonElement> StorageboxDirectoryListingAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all snapshot plans for a Storage Box
  /// Operation: GET /storagebox/{id}/snapshotplan
  /// </summary>
  Task<List<StorageboxSnapshotPlanGetResponse>> StorageboxSnapshotPlanGetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Creates a new snapshot plan for a Storage Box
  /// Operation: POST /storagebox/{id}/snapshotplan
  /// </summary>
  Task<List<StorageboxSnapshotPlanEditResponse>> StorageboxSnapshotPlanEditAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get all sub accounts for a Storage Box
  /// Operation: GET /storagebox/{id}/subaccount
  /// </summary>
  Task<List<StorageboxSubAccountGetResponse>> StorageboxSubAccountGetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Creates a new sub account for a Storage Box
  /// Operation: POST /storagebox/{id}/subaccount
  /// </summary>
  Task<StorageboxSubAccountCreateResponse> StorageboxSubAccountCreateAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Updates a new sub account for a Storage Box
  /// Operation: PUT /storagebox/{id}/subaccount/{username}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, string username, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deletes a sub account for a Storage Box
  /// Operation: DELETE /storagebox/{id}/subaccount/{username}
  /// </summary>
  Task DeleteStorageboxSubaccountAsync(int id, string username, CancellationToken cancellationToken = default);

  /// <summary>
  /// Resets the password of a sub account
  /// Operation: POST /storagebox/{id}/subaccount/{username}/password
  /// </summary>
  Task<StorageboxSubAccountResetPasswordResponse> StorageboxSubAccountResetPasswordAsync(int id, string username, CancellationToken cancellationToken = default);

}
