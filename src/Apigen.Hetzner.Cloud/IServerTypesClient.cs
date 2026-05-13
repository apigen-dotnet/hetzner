using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Server Types operations
/// </summary>
public partial interface IServerTypesClient
{
  /// <summary>
  /// List Server Types
  /// Operation: GET /server_types
  /// </summary>
  Task<JsonElement> ListServerTypesAsync(ListServerTypesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Server Type
  /// Operation: GET /server_types/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

}
