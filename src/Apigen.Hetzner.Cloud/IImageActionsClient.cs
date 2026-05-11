using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Image Actions operations
/// </summary>
public partial interface IImageActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /images/actions
  /// </summary>
  Task<JsonElement> ListImagesActionsAsync(ListImagesActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /images/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for an Image
  /// Operation: GET /images/{id}/actions
  /// </summary>
  Task<JsonElement> ListImageActionsAsync(int id, ListImageActionsRequest? request = null);

  /// <summary>
  /// Change Image Protection
  /// Operation: POST /images/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeImageProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeImageProtectionRequest changeImageProtectionRequest);

  /// <summary>
  /// Get an Action for an Image
  /// Operation: GET /images/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

}
