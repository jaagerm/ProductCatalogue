using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;

namespace DataService.Infrastructure.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public RequestResponseLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestResponseLoggingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await next(context);

                var response = await FormatResponse(context.Response);

                logger.LogInformation($"REQUEST: {request}, RESPONSE: {response}");

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private static async Task<string> FormatRequest(HttpRequest request)
        {
            string bodyAsText = null;

            if (request.ContentLength > 0)
            {
                request.EnableRewind();

                var buffer = new byte[Convert.ToInt32(request.ContentLength)];

                await request.Body.ReadAsync(buffer, 0, buffer.Length);

                bodyAsText = Encoding.UTF8.GetString(buffer);

                request.Body.Seek(0, SeekOrigin.Begin);
            }

            return $"{request.Method} | {request.Host} | {request.Path} | {request.QueryString} | {bodyAsText}";
        }

        private static async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var bodyText = await new StreamReader(response.Body).ReadToEndAsync();

            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{response.StatusCode}: {bodyText}";
        }
    }
}
