// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Primitives;

namespace AspNetCorePlus.ResponseCaching;

internal sealed class AspNetCorePlus_CachedVaryByRules : IAspNetCorePlus_ResponseCacheEntry
{
    public string VaryByKeyPrefix { get; set; } = default!;

    public StringValues Headers { get; set; }

    public StringValues QueryKeys { get; set; }
}
