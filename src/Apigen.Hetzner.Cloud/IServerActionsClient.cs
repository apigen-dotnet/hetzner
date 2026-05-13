using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Server Actions operations
/// </summary>
public partial interface IServerActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /servers/actions
  /// </summary>
  Task<JsonElement> ListServersActionsAsync(ListServersActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action
  /// Operation: GET /servers/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// List Actions for a Server
  /// Operation: GET /servers/{id}/actions
  /// </summary>
  Task<JsonElement> ListServerActionsAsync(int id, ListServerActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add a Server to a Placement Group
  /// Operation: POST /servers/{id}/actions/add_to_placement_group
  /// </summary>
  Task<JsonElement> AddServerToPlacementGroupAsync(int id, Apigen.Hetzner.Cloud.Models.AddServerToPlacementGroupRequest addServerToPlacementGroupRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Attach an ISO to a Server
  /// Operation: POST /servers/{id}/actions/attach_iso
  /// </summary>
  Task<JsonElement> AttachServerIsoAsync(int id, Apigen.Hetzner.Cloud.Models.AttachServerIsoRequest attachServerIsoRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Attach a Server to a Network
  /// Operation: POST /servers/{id}/actions/attach_to_network
  /// </summary>
  Task<JsonElement> AttachServerToNetworkAsync(int id, Apigen.Hetzner.Cloud.Models.AttachServerToNetworkRequest attachServerToNetworkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change alias IPs of a Network
  /// Operation: POST /servers/{id}/actions/change_alias_ips
  /// </summary>
  Task<JsonElement> ChangeServerAliasIpsAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerAliasIpsRequest changeServerAliasIpsRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change reverse DNS entry for this Server
  /// Operation: POST /servers/{id}/actions/change_dns_ptr
  /// </summary>
  Task<JsonElement> ChangeServerDnsPtrAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerDnsPtrRequest changeServerDnsPtrRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change Server Protection
  /// Operation: POST /servers/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeServerProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerProtectionRequest changeServerProtectionRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Change the Type of a Server
  /// Operation: POST /servers/{id}/actions/change_type
  /// </summary>
  Task<JsonElement> ChangeServerTypeAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerTypeRequest changeServerTypeRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create Image from a Server
  /// Operation: POST /servers/{id}/actions/create_image
  /// </summary>
  Task<JsonElement> CreateServerImageAsync(int id, Apigen.Hetzner.Cloud.Models.CreateServerImageRequest createServerImageRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Detach a Server from a Network
  /// Operation: POST /servers/{id}/actions/detach_from_network
  /// </summary>
  Task<JsonElement> DetachServerFromNetworkAsync(int id, Apigen.Hetzner.Cloud.Models.DetachServerFromNetworkRequest detachServerFromNetworkRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Detach an ISO from a Server
  /// Operation: POST /servers/{id}/actions/detach_iso
  /// </summary>
  Task<JsonElement> DetachServerIsoAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Disable Backups for a Server
  /// Operation: POST /servers/{id}/actions/disable_backup
  /// </summary>
  Task<JsonElement> DisableServerBackupAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Disable Rescue Mode for a Server
  /// Operation: POST /servers/{id}/actions/disable_rescue
  /// </summary>
  Task<JsonElement> DisableServerRescueAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Enable and Configure Backups for a Server
  /// Operation: POST /servers/{id}/actions/enable_backup
  /// </summary>
  Task<JsonElement> EnableServerBackupAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Enable Rescue Mode for a Server
  /// Operation: POST /servers/{id}/actions/enable_rescue
  /// </summary>
  Task<JsonElement> EnableServerRescueAsync(int id, Apigen.Hetzner.Cloud.Models.EnableServerRescueRequest enableServerRescueRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Power off a Server
  /// Operation: POST /servers/{id}/actions/poweroff
  /// </summary>
  Task<JsonElement> PoweroffServerAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Power on a Server
  /// Operation: POST /servers/{id}/actions/poweron
  /// </summary>
  Task<JsonElement> PoweronServerAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Soft-reboot a Server
  /// Operation: POST /servers/{id}/actions/reboot
  /// </summary>
  Task<JsonElement> RebootServerAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Rebuild a Server from an Image
  /// Operation: POST /servers/{id}/actions/rebuild
  /// </summary>
  Task<JsonElement> RebuildServerAsync(int id, Apigen.Hetzner.Cloud.Models.RebuildServerRequest rebuildServerRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove from Placement Group
  /// Operation: POST /servers/{id}/actions/remove_from_placement_group
  /// </summary>
  Task<JsonElement> RemoveServerFromPlacementGroupAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Request Console for a Server
  /// Operation: POST /servers/{id}/actions/request_console
  /// </summary>
  Task<JsonElement> RequestServerConsoleAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Reset a Server
  /// Operation: POST /servers/{id}/actions/reset
  /// </summary>
  Task<JsonElement> ResetServerAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Reset root Password of a Server
  /// Operation: POST /servers/{id}/actions/reset_password
  /// </summary>
  Task<JsonElement> ResetServerPasswordAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Shutdown a Server
  /// Operation: POST /servers/{id}/actions/shutdown
  /// </summary>
  Task<JsonElement> ShutdownServerAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action for a Server
  /// Operation: GET /servers/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId, CancellationToken cancellationToken = default);

}
