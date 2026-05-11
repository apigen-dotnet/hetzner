using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for failover operations
/// </summary>
public partial interface IFailoverClient
{
  /// <summary>
  /// Get failover
  /// Operation: GET /failover/{ip}
  /// </summary>
  Task<FailoverGetResponse> GetAsync(string ip, FailoverGetRequest? request = null);

  /// <summary>
  /// Route failover
  /// Operation: POST /failover/{ip}
  /// </summary>
  Task<FailoverRouteResponse> FailoverRouteAsync(string ip, Apigen.Hetzner.Robot.Models.FailoverRouteRequest failoverRouteRequest);

  /// <summary>
  /// Delete failover routing
  /// Operation: DELETE /failover/{ip}
  /// </summary>
  Task<FailoverDeleteResponse> DeleteAsync(string ip);

  /// <summary>
  /// Get failover (collection)
  /// Operation: GET /failover
  /// </summary>
  Task<List<FailoverGetAllResponse>> ListAsync(FailoverGetAllRequest? request = null);

}
