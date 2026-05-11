using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Actions operations
/// </summary>
public partial interface IActionsClient
{
  /// <summary>
  /// Get multiple Actions
  /// Operation: GET /actions
  /// </summary>
  Task<JsonElement> GetActionsAsync(GetActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

}
