using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for key operations
/// </summary>
public partial interface IKeyClient
{
  /// <summary>
  /// Get a specific ssh public key
  /// Operation: GET /key/{fingerprint}
  /// </summary>
  Task<KeyGetResponse> GetAsync(string fingerprint);

  /// <summary>
  /// Update the name of a key
  /// Operation: POST /key/{fingerprint}
  /// </summary>
  Task<KeyUpdateResponse> KeyUpdateAsync(string fingerprint, Apigen.Hetzner.Robot.Models.KeyUpdateRequest keyUpdateRequest);

  /// <summary>
  /// Remove a ssh public key
  /// Operation: DELETE /key/{fingerprint}
  /// </summary>
  Task DeleteAsync(string fingerprint);

  /// <summary>
  /// Save a new ssh public key
  /// Operation: POST /key
  /// </summary>
  Task<KeyCreateResponse> CreateAsync(Apigen.Hetzner.Robot.Models.KeyCreateRequest keyCreateRequest);

}
