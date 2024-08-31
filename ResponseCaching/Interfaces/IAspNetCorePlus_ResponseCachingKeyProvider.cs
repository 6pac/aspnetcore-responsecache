// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace AspNetCorePlus.ResponseCaching;

internal interface IAspNetCorePlus_ResponseCachingKeyProvider
{
    /// <summary>
    /// Create a base key for a response cache entry.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns>The created base key.</returns>
    string CreateBaseKey(AspNetCorePlus_ResponseCachingContext context);

    /// <summary>
    /// Create a vary key for storing cached responses.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns>The created vary key.</returns>
    string CreateStorageVaryByKey(AspNetCorePlus_ResponseCachingContext context);

    /// <summary>
    /// Create one or more vary keys for looking up cached responses.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns>An ordered <see cref="IEnumerable{T}"/> containing the vary keys to try when looking up items.</returns>
    IEnumerable<string> CreateLookupVaryByKeys(AspNetCorePlus_ResponseCachingContext context);
}
