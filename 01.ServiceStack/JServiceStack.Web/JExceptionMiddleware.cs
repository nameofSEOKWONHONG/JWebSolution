using System.Threading.Tasks;
using eXtensionSharp;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace JServiceStack.Web
{
    public class JExceptionMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public JExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory) {
            _next = next;
            _logger = loggerFactory.CreateLogger<JExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next(context);
            }
            finally {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature.xIsNotNull() && contextFeature.Error.xIsNotNull())
                {
                    // Add lines to your log file, or your
                    // Application insights Instance here
                    // ...

                    _logger.LogError(contextFeature.Error, contextFeature.Error.Message);
                    //context.Response.StatusCode = (int)GetErrorCode(contextFeature.Error);
                    //context.Response.ContentType = "application/json";

                    //await context.Response.WriteAsync(JsonConvert.SerializeObject(new ProblemDetails() {
                    //    Status = context.Response.StatusCode,
                    //    Title = contextFeature.Error.Message
                    //}));                    
                }
            }
        }
    }
}