using System.Collections;
using System.Globalization;
using System.Net.Http;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Apigen.Hetzner.Robot;

internal static class FormUrlEncodedContentExtensions
{
  /// <summary>
  /// Converts a DTO object to FormUrlEncodedContent for OAuth2 token endpoints,
  /// the Hetzner Robot Webservice, and any other form-encoded body endpoint.
  /// Uses JsonPropertyName attribute for field names. Null properties are omitted.
  /// Repeated array fields use PHP-style indexed brackets (name[0]=…&name[1]=…),
  /// matching http_build_query() output and what Hetzner's reference clients emit.
  /// Numeric and DateTime values are formatted with invariant culture.
  /// </summary>
  public static FormUrlEncodedContent ToFormUrlEncodedContent(this object dto)
  {
    List<KeyValuePair<string, string>> fields = new();

    foreach (PropertyInfo prop in dto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
      object? value = prop.GetValue(dto);
      if (value == null) continue;

      string fieldName = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;

      AppendField(fields, fieldName, value);
    }

    return new FormUrlEncodedContent(fields);
  }

  private static void AppendField(List<KeyValuePair<string, string>> fields, string name, object value)
  {
    switch (value)
    {
      case string s:
        fields.Add(new(name, s));
        break;
      case bool b:
        fields.Add(new(name, b ? "true" : "false"));
        break;
      case int or long or short or byte or uint or ulong or ushort or sbyte:
        fields.Add(new(name, ((IFormattable)value).ToString(null, CultureInfo.InvariantCulture)));
        break;
      case float or double or decimal:
        fields.Add(new(name, ((IFormattable)value).ToString(null, CultureInfo.InvariantCulture)));
        break;
      case DateTime dt:
        fields.Add(new(name, dt.ToString("o", CultureInfo.InvariantCulture)));
        break;
      case DateTimeOffset dto:
        fields.Add(new(name, dto.ToString("o", CultureInfo.InvariantCulture)));
        break;
      case IEnumerable enumerable:
        // PHP-style bare brackets: `name[]=…&name[]=…`. This matches what
        // Hetzner's docs literally show in their curl examples, what PHP's
        // http_build_query produces for unindexed arrays, and what the
        // PHP/Laravel/Symfony/WordPress/Drupal ecosystems parse natively.
        // Equivalent to `name[0]=…&name[1]=…` on any PHP server but closer
        // to the documented format.
        foreach (object? item in enumerable)
        {
          if (item == null) continue;
          AppendField(fields, $"{name}[]", item);
        }
        break;
      default:
        fields.Add(new(name, value.ToString() ?? ""));
        break;
    }
  }
}
