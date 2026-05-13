using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for vswitch operations
/// </summary>
public partial interface IVswitchClient
{
  /// <summary>
  /// Create a new vSwitch
  /// Operation: POST /vswitch
  /// </summary>
  Task<VswitchCreateResponse> CreateAsync(CancellationToken cancellationToken = default);

  /// <summary>
  /// Change the VLAN id of a vSwitch
  /// Operation: POST /vswitch/{vswitch_id}
  /// </summary>
  Task<JsonElement> VswitchChangeVlanAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchChangeVlanRequest vswitchChangeVlanRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Cancel a vSwitch
  /// Operation: DELETE /vswitch/{vswitch_id}
  /// </summary>
  Task DeleteAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchCancelRequest vswitchCancelRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Add servers to a vSwitch
  /// Operation: POST /vswitch/{vswitch_id}/server
  /// </summary>
  Task<JsonElement> VswitchAddServersAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchAddServersRequest vswitchAddServersRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Remove servers from a vSwitch
  /// Operation: DELETE /vswitch/{vswitch_id}/server
  /// </summary>
  Task VswitchRemoveServersAsync(int vswitchId, Apigen.Hetzner.Robot.Models.VswitchRemoveServersRequest vswitchRemoveServersRequest, CancellationToken cancellationToken = default);

}
