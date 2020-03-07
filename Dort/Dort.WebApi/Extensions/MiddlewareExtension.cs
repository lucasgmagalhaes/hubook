using Dort.WebApi.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Dort.WebApi.Extensions
{
    public static class MiddlewareExtension
    {

        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCultureMiddleware>();
        }
    }
}
