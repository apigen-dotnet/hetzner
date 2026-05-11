using System.Collections.Generic;
using System.Linq;
using System.Web;

#nullable enable

namespace Apigen.Hetzner.Cloud;

/// <summary>
/// Base class for request objects
/// </summary>
public abstract partial class BaseRequest
{
  public virtual string ToQueryString() => string.Empty;
}
