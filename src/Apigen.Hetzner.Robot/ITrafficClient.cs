using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for traffic operations
/// </summary>
public partial interface ITrafficClient
{
  /// <summary>
  /// Get traffic for single ips and subnets
  /// Operation: POST /traffic
  /// </summary>
  Task<TrafficGetResponse> CreateAsync();

}
