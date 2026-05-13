using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Images operations
/// </summary>
public partial interface IImagesClient
{
  /// <summary>
  /// List Images
  /// Operation: GET /images
  /// </summary>
  Task<JsonElement> ListImagesAsync(ListImagesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Image
  /// Operation: GET /images/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update an Image
  /// Operation: PUT /images/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateImageRequest updateImageRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete an Image
  /// Operation: DELETE /images/{id}
  /// </summary>
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);

}
