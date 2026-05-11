using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Zone RRSet Actions operations
/// </summary>
public partial interface IZoneRRSetActionsClient
{
  /// <summary>
  /// Change an RRSet&apos;s Protection
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeZoneRrsetProtectionAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.ChangeZoneRrsetProtectionRequest changeZoneRrsetProtectionRequest);

  /// <summary>
  /// Change an RRSet&apos;s TTL
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/change_ttl
  /// </summary>
  Task<JsonElement> ChangeZoneRrsetTtlAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.ChangeZoneRrsetTtlRequest changeZoneRrsetTtlRequest);

  /// <summary>
  /// Set Records of an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/set_records
  /// </summary>
  Task<JsonElement> SetZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.SetZoneRrsetRecordsRequest setZoneRrsetRecordsRequest);

  /// <summary>
  /// Add Records to an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/add_records
  /// </summary>
  Task<JsonElement> AddZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.AddZoneRrsetRecordsRequest addZoneRrsetRecordsRequest);

  /// <summary>
  /// Remove Records from an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/remove_records
  /// </summary>
  Task<JsonElement> RemoveZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.RemoveZoneRrsetRecordsRequest removeZoneRrsetRecordsRequest);

  /// <summary>
  /// Update Records of an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}/actions/update_records
  /// </summary>
  Task<JsonElement> UpdateZoneRrsetRecordsAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.UpdateZoneRrsetRecordsRequest updateZoneRrsetRecordsRequest);

}
