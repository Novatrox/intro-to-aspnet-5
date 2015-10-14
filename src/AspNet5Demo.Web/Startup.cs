using AspNet5Demo.Common;
using AspNet5Demo.Web.Middlewares;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;

namespace AspNet5Demo.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment hostingEnv, IApplicationEnvironment appEnv)
        {
            Configuration = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();
        }

        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton(x => Configuration);
            services.AddSingleton(typeof (IGreetingService), typeof (GreetingService));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<DebugMiddleware>();

            app.UseMvc(x =>
            {
                x.MapRoute("Default", "{controller:alpha=Home}/{action:regex(^.+$)=Index}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public IConfiguration Configuration { get; set; }
    }
}
