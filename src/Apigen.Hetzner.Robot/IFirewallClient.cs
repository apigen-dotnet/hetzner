using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Robot.Models;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Interface for firewall operations
/// </summary>
public partial interface IFirewallClient
{
  /// <summary>
  /// Get firewall of server
  /// Operation: GET /firewall/{server_number}/{port}
  /// </summary>
  Task<JsonElement> GetAsync(string serverNumber, string port);

  /// <summary>
  /// Craete new firewall or update existing firewall from template
  /// Operation: POST /firewall/{server_number}/{port}
  /// </summary>
  Task<JsonElement> FirewallCreateOrUpdateFromTemplateAsync(string serverNumber, string port, Apigen.Hetzner.Robot.Models.FirewallCreateOrUpdateFromTemplateRequest firewallCreateOrUpdateFromTemplateRequest);

  /// <summary>
  /// Delete firewall
  /// Operation: DELETE /firewall/{server_number}/{port}
  /// </summary>
  Task DeleteAsync(string serverNumber, string port);

  /// <summary>
  /// Get all existing firewall templates
  /// Operation: GET /firewall/template
  /// </summary>
  Task<List<FirewallTemplateGetAllResponse>> FirewallTemplateGetAllAsync();

  /// <summary>
  /// Create a new firewall template
  /// Operation: POST /firewall/template
  /// </summary>
  Task<FirewallTemplateCreateResponse> FirewallTemplateCreateAsync(Apigen.Hetzner.Robot.Models.FirewallTemplateCreateRequest firewallTemplateCreateRequest);

  /// <summary>
  /// Get a specific firewall template by ID
  /// Operation: GET /firewall/template/{template_id}
  /// </summary>
  Task<FirewallTemplateGetResponse> GetAsync(string templateId);

  /// <summary>
  /// Update a existing firewall template name
  /// Operation: POST /firewall/template/{template_id}
  /// </summary>
  Task<FirewallTemplateUpdateNameResponse> FirewallTemplateUpdateNameAsync(int templateId, Apigen.Hetzner.Robot.Models.FirewallTemplateUpdateNameRequest firewallTemplateUpdateNameRequest);

  /// <summary>
  /// Delete a firewall template
  /// Operation: DELETE /firewall/template/{template_id}
  /// </summary>
  Task DeleteAsync(int templateId);

}
