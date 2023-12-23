using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Presentation
{
    public class CachedAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveSeconds;

        public CachedAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds=timeToLiveSeconds;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            /// i want from clr create object from class implement IResponseCacheService insteed of method dependancy 
            /// injection in constructor and i write that attribute [CachedAttribute(600)] insteed [CachedAttribute(600, IReponseCacheService)] 
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheService.GetCachedResponseAsync(cacheKey);
            if(!string.IsNullOrEmpty(cachedResponse))
            {
                var contentResult = new ContentResult()
                { 
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var executeedEndpointContext = await next(); /// will execute the endpoint

            if (executeedEndpointContext.Result is OkObjectResult okObjectResult)
            {
                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append(request.Path);
            
            /// pagelength =3
            /// pageSize = 3
            /// sort=name

            /// /api/products
            foreach (var (key, value) in request.Query)
            {
                keyBuilder.Append($"| {key}-{value}");
                ///  /api/products|pagelength =3
                ///  /api/products|pagelength =3|pageSize = 3
                ///  /api/products|pagelength =3|pageSize = 3|sort=name
            }

            return keyBuilder.ToString();   
        }
    }
}
