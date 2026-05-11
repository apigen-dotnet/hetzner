using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Apigen.Hetzner.Robot;

internal static class FormUrlEncodedContentExtensions
{
  /// <summary>
  /// Converts a DTO object to FormUrlEncodedContent for OAuth2 token endpoints and similar.
  /// Uses JsonPropertyName attribute for field names. Null properties are omitted.
  /// </summary>
  public static FormUrlEncodedContent ToFormUrlEncodedContent(this object dto)
  {
    List<KeyValuePair<string, string>> fields = new();

    foreach (PropertyInfo prop in dto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
      object? value = prop.GetValue(dto);
      if (value == null) continue;

      string fieldName = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;

      if (value is bool boolValue)
        fields.Add(new(fieldName, boolValue.ToString().ToLowerInvariant()));
      else if (value is int or long or short or byte)
        fields.Add(new(fieldName, value.ToString()!));
      else
        fields.Add(new(fieldName, value.ToString() ?? ""));
    }

    return new FormUrlEncodedContent(fields);
  }
}
