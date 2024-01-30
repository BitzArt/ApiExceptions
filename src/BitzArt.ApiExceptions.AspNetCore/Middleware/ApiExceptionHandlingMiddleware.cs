using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BitzArt.ApiExceptions.AspNetCore;

internal class ApiExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ApiExceptionHandlerOptions _options;
    private readonly ILogger _requestLogger;

    public ApiExceptionHandlingMiddleware(RequestDelegate next, ApiExceptionHandlerOptions options, ILoggerFactory loggerFactory)
    {
        _next = next;
        _options = options;
        _requestLogger = loggerFactory.CreateLogger("Request");
    }

    public virtual async Task InvokeAsync(HttpContext context, IApiExceptionHandler handler)
    {
        try
        {
            await _next(context);

            if (_options.LogRequests)
            {
                var req = context.Request;
                _requestLogger.LogInformation("{timestamp} {method} {path} : 200", string.Format("{0:u}", DateTime.Now), req.Method, req.Path);
            }
        }
        catch (Exception ex)
        {
            await handler.HandleAsync(ex);
        }
    }
}
