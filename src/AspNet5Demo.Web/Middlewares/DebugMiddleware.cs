using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Configuration;

namespace AspNet5Demo.Web.Middlewares
{
    public class DebugMiddleware
    {
        private readonly RequestDelegate _next;

        public DebugMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IConfiguration config)
        {
            Debug.WriteLine(config["debug.prefix"] + "Incoming request");
            await _next(context);
            Debug.WriteLine(config["debug.prefix"] + "Outgoing request");
        }

    }
}
