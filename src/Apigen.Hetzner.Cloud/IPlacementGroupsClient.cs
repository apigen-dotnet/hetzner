using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Placement Groups operations
/// </summary>
public partial interface IPlacementGroupsClient
{
  /// <summary>
  /// List Placement Groups
  /// Operation: GET /placement_groups
  /// </summary>
  Task<JsonElement> ListPlacementGroupsAsync(ListPlacementGroupsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a PlacementGroup
  /// Operation: POST /placement_groups
  /// </summary>
  Task<JsonElement> CreatePlacementGroupAsync(Apigen.Hetzner.Cloud.Models.CreatePlacementGroupRequest createPlacementGroupRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a PlacementGroup
  /// Operation: GET /placement_groups/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a PlacementGroup
  /// Operation: PUT /placement_groups/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdatePlacementGroupRequest updatePlacementGroupRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a PlacementGroup
  /// Operation: DELETE /placement_groups/{id}
  /// </summary>
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);

}
