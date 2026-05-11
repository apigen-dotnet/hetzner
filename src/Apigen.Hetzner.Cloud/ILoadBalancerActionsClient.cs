using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Load Balancer Actions operations
/// </summary>
public partial interface ILoadBalancerActionsClient
{
  /// <summary>
  /// List Actions
  /// Operation: GET /load_balancers/actions
  /// </summary>
  Task<JsonElement> ListLoadBalancersActionsAsync(ListLoadBalancersActionsRequest? request = null);

  /// <summary>
  /// Get an Action
  /// Operation: GET /load_balancers/actions/{id}
  /// </summary>
  Task<JsonElement> GetAsync(int id);

  /// <summary>
  /// List Actions for a Load Balancer
  /// Operation: GET /load_balancers/{id}/actions
  /// </summary>
  Task<JsonElement> ListLoadBalancerActionsAsync(int id, ListLoadBalancerActionsRequest? request = null);

  /// <summary>
  /// Add Service
  /// Operation: POST /load_balancers/{id}/actions/add_service
  /// </summary>
  Task<JsonElement> AddLoadBalancerServiceAsync(int id);

  /// <summary>
  /// Add Target
  /// Operation: POST /load_balancers/{id}/actions/add_target
  /// </summary>
  Task<JsonElement> AddLoadBalancerTargetAsync(int id);

  /// <summary>
  /// Attach a Load Balancer to a Network
  /// Operation: POST /load_balancers/{id}/actions/attach_to_network
  /// </summary>
  Task<JsonElement> AttachLoadBalancerToNetworkAsync(int id, Apigen.Hetzner.Cloud.Models.AttachLoadBalancerToNetworkRequest attachLoadBalancerToNetworkRequest);

  /// <summary>
  /// Change Algorithm
  /// Operation: POST /load_balancers/{id}/actions/change_algorithm
  /// </summary>
  Task<JsonElement> ChangeLoadBalancerAlgorithmAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeLoadBalancerAlgorithmRequest changeLoadBalancerAlgorithmRequest);

  /// <summary>
  /// Change reverse DNS entry for this Load Balancer
  /// Operation: POST /load_balancers/{id}/actions/change_dns_ptr
  /// </summary>
  Task<JsonElement> ChangeLoadBalancerDnsPtrAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeLoadBalancerDnsPtrRequest changeLoadBalancerDnsPtrRequest);

  /// <summary>
  /// Change Load Balancer Protection
  /// Operation: POST /load_balancers/{id}/actions/change_protection
  /// </summary>
  Task<JsonElement> ChangeLoadBalancerProtectionAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeLoadBalancerProtectionRequest changeLoadBalancerProtectionRequest);

  /// <summary>
  /// Change the Type of a Load Balancer
  /// Operation: POST /load_balancers/{id}/actions/change_type
  /// </summary>
  Task<JsonElement> ChangeLoadBalancerTypeAsync(int id, Apigen.Hetzner.Cloud.Models.ChangeLoadBalancerTypeRequest changeLoadBalancerTypeRequest);

  /// <summary>
  /// Delete Service
  /// Operation: POST /load_balancers/{id}/actions/delete_service
  /// </summary>
  Task<JsonElement> DeleteLoadBalancerServiceAsync(int id, Apigen.Hetzner.Cloud.Models.DeleteLoadBalancerServiceRequest deleteLoadBalancerServiceRequest);

  /// <summary>
  /// Detach a Load Balancer from a Network
  /// Operation: POST /load_balancers/{id}/actions/detach_from_network
  /// </summary>
  Task<JsonElement> DetachLoadBalancerFromNetworkAsync(int id, Apigen.Hetzner.Cloud.Models.DetachLoadBalancerFromNetworkRequest detachLoadBalancerFromNetworkRequest);

  /// <summary>
  /// Disable the public interface of a Load Balancer
  /// Operation: POST /load_balancers/{id}/actions/disable_public_interface
  /// </summary>
  Task<JsonElement> DisableLoadBalancerPublicInterfaceAsync(int id);

  /// <summary>
  /// Enable the public interface of a Load Balancer
  /// Operation: POST /load_balancers/{id}/actions/enable_public_interface
  /// </summary>
  Task<JsonElement> EnableLoadBalancerPublicInterfaceAsync(int id);

  /// <summary>
  /// Remove Target
  /// Operation: POST /load_balancers/{id}/actions/remove_target
  /// </summary>
  Task<JsonElement> RemoveLoadBalancerTargetAsync(int id, Apigen.Hetzner.Cloud.Models.RemoveLoadBalancerTargetRequest removeLoadBalancerTargetRequest);

  /// <summary>
  /// Update Service
  /// Operation: POST /load_balancers/{id}/actions/update_service
  /// </summary>
  Task<JsonElement> UpdateLoadBalancerServiceAsync(int id);

  /// <summary>
  /// Get an Action for a Load Balancer
  /// Operation: GET /load_balancers/{id}/actions/{action_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int actionId);

}
