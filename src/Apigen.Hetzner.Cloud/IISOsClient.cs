using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for ISOs operations
/// </summary>
public partial interface IISOsClient
{
  /// <summary>
  /// List ISOs
  /// Operation: GET /isos
  /// </summary>
  Task<JsonElement> ListIsosAsync(ListIsosRequest? request = null);

  /// <summary>
  /// Get an ISO
  /// Operation: GET /isos/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

}
