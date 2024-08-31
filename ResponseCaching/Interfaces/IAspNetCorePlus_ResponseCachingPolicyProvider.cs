﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace AspNetCorePlus.ResponseCaching;

internal interface IAspNetCorePlus_ResponseCachingPolicyProvider {
    /// <summary>
    /// Determine whether the response caching logic should be attempted for the incoming HTTP request.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns><c>true</c> if response caching logic should be attempted; otherwise <c>false</c>.</returns>
    bool AttemptResponseCaching(AspNetCorePlus_ResponseCachingContext context, AspNetCorePlus_ResponseCachingOptions _options);

    /// <summary>
    /// Determine whether a cache lookup is allowed for the incoming HTTP request.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns><c>true</c> if cache lookup for this request is allowed; otherwise <c>false</c>.</returns>
    bool AllowCacheLookup(AspNetCorePlus_ResponseCachingContext context);

    /// <summary>
    /// Determine whether storage of the response is allowed for the incoming HTTP request.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns><c>true</c> if storage of the response for this request is allowed; otherwise <c>false</c>.</returns>
    bool AllowCacheStorage(AspNetCorePlus_ResponseCachingContext context);

    /// <summary>
    /// Determine whether the response received by the middleware can be cached for future requests.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns><c>true</c> if the response is cacheable; otherwise <c>false</c>.</returns>
    bool IsResponseCacheable(AspNetCorePlus_ResponseCachingContext context);

    /// <summary>
    /// Determine whether the response retrieved from the response cache is fresh and can be served.
    /// </summary>
    /// <param name="context">The <see cref="AspNetCorePlus_ResponseCachingContext"/>.</param>
    /// <returns><c>true</c> if the cached entry is fresh; otherwise <c>false</c>.</returns>
    bool IsCachedEntryFresh(AspNetCorePlus_ResponseCachingContext context);
}
