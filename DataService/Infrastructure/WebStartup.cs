using DataService.Infrastructure.Extensions;
using DataService.Infrastructure.Middleware;
using DataService.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DataService.Infrastructure
{
    public class WebStartup
    {
        public WebStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var appSettings = app.ApplicationServices.GetService<IApplicationSettings>();
            app.UseCustomMiddlewareForRequestResponseLogging(appSettings.EndpointsToLog);

            app.UseCustomMiddlewareForExceptions();

            app.UseCors();

            app.UseMvc();
        }
    }
}
