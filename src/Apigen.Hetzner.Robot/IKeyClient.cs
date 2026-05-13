using System.Text.Json;
using System.Threading;
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
  /// Get all ssh public keys
  /// Operation: GET /key
  /// </summary>
  Task<List<KeyGetAllResponse>> ListAsync(KeyGetAllRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Save a new ssh public key
  /// Operation: POST /key
  /// </summary>
  Task<KeyCreateResponse> CreateAsync(Apigen.Hetzner.Robot.Models.KeyCreateRequest keyCreateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a specific ssh public key
  /// Operation: GET /key/{fingerprint}
  /// </summary>
  Task<KeyGetResponse> GetAsync(string fingerprint, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update the name of a key
  /// Operation: POST /key/{fingerprint}
  /// </summary>
  Task<KeyUpdateResponse> KeyUpdateAsync(string fingerprint, Apigen.Hetzner.Robot.Models.KeyUpdateRequest keyUpdateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove a ssh public key
  /// Operation: DELETE /key/{fingerprint}
  /// </summary>
  Task DeleteAsync(string fingerprint, CancellationToken cancellationToken = default);

}
