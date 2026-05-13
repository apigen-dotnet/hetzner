using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for boot operations
/// </summary>
public partial interface IBootClient
{
  /// <summary>
  /// Get current boot config
  /// Operation: GET /boot/{server_number}
  /// </summary>
  Task<BootGetResponse> GetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get server rescue data
  /// Operation: GET /boot/{server_number}/rescue
  /// </summary>
  Task<RescueGetResponse> RescueGetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Activate rescue system for a server
  /// Operation: POST /boot/{server_number}/rescue
  /// </summary>
  Task<RescueActivateResponse> RescueActivateAsync(string serverNumber, Apigen.Hetzner.Robot.Models.RescueActivateRequest rescueActivateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deactivate rescue system for a server
  /// Operation: DELETE /boot/{server_number}/rescue
  /// </summary>
  Task<RescueDeactivateResponse> RescueDeactivateAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get data of last rescue system activation
  /// Operation: GET /boot/{server_number}/rescue/last
  /// </summary>
  Task<RescueGetLastResponse> RescueGetLastAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get linux data
  /// Operation: GET /boot/{server_number}/linux
  /// </summary>
  Task<LinuxGetResponse> LinuxGetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Activate linux installation
  /// Operation: POST /boot/{server_number}/linux
  /// </summary>
  Task<LinuxActivateResponse> LinuxActivateAsync(string serverNumber, Apigen.Hetzner.Robot.Models.LinuxActivateRequest linuxActivateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deactivate linux installation
  /// Operation: DELETE /boot/{server_number}/linux
  /// </summary>
  Task<LinuxDeactivateResponse> LinuxDeactivateAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get data of last linux installation activation
  /// Operation: GET /boot/{server_number}/linux/last
  /// </summary>
  Task<LinuxGetLastResponse> LinuxGetLastAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get vnc data
  /// Operation: GET /boot/{server_number}/vnc
  /// </summary>
  Task<VncGetResponse> VncGetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Activate vnc installation
  /// Operation: POST /boot/{server_number}/vnc
  /// </summary>
  Task<VncActivateResponse> VncActivateAsync(string serverNumber, Apigen.Hetzner.Robot.Models.VncActivateRequest vncActivateRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deactivate vnc installation
  /// Operation: DELETE /boot/{server_number}/vnc
  /// </summary>
  Task<VncDeactivateResponse> VncDeactivateAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get windows data
  /// Operation: GET /boot/{server_number}/windows
  /// </summary>
  Task<WindowsGetResponse> WindowsGetAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Activate windows installation
  /// Operation: POST /boot/{server_number}/windows
  /// </summary>
  Task<WindowsActivateResponse> WindowsActivateAsync(string serverNumber, CancellationToken cancellationToken = default);

  /// <summary>
  /// Deactivate windows installation
  /// Operation: DELETE /boot/{server_number}/windows
  /// </summary>
  Task<WindowsDeactivateResponse> WindowsDeactivateAsync(string serverNumber, CancellationToken cancellationToken = default);

}
