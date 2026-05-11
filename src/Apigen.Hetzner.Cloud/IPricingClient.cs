using System.Text.Json;
using System.Threading.Tasks;
using Apigen.Hetzner.Cloud.Models;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Interface for Pricing operations
/// </summary>
public partial interface IPricingClient
{
  /// <summary>
  /// Get all prices
  /// Operation: GET /pricing
  /// </summary>
  Task<JsonElement> GetAsync();

}
