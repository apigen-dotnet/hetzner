using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Certificate Actions operations
/// </summary>
public partial interface ICertificateActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /certificates/actions
  /// </summary>
  Task<JsonElement> ListCertificatesActionsAsync(ListCertificatesActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action
  /// Operation: GET /certificates/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// List Actions for a Certificate
  /// Operation: GET /certificates/{id}/actions
  /// </summary>
  Task<JsonElement> ListCertificateActionsAsync(int id, ListCertificateActionsRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Retry Issuance or Renewal
  /// Operation: POST /certificates/{id}/actions/retry
  /// </summary>
  Task<JsonElement> RetryCertificateAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get an Action for a Certificate
  /// Operation: GET /certificates/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId, CancellationToken cancellationToken = default);

}
