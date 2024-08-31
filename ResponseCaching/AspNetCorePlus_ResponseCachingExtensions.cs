// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.Builder;
using System;
using AspNetCorePlus.ResponseCaching;

namespace Microsoft.AspNetCorePlus.Builder;

/// <summary>
/// Extension methods for adding the <see cref="ResponseCachingMiddleware"/> to an application.
/// </summary>
public static class AspNetCorePlus_ResponseCachingExtensions
{
    /// <summary>
    /// Adds the <see cref="ResponseCachingMiddleware"/> for caching HTTP responses.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
    public static IApplicationBuilder AspNetCorePlus_UseResponseCaching(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app);

        return app.UseMiddleware<AspNetCorePlus_ResponseCachingMiddleware>();
    }
}
