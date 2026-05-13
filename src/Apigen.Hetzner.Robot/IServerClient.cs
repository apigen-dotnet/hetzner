using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for server operations
/// </summary>
public partial interface IServerClient
{
  /// <summary>
  /// Get all servers
  /// Operation: GET /server
  /// </summary>
  Task<List<ServerGetAllResponse>> ListAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Get server by main ip
  /// Operation: GET /server/{server_number}
  /// </summary>
  Task<ServerGetResponse> GetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update servername
  /// Operation: POST /server/{server_number}
  /// </summary>
  Task<ServernameUpdateResponse> ServernameUpdateAsync(string serverNumber, Apigen.Hetzner.Robot.Models.ServernameUpdateRequest servernameUpdateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get cancellation data of a server
  /// Operation: GET /server/{server_number}/cancellation
  /// </summary>
  Task<ServerCancellationGetResponse> ServerCancellationGetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Cancel a server
  /// Operation: POST /server/{server_number}/cancellation
  /// </summary>
  Task<ServerCancelResponse> ServerCancelAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Revoke a server cancellation
  /// Operation: DELETE /server/{server_number}/cancellation
  /// </summary>
  Task ServerCancellationDeleteAsync(string serverNumber, CancellationToken cancellationToken = default);

}
