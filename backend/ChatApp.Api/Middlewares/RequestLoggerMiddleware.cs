using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ChatApp.Api.Middlewares
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<RequestLoggerMiddleware> logger;

        public RequestLoggerMiddleware(
            RequestDelegate next,
            ILogger<RequestLoggerMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            logger.LogInformation($"Request to {httpContext.Request.Path.Value} recieved");

            await next(httpContext);

            logger.LogInformation($"Request to {httpContext.Request.Path.Value} processed");
        }
    }
}
