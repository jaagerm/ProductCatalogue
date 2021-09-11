using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace DataService.Infrastructure.Extensions
{
    public static class WebHostBuilderExtensions
    {
        public static IWebHostBuilder ConfigureServices(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.ConfigureServices((context, collection) =>
            {
                collection.AddApplicationSettings(context);
                collection.AddApplicationConfigurationClient(context);
                collection.AddOtherSingletonServices();
            });
        }

        public static IWebHostBuilder ConfigureLogging(this IWebHostBuilder webHostBuilder)
        {
            return webHostBuilder.ConfigureLogging((context, builder) =>
            {
                builder.ClearProviders();
                builder.AddConfiguration(context.Configuration.GetSection("Logging"))
                    .AddConsole();
            });
        }
    }
}
