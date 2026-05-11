using System.Text.Json;
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
  Task<JsonElement> ListVolumesActionsAsync(ListVolumesActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /volumes/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Volume
  /// Operation: GET /volumes/{id}/actions
  /// </summary>
  Task<JsonElement> ListVolumeActionsAsync(int id, ListVolumeActionsRequest? request = null);

  /// <summary>
  /// Attach Volume to a Server
  /// Operation: POST /volumes/{id}/actions/attach
  /// </summary>
  Task<JsonElement> AttachVolumeAsync(int id, Apigen.Hetzner.Cloud.Models.AttachVolumeRequest attachVolumeRequest);

  /// <summary>
  /// Change Volume Protection
  /// Operation: POST /volumes/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeVolumeProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeVolumeProtectionRequest changeVolumeProtectionRequest);

  /// <summary>
  /// Detach Volume
  /// Operation: POST /volumes/{id}/actions/detach
  /// </summary>
  Task<JsonElement> DetachVolumeAsync(int id);

  /// <summary>
  /// Resize Volume
  /// Operation: POST /volumes/{id}/actions/resize
  /// </summary>
  Task<JsonElement> ResizeVolumeAsync(int id, Apigen.Hetzner.Cloud.Models.ResizeVolumeRequest resizeVolumeRequest);

  /// <summary>
  /// Get an Action for a Volume
  /// Operation: GET /volumes/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

}
