using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Certificates operations
/// </summary>
public partial interface ICertificatesClient
{
  /// <summary>
  /// List Certificates
  /// Operation: GET /certificates
  /// </summary>
  Task<JsonElement> ListCertificatesAsync(ListCertificatesRequest? request = null);

  /// <summary>
  /// Create a Certificate
  /// Operation: POST /certificates
  /// </summary>
  Task<JsonElement> CreateAsync(Apigen.Hetzner.Cloud.Models.CreateCertificateRequest createCertificateRequest);

  /// <summary>
  /// Get a Certificate
  /// Operation: GET /certificates/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Certificate
  /// Operation: PUT /certificates/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateCertificateRequest updateCertificateRequest);

  /// <summary>
  /// Delete a Certificate
  /// Operation: DELETE /certificates/{id}
  /// </summary>
  Task DeleteAsync(int id);

}
