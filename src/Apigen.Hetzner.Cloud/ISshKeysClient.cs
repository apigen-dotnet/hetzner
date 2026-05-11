using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for SSH Keys operations
/// </summary>
public partial interface ISshKeysClient
{
  /// <summary>
  /// List SSH keys
  /// Operation: GET /ssh_keys
  /// </summary>
  Task<JsonElement> ListSshKeysAsync(ListSshKeysRequest? request = null);

  /// <summary>
  /// Create an SSH key
  /// Operation: POST /ssh_keys
  /// </summary>
  Task<JsonElement> CreateSshKeyAsync(Apigen.Hetzner.Cloud.Models.CreateSshKeyRequest createSshKeyRequest);

  /// <summary>
  /// Get a SSH key
  /// Operation: GET /ssh_keys/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update an SSH key
  /// Operation: PUT /ssh_keys/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateSshKeyRequest updateSshKeyRequest);

  /// <summary>
  /// Delete an SSH key
  /// Operation: DELETE /ssh_keys/{id}
  /// </summary>
  Task DeleteAsync(int id);

}
