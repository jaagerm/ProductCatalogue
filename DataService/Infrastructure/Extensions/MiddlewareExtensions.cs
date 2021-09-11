using DataService.Infrastructure.Middleware;
using Microsoft.AspNetCore.Builder;

namespace DataService.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddlewareForExceptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }

        public static IApplicationBuilder UseCustomMiddlewareForRequestResponseLogging(this IApplicationBuilder builder, string[] endpointIdentifiers)
        {
            foreach (var identifier in endpointIdentifiers)
            {
                builder.UseWhen(context => context.Request.Path.StartsWithSegments(identifier), appBuilder =>
                {
                    appBuilder.UseMiddleware<RequestResponseLoggingMiddleware>();
                });
            }

            return builder;
        }
    }
}
