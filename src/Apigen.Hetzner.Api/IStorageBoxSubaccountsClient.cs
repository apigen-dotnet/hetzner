using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Interface for Storage Box Subaccounts operations
/// </summary>
public partial interface IStorageBoxSubaccountsClient
{
  /// <summary>
  /// List Subaccounts
  /// Operation: GET /storage_boxes/{id}/subaccounts
  /// </summary>
  Task<JsonElement> ListStorageBoxSubaccountsAsync(int id, ListStorageBoxSubaccountsRequest? request = null);

  /// <summary>
  /// Create a Subaccount
  /// Operation: POST /storage_boxes/{id}/subaccounts
  /// </summary>
  Task<JsonElement> CreateStorageBoxSubaccountAsync(int id, Apigen.Hetzner.Api.Models.CreateStorageBoxSubaccountRequest createStorageBoxSubaccountRequest);

  /// <summary>
  /// Get a Subaccount
  /// Operation: GET /storage_boxes/{id}/subaccounts/{subaccount_id}
  /// </summary>
  Task<JsonElement> GetAsync(int id, int subaccountId);

  /// <summary>
  /// Update a Subaccount
  /// Operation: PUT /storage_boxes/{id}/subaccounts/{subaccount_id}
  /// </summary>
  Task<JsonElement> UpdateAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.UpdateStorageBoxSubaccountRequest updateStorageBoxSubaccountRequest);

  /// <summary>
  /// Delete a Subaccount
  /// Operation: DELETE /storage_boxes/{id}/subaccounts/{subaccount_id}
  /// </summary>
  Task<JsonElement> DeleteAsync(int id, int subaccountId);

}
