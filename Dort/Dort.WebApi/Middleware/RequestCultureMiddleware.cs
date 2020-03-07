using Dort.I18n;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace Dort.WebApi.Middleware
{
    public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext http)
        {
            CultureManager.Lang = http.Request.GetTypedHeaders().AcceptLanguage.FirstOrDefault().Value.Value;
            await _next(http);
        }
    }
}
