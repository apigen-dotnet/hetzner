using System.Text.Json;
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
  Task<JsonElement> ListLoadBalancersAsync(ListLoadBalancersRequest? request = null);

  /// <summary>
  /// Create a Load Balancer
  /// Operation: POST /load_balancers
  /// </summary>
  Task<JsonElement> CreateLoadBalancerAsync(Apigen.Hetzner.Cloud.Models.CreateLoadBalancerRequest createLoadBalancerRequest);

  /// <summary>
  /// Get a Load Balancer
  /// Operation: GET /load_balancers/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// Update a Load Balancer
  /// Operation: PUT /load_balancers/{id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, Apigen.Hetzner.Cloud.Models.UpdateLoadBalancerRequest updateLoadBalancerRequest);

  /// <summary>
  /// Delete a Load Balancer
  /// Operation: DELETE /load_balancers/{id}
  /// </summary>
  Task DeleteAsync(int id);

  /// <summary>
  /// Get Metrics for a LoadBalancer
  /// Operation: GET /load_balancers/{id}/metrics
  /// </summary>
  Task<JsonElement> GetLoadBalancerMetricsAsync(int id, GetLoadBalancerMetricsRequest? request = null);

}
