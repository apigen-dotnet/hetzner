using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Api.Models;

#nullable enable

namespace Apigen.Hetzner.Api;

/// <summary>
/// Interface for Storage Box Subaccount Actions operations
/// </summary>
public partial interface IStorageBoxSubaccountActionsClient
{
  /// <summary>
  /// Change Home Directory
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/change_home_directory
  /// </summary>
  Task<JsonElement> ChangeStorageBoxSubaccountHomeDirectoryAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.ChangeStorageBoxSubaccountHomeDirectoryRequest changeStorageBoxSubaccountHomeDirectoryRequest);

  /// <summary>
  /// Reset Password
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/reset_subaccount_password
  /// </summary>
  Task<JsonElement> ResetStorageBoxSubaccountPasswordAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.ResetStorageBoxSubaccountPasswordRequest resetStorageBoxSubaccountPasswordRequest);

  /// <summary>
  /// Update Access Settings
  /// Operation: POST /storage_boxes/{id}/subaccounts/{subaccount_id}/actions/update_access_settings
  /// </summary>
  Task<JsonElement> UpdateStorageBoxSubaccountAccessSettingsAsync(int id, int subaccountId, Apigen.Hetzner.Api.Models.UpdateStorageBoxSubaccountAccessSettingsRequest updateStorageBoxSubaccountAccessSettingsRequest);

}
