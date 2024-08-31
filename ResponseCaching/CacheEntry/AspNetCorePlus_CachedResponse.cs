// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.AspNetCore.Http;

namespace AspNetCorePlus.ResponseCaching;

internal sealed class AspNetCorePlus_CachedResponse : IAspNetCorePlus_ResponseCacheEntry
{
    public DateTimeOffset Created { get; set; }

    public int StatusCode { get; set; }

    public IHeaderDictionary Headers { get; set; } = default!;

    public AspNetCorePlus_CachedResponseBody Body { get; set; } = default!;
}
