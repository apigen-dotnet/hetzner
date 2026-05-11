using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for subnet operations
/// </summary>
public partial interface ISubnetClient
{
  /// <summary>
  /// Get all subnets of specific server
  /// Operation: GET /subnet
  /// </summary>
  Task<List<SubnetGetByServerIpResponse>> ListAsync(SubnetGetByServerIpRequest? request = null);

  /// <summary>
  /// Get subnet
  /// Operation: GET /subnet/{ip}
  /// </summary>
  Task<SubnetGetResponse> GetAsync(string ip);

  /// <summary>
  /// Set traffic warning limits for subnet
  /// Operation: POST /subnet/{ip}
  /// </summary>
  Task<SubnetSetTrafficWarningLimitsResponse> SubnetSetTrafficWarningLimitsAsync(string ip, Apigen.Hetzner.Robot.Models.SubnetSetTrafficWarningLimitsRequest subnetSetTrafficWarningLimitsRequest);

  /// <summary>
  /// Get the mac address of a ipv6 subnet
  /// Operation: GET /subnet/{ip}/mac
  /// </summary>
  Task<SubnetMacGetResponse> SubnetMacGetAsync(string ip);

  /// <summary>
  /// Set the mac address of a ipv6 subnet
  /// Operation: PUT /subnet/{ip}/mac
  /// </summary>
  Task<SubnetMacSetResponse> SubnetMacSetAsync(string ip, Apigen.Hetzner.Robot.Models.SubnetMacSetRequest subnetMacSetRequest);

  /// <summary>
  /// Reset the mac address of a ipv6 subnet to the
  /// Operation: DELETE /subnet/{ip}/mac
  /// </summary>
  Task<SubnetMacResetResponse> SubnetMacResetAsync(string ip);

}
