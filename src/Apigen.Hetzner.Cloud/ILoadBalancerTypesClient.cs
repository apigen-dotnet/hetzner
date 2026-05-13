using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Load Balancer Types operations
/// </summary>
public partial interface ILoadBalancerTypesClient
{
  /// <summary>
  /// List Load Balancer Types
  /// Operation: GET /load_balancer_types
  /// </summary>
  Task<JsonElement> ListLoadBalancerTypesAsync(ListLoadBalancerTypesRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Load Balancer Type
  /// Operation: GET /load_balancer_types/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

}
