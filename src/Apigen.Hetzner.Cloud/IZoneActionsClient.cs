using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Zone Actions operations
/// </summary>
public partial interface IZoneActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /zones/actions
  /// </summary>
  Task<JsonElement> ListZonesActionsAsync(ListZonesActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /zones/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Zone
  /// Operation: GET /zones/{id_or_name}/actions
  /// </summary>
  Task<JsonElement> ListZoneActionsAsync(string idOrName, ListZoneActionsRequest? request = null);

  /// <summary>
  /// Get an Action for a Zone
  /// Operation: GET /zones/{id_or_name}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(string idOrName, int actionId);

  /// <summary>
  /// Change a Zone&apos;s Primary Nameservers
  /// Operation: POST /zones/{id_or_name}/actions/change_primary_nameservers
  /// </summary>
  Task<JsonElement> ChangeZonePrimaryNameserversAsync(string idOrName, Apigen.Hetzner.Cloud.Models.ChangeZonePrimaryNameserversRequest changeZonePrimaryNameserversRequest);

  /// <summary>
  /// Change a Zone&apos;s Protection
  /// Operation: POST /zones/{id_or_name}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeZoneProtectionAsync(string idOrName, Apigen.Hetzner.Cloud.Models.ChangeZoneProtectionRequest changeZoneProtectionRequest);

  /// <summary>
  /// Change a Zone&apos;s Default TTL
  /// Operation: POST /zones/{id_or_name}/actions/change_ttl
  /// </summary>
  Task<JsonElement> ChangeZoneTtlAsync(string idOrName, Apigen.Hetzner.Cloud.Models.ChangeZoneTtlRequest changeZoneTtlRequest);

  /// <summary>
  /// Import a Zone file
  /// Operation: POST /zones/{id_or_name}/actions/import_zonefile
  /// </summary>
  Task<JsonElement> ImportZoneZonefileAsync(string idOrName, Apigen.Hetzner.Cloud.Models.ImportZoneZonefileRequest importZoneZonefileRequest);

}
