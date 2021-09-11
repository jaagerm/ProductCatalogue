using DataService.Domain.Products;
using DataService.MockExternalLibraries;
using DataService.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DataService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationSettings(this IServiceCollection serviceCollection, WebHostBuilderContext context)
        {
            serviceCollection.AddOptions();

            serviceCollection.Configure<ApplicationInformation>(context.Configuration.GetSection(nameof(ApplicationInformation)));
        }

        public static void AddApplicationConfigurationClient(this IServiceCollection serviceCollection, WebHostBuilderContext context)
        {
            serviceCollection.AddSingleton<IApplicationConfigurationClient>(serviceProvider => new ApplicationConfigurationClient());
        }

        public static void AddOtherSingletonServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IApplicationSettings, ApplicationSettings>();
            serviceCollection.AddSingleton<IProductCache, ProductCache>();
            serviceCollection.AddSingleton<IProductCacheUpdater, ProductCacheUpdater>();
        }
    }
}
