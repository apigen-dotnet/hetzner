using System.Text.Json;
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
  Task<JsonElement> ListServersActionsAsync(ListServersActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /servers/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Server
  /// Operation: GET /servers/{id}/actions
  /// </summary>
  Task<JsonElement> ListServerActionsAsync(int id, ListServerActionsRequest? request = null);

  /// <summary>
  /// Add a Server to a Placement Group
  /// Operation: POST /servers/{id}/actions/add_to_placement_group
  /// </summary>
  Task<JsonElement> AddServerToPlacementGroupAsync(int id, Apigen.Hetzner.Cloud.Models.AddServerToPlacementGroupRequest addServerToPlacementGroupRequest);

  /// <summary>
  /// Attach an ISO to a Server
  /// Operation: POST /servers/{id}/actions/attach_iso
  /// </summary>
  Task<JsonElement> AttachServerIsoAsync(int id, Apigen.Hetzner.Cloud.Models.AttachServerIsoRequest attachServerIsoRequest);

  /// <summary>
  /// Attach a Server to a Network
  /// Operation: POST /servers/{id}/actions/attach_to_network
  /// </summary>
  Task<JsonElement> AttachServerToNetworkAsync(int id, Apigen.Hetzner.Cloud.Models.AttachServerToNetworkRequest attachServerToNetworkRequest);

  /// <summary>
  /// Change alias IPs of a Network
  /// Operation: POST /servers/{id}/actions/change_alias_ips
  /// </summary>
  Task<JsonElement> ChangeServerAliasIpsAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerAliasIpsRequest changeServerAliasIpsRequest);

  /// <summary>
  /// Change reverse DNS entry for this Server
  /// Operation: POST /servers/{id}/actions/change_dns_ptr
  /// </summary>
  Task<JsonElement> ChangeServerDnsPtrAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerDnsPtrRequest changeServerDnsPtrRequest);

  /// <summary>
  /// Change Server Protection
  /// Operation: POST /servers/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeServerProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerProtectionRequest changeServerProtectionRequest);

  /// <summary>
  /// Change the Type of a Server
  /// Operation: POST /servers/{id}/actions/change_type
  /// </summary>
  Task<JsonElement> ChangeServerTypeAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeServerTypeRequest changeServerTypeRequest);

  /// <summary>
  /// Create Image from a Server
  /// Operation: POST /servers/{id}/actions/create_image
  /// </summary>
  Task<JsonElement> CreateServerImageAsync(int id, Apigen.Hetzner.Cloud.Models.CreateServerImageRequest createServerImageRequest);

  /// <summary>
  /// Detach a Server from a Network
  /// Operation: POST /servers/{id}/actions/detach_from_network
  /// </summary>
  Task<JsonElement> DetachServerFromNetworkAsync(int id, Apigen.Hetzner.Cloud.Models.DetachServerFromNetworkRequest detachServerFromNetworkRequest);

  /// <summary>
  /// Detach an ISO from a Server
  /// Operation: POST /servers/{id}/actions/detach_iso
  /// </summary>
  Task<JsonElement> DetachServerIsoAsync(int id);

  /// <summary>
  /// Disable Backups for a Server
  /// Operation: POST /servers/{id}/actions/disable_backup
  /// </summary>
  Task<JsonElement> DisableServerBackupAsync(int id);

  /// <summary>
  /// Disable Rescue Mode for a Server
  /// Operation: POST /servers/{id}/actions/disable_rescue
  /// </summary>
  Task<JsonElement> DisableServerRescueAsync(int id);

  /// <summary>
  /// Enable and Configure Backups for a Server
  /// Operation: POST /servers/{id}/actions/enable_backup
  /// </summary>
  Task<JsonElement> EnableServerBackupAsync(int id);

  /// <summary>
  /// Enable Rescue Mode for a Server
  /// Operation: POST /servers/{id}/actions/enable_rescue
  /// </summary>
  Task<JsonElement> EnableServerRescueAsync(int id, Apigen.Hetzner.Cloud.Models.EnableServerRescueRequest enableServerRescueRequest);

  /// <summary>
  /// Power off a Server
  /// Operation: POST /servers/{id}/actions/poweroff
  /// </summary>
  Task<JsonElement> PoweroffServerAsync(int id);

  /// <summary>
  /// Power on a Server
  /// Operation: POST /servers/{id}/actions/poweron
  /// </summary>
  Task<JsonElement> PoweronServerAsync(int id);

  /// <summary>
  /// Soft-reboot a Server
  /// Operation: POST /servers/{id}/actions/reboot
  /// </summary>
  Task<JsonElement> RebootServerAsync(int id);

  /// <summary>
  /// Rebuild a Server from an Image
  /// Operation: POST /servers/{id}/actions/rebuild
  /// </summary>
  Task<JsonElement> RebuildServerAsync(int id, Apigen.Hetzner.Cloud.Models.RebuildServerRequest rebuildServerRequest);

  /// <summary>
  /// Remove from Placement Group
  /// Operation: POST /servers/{id}/actions/remove_from_placement_group
  /// </summary>
  Task<JsonElement> RemoveServerFromPlacementGroupAsync(int id);

  /// <summary>
  /// Request Console for a Server
  /// Operation: POST /servers/{id}/actions/request_console
  /// </summary>
  Task<JsonElement> RequestServerConsoleAsync(int id);

  /// <summary>
  /// Reset a Server
  /// Operation: POST /servers/{id}/actions/reset
  /// </summary>
  Task<JsonElement> ResetServerAsync(int id);

  /// <summary>
  /// Reset root Password of a Server
  /// Operation: POST /servers/{id}/actions/reset_password
  /// </summary>
  Task<JsonElement> ResetServerPasswordAsync(int id);

  /// <summary>
  /// Shutdown a Server
  /// Operation: POST /servers/{id}/actions/shutdown
  /// </summary>
  Task<JsonElement> ShutdownServerAsync(int id);

  /// <summary>
  /// Get an Action for a Server
  /// Operation: GET /servers/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

}
