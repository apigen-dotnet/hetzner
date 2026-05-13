using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Volume Actions operations
/// </summary>
public partial interface IVolumeActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /volumes/actions
  /// </summary>
  Task<JsonElement> ListVolumesActionsAsync(ListVolumesActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action
  /// Operation: GET /volumes/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// List Actions for a Volume
  /// Operation: GET /volumes/{id}/actions
  /// </summary>
  Task<JsonElement> ListVolumeActionsAsync(int id, ListVolumeActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Attach Volume to a Server
  /// Operation: POST /volumes/{id}/actions/attach
  /// </summary>
  Task<JsonElement> AttachVolumeAsync(int id, Apigen.Hetzner.Cloud.Models.AttachVolumeRequest attachVolumeRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change Volume Protection
  /// Operation: POST /volumes/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeVolumeProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeVolumeProtectionRequest changeVolumeProtectionRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Detach Volume
  /// Operation: POST /volumes/{id}/actions/detach
  /// </summary>
  Task<JsonElement> DetachVolumeAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Resize Volume
  /// Operation: POST /volumes/{id}/actions/resize
  /// </summary>
  Task<JsonElement> ResizeVolumeAsync(int id, Apigen.Hetzner.Cloud.Models.ResizeVolumeRequest resizeVolumeRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action for a Volume
  /// Operation: GET /volumes/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId, CancellationToken cancellationToken = default);

}
