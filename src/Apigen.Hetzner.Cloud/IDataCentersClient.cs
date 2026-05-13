using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Data Centers operations
/// </summary>
public partial interface IDataCentersClient
{
  /// <summary>
  /// List Data Centers
  /// Operation: GET /datacenters
  /// </summary>
  Task<JsonElement> ListDatacentersAsync(ListDatacentersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Data Center
  /// Operation: GET /datacenters/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

}
