using System.Text.Json;
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
  Task<JsonElement> ListImagesAsync(ListImagesRequest? request = null);

  /// <summary>
  /// Get an Image
  /// Operation: GET /images/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update an Image
  /// Operation: PUT /images/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateImageRequest updateImageRequest);

  /// <summary>
  /// Delete an Image
  /// Operation: DELETE /images/{id}
  /// </summary>
  Task DeleteAsync(int id);

}
