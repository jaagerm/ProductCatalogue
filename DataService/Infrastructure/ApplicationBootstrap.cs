using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using DataService.Infrastructure.Extensions;

namespace DataService.Infrastructure
{
    public class ApplicationBootstrap
    {
        private readonly IConfigurationRoot configurationRoot;
        private readonly IWebHost webHost;

        public ApplicationBootstrap()
        {
            configurationRoot = BuildConfigurationRoot();
            webHost = BuildWebHost();
        }

        public void Run()
        {
            webHost.Run();
        }

        private static IConfigurationRoot BuildConfigurationRoot()
        {
            var environmentName = Environment.GetEnvironmentVariable("APP_ENVIRONMENT");

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Settings/appsettings.json", false)
                .AddJsonFile($"Settings/appsettings.{environmentName}.json", true)
                .Build();
        }

        private IWebHost BuildWebHost()
        {
            return WebHost
                .CreateDefaultBuilder()
                .UseConfiguration(configurationRoot)
                .ConfigureServices()
                .ConfigureLogging()
                .UseKestrel()
                .UseUrls(configurationRoot.GetValue<string>("UrlToListen"))
                .UseShutdownTimeout(TimeSpan.FromSeconds(5))
                .UseStartup<WebStartup>()
                .Build();
        }
    }
}
