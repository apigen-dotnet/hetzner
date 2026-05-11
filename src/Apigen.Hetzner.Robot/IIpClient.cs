using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for ip operations
/// </summary>
public partial interface IIpClient
{
  /// <summary>
  /// Get all single ips of specific server
  /// Operation: GET /ip
  /// </summary>
  Task<List<IpGetByServerIpResponse>> ListAsync(IpGetByServerIpRequest? request = null);

  /// <summary>
  /// Get ip
  /// Operation: GET /ip/{ip}
  /// </summary>
  Task<IpGetResponse> GetAsync(string ip);

  /// <summary>
  /// Set traffic warning limits for single ip
  /// Operation: POST /ip/{ip}
  /// </summary>
  Task<IpSetTrafficWarningLimitsResponse> IpSetTrafficWarningLimitsAsync(string ip, Apigen.Hetzner.Robot.Models.IpSetTrafficWarningLimitsRequest ipSetTrafficWarningLimitsRequest);

  /// <summary>
  /// Get separate mac for a single ip
  /// Operation: GET /ip/{ip}/mac
  /// </summary>
  Task<SeparateMacGetResponse> SeparateMacGetAsync(string ip);

  /// <summary>
  /// Create separate mac for a single ip
  /// Operation: PUT /ip/{ip}/mac
  /// </summary>
  Task<SeparateMacCreateResponse> SeparateMacCreateAsync(string ip);

  /// <summary>
  /// Delete separate mac for a single ip
  /// Operation: DELETE /ip/{ip}/mac
  /// </summary>
  Task<SeparateMacDeleteResponse> SeparateMacDeleteAsync(string ip);

}
