using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Zone RRSets operations
/// </summary>
public partial interface IZoneRRSetsClient
{
  /// <summary>
  /// List RRSets
  /// Operation: GET /zones/{id_or_name}/rrsets
  /// </summary>
  Task<JsonElement> ListZoneRrsetsAsync(string idOrName, ListZoneRrsetsRequest? request = null);

  /// <summary>
  /// Create an RRSet
  /// Operation: POST /zones/{id_or_name}/rrsets
  /// </summary>
  Task<JsonElement> CreateZoneRrsetAsync(string idOrName, Apigen.Hetzner.Cloud.Models.CreateZoneRrsetRequest createZoneRrsetRequest);

  /// <summary>
  /// Get an RRSet
  /// Operation: GET /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}
  /// </summary>
  Task<JsonElement> GetAsync(string idOrName, string rrName, string rrType);

  /// <summary>
  /// Update an RRSet
  /// Operation: PUT /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}
  /// </summary>
  Task<JsonElement> UpdateAsync(string idOrName, string rrName, string rrType, Apigen.Hetzner.Cloud.Models.UpdateZoneRrsetRequest updateZoneRrsetRequest);

  /// <summary>
  /// Delete an RRSet
  /// Operation: DELETE /zones/{id_or_name}/rrsets/{rr_name}/{rr_type}
  /// </summary>
  Task<JsonElement> DeleteAsync(string idOrName, string rrName, string rrType);

}
