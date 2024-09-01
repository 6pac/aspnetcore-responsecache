# aspnetcore-responsecache

Modified copy of the ASP Net Core Response caching libraries, adding a single thing: the ability to cache authorized endpoints.

The code includes two folders: ResponseCaching is the new version of the middleware components, and ResponseCachingOrig is the original code from the AspDotNet github repo.  If you want to see the changes you can use a diff tool like WinMerge or Beyond Compare.  
The changes are essentially those in this [Issue](https://github.com/dotnet/aspnetcore/issues/56769) and this matching [PR](https://github.com/dotnet/aspnetcore/pull/56768).  
The library also has all the key class names replaced with the same name but prefixed with 'AspNetCorePlus_' - this was to avoid confusion with the built in DotNet classes.

Note that Client Side Caching, requiring only a HTTP cache-control header, can be achieved much more easily (see the issue linked above and [this blog post](https://low-bandwidth.blogspot.com/2024/09/client-caching-in-asp-dotnet-core.html)). This library is for where Server Side Caching is required for authorized endpoints.

There is a very important rule when using Server Side Caching on authorized endpoints with this library: **NEVER** cache sensitive data that is specific to a user.  
Cached data should be data that will be used for *every* authorized user on the website.

To game this out, consider user X is logged in to the site (authorized) and goes to endpoint A: https://mysite.com/myaccountsettings  
Now user Y logs in and also goes to endpoint A. Rather than regenerating the page, the server serves up the cached page previouly served to user X.  
You can see why this is a problem on a number of levels - not the least being security.

However there is a case for server-caching content that is specific to the endpoint but should be served up to **all** authorized users, such as say a list of 2000 store addresses for an organisation pulled from a database.

To add the new *AspNetCorePlus_AddResponseCaching* middleware to the service pipeline, once the project reference has been added, use in ```startup.cs```:

    public void ConfigureServices(IServiceCollection services) {
      ...
      services.AddHttpsRedirection(options => { options.HttpsPort = 443; });
      
      services.AspNetCorePlus_AddResponseCaching(options => { 
        options.AllowAuthorizedEndpoint = true; 
      });
      ...
 
and here is an example of a controller using the caching:


    namespace AspMvcApp.Controllers { 
      [Authorize]
      [ResponseCache(Duration = 20000, Location = ResponseCacheLocation.Client)]
      public class ScriptController : Controller {
        [Route("Script/list-view-cache.js")]
        public IActionResult list_view_cache(string hash) {
          var scriptText= ListViewCache.GetTableDataCacheItemByHash(hash).TableDataSerialised;
          return Content(scriptText, "text/javascript");
        }
      }
    }

