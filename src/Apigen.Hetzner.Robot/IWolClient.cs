using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for wol operations
/// </summary>
public partial interface IWolClient
{
  /// <summary>
  /// Get Wake On Lan data
  /// Operation: GET /wol/{server_number}
  /// </summary>
  Task<WolGetResponse> GetAsync(string serverNumber);

  /// <summary>
  /// Send Wake On Lan packet to server
  /// Operation: POST /wol/{server_number}
  /// </summary>
  Task<WolSendResponse> WolSendAsync(string serverNumber);

}
