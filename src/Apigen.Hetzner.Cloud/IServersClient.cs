using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Servers operations
/// </summary>
public partial interface IServersClient
{
  /// <summary>
  /// List Servers
  /// Operation: GET /servers
  /// </summary>
  Task<JsonElement> ListServersAsync(ListServersRequest? request = null);

  /// <summary>
  /// Create a Server
  /// Operation: POST /servers
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateServerRequest createServerRequest);

  /// <summary>
  /// Get a Server
  /// Operation: GET /servers/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Server
  /// Operation: PUT /servers/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateServerRequest updateServerRequest);

  /// <summary>
  /// Delete a Server
  /// Operation: DELETE /servers/{id}
  /// </summary>
  Task<JsonElement> DeleteAsync(int id);

  /// <summary>
  /// Get Metrics for a Server
  /// Operation: GET /servers/{id}/metrics
  /// </summary>
  Task<JsonElement> GetServerMetricsAsync(int id, GetServerMetricsRequest? request = null);

}
