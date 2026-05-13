using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for rdns operations
/// </summary>
public partial interface IRdnsClient
{
  /// <summary>
  /// Get rdns entry for ip
  /// Operation: GET /rdns/{ip}
  /// </summary>
  Task<RdnsGetResponse> GetAsync(string ip, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create rdns entry for ip
  /// Operation: PUT /rdns/{ip}
  /// </summary>
  Task<RdnsCreateResponse> UpdateAsync(string ip, Apigen.Hetzner.Robot.Models.RdnsCreateRequest rdnsCreateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update rdns entry for ip
  /// Operation: POST /rdns/{ip}
  /// </summary>
  Task<RdnsUpdateResponse> RdnsUpdateAsync(string ip, Apigen.Hetzner.Robot.Models.RdnsUpdateRequest rdnsUpdateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete rdns entry for ip
  /// Operation: DELETE /rdns/{ip}
  /// </summary>
  Task DeleteAsync(string ip, CancellationToken cancellationToken = default);

}
