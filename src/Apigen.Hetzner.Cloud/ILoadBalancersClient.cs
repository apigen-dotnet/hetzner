using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Load Balancers operations
/// </summary>
public partial interface ILoadBalancersClient
{
  /// <summary>
  /// List Load Balancers
  /// Operation: GET /load_balancers
  /// </summary>
  Task<JsonElement> ListLoadBalancersAsync(ListLoadBalancersRequest? request = null, CancellationToken cancellationToken = default);

  /// <summary>
  /// Create a Load Balancer
  /// Operation: POST /load_balancers
  /// </summary>
  Task<JsonElement> CreateLoadBalancerAsync(Apigen.Hetzner.Cloud.Models.CreateLoadBalancerRequest createLoadBalancerRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get a Load Balancer
  /// Operation: GET /load_balancers/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Update a Load Balancer
  /// Operation: PUT /load_balancers/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateLoadBalancerRequest updateLoadBalancerRequest, CancellationToken cancellationToken = default);

  /// <summary>
  /// Delete a Load Balancer
  /// Operation: DELETE /load_balancers/{id}
  /// </summary>
  Task DeleteAsync(int id, CancellationToken cancellationToken = default);

  /// <summary>
  /// Get Metrics for a LoadBalancer
  /// Operation: GET /load_balancers/{id}/metrics
  /// </summary>
  Task<JsonElement> GetLoadBalancerMetricsAsync(int id, GetLoadBalancerMetricsRequest? request = null, CancellationToken cancellationToken = default);

}
