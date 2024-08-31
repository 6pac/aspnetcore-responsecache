// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Extensions.Caching.Memory;
using System;

namespace AspNetCorePlus.ResponseCaching;

internal sealed class AspNetCorePlus_MemoryResponseCache : IAspNetCorePlus_ResponseCache
{
    private readonly IMemoryCache _cache;

    internal AspNetCorePlus_MemoryResponseCache(IMemoryCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public IAspNetCorePlus_ResponseCacheEntry? Get(string key)
    {
        var entry = _cache.Get(key);

        if (entry is AspNetCorePlus_MemoryCachedResponse memoryCachedResponse)
        {
            return new AspNetCorePlus_CachedResponse
            {
                Created = memoryCachedResponse.Created,
                StatusCode = memoryCachedResponse.StatusCode,
                Headers = memoryCachedResponse.Headers,
                Body = memoryCachedResponse.Body
            };
        }
        else
        {
            return entry as IAspNetCorePlus_ResponseCacheEntry;
        }
    }

    public void Set(string key, IAspNetCorePlus_ResponseCacheEntry entry, TimeSpan validFor)
    {
        if (entry is AspNetCorePlus_CachedResponse cachedResponse)
        {
            _cache.Set(
                key,
                new AspNetCorePlus_MemoryCachedResponse
                {
                    Created = cachedResponse.Created,
                    StatusCode = cachedResponse.StatusCode,
                    Headers = cachedResponse.Headers,
                    Body = cachedResponse.Body
                },
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = validFor,
                    Size = AspNetCorePlus_CacheEntryHelpers.EstimateCachedResponseSize(cachedResponse)
                });
        }
        else
        {
            _cache.Set(
                key,
                entry,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = validFor,
                    Size = AspNetCorePlus_CacheEntryHelpers.EstimateCachedVaryByRulesySize(entry as AspNetCorePlus_CachedVaryByRules)
                });
        }
    }
}
