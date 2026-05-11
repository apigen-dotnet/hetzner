using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for reset operations
/// </summary>
public partial interface IResetClient
{
  /// <summary>
  /// Get server reset
  /// Operation: GET /reset/{server_number}
  /// </summary>
  Task<ResetGetResponse> GetAsync(string serverNumber);

  /// <summary>
  /// Execute server reset
  /// Operation: POST /reset/{server_number}
  /// </summary>
  Task<ResetExecuteResponse> ResetExecuteAsync(string serverNumber, Apigen.Hetzner.Robot.Models.ResetExecuteRequest resetExecuteRequest);

  /// <summary>
  /// Get server reset (collection)
  /// Operation: GET /reset
  /// </summary>
  Task<List<ResetGetAllResponse>> ListAsync();

}
