using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Robot;

/// <summary>
/// Extension methods for building query strings and URL templates
/// </summary>
public static class QueryStringExtensions
{
  /// <summary>
  /// Converts a dictionary of query parameters to a URL-encoded query string
  /// </summary>
  /// <param name="queryParams">Dictionary of query parameters</param>
  /// <returns>URL-encoded query string starting with '?' or empty string if no parameters</returns>
  public static string ToQueryString(this Dictionary<string, object> queryParams)
  {
    if (queryParams.Count == 0) return string.Empty;

    IEnumerable<string> encodedParams = queryParams.Select(kvp =>
    {
      string valueStr = kvp.Value switch
      {
        null => string.Empty,
        IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
        _ => kvp.Value.ToString() ?? string.Empty
      };
      return $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(valueStr)}";
    });

    return "?" + string.Join("&", encodedParams);
  }

  /// <summary>
  /// Builds a URL from a template string by safely substituting parameters and appending query string
  /// </summary>
  /// <param name="template">URL template with {param} placeholders (case-sensitive)</param>
  /// <param name="pathParams">Dictionary with path parameter values. Keys must match template placeholders exactly.</param>
  /// <param name="request">Request object with ToQueryString method for query parameters</param>
  /// <returns>Complete URL with path parameters substituted and query string appended</returns>
  public static string BuildUrl(this string template, Dictionary<string, object>? pathParams = null, object? request = null)
  {
    string url = template;

    // Handle path parameter substitution
    if (pathParams != null)
    {
      // Dictionary keys must match template placeholders exactly (case-sensitive)

      StringBuilder result = new StringBuilder();
      int lastIndex = 0;

      while (lastIndex < template.Length)
      {
        int openBrace = template.IndexOf('{', lastIndex);
        if (openBrace == -1)
        {
          // No more placeholders, append the rest
          result.Append(template.Substring(lastIndex));
          break;
        }

        // Append literal part before the placeholder
        result.Append(template.Substring(lastIndex, openBrace - lastIndex));

        int closeBrace = template.IndexOf('}', openBrace);
        if (closeBrace == -1)
        {
          // Malformed template, append the rest as-is
          result.Append(template.Substring(openBrace));
          break;
        }

        // Extract parameter name and substitute
        string paramName = template.Substring(openBrace + 1, closeBrace - openBrace - 1);
        if (pathParams.TryGetValue(paramName, out object? paramValue))
        {
          string valueStr = paramValue switch
          {
            null => string.Empty,
            IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
            _ => paramValue.ToString() ?? string.Empty
          };
          result.Append(Uri.EscapeDataString(valueStr));
        }
        else
        {
          // Parameter not found, keep placeholder
          result.Append(template.Substring(openBrace, closeBrace - openBrace + 1));
        }

        lastIndex = closeBrace + 1;
      }

      url = result.ToString();
    }

    // Handle query string appending
    if (request != null)
    {
      MethodInfo? toQueryStringMethod = request.GetType().GetMethod("ToQueryString");
      if (toQueryStringMethod != null)
      {
        string? queryString = toQueryStringMethod.Invoke(request, null) as string;
        if (!string.IsNullOrEmpty(queryString))
        {
          url += queryString;
        }
      }
    }

    return url;
  }
}
