using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace BitzArt.ApiExceptions.AspNetCore;

public class ApiExceptionHandlingMiddleware<THandler>
    where THandler : IApiExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ApiExceptionHandlerOptions _options;

    public ApiExceptionHandlingMiddleware(RequestDelegate next, ApiExceptionHandlerOptions options)
    {
        _next = next;
        _options = options;
    }

    public virtual async Task InvokeAsync(HttpContext context, THandler handler, ILogger<IApiExceptionHandler> logger)
    {
        try
        {
            await _next(context);

            if (_options.EnableRequestLogging)
            {
                var req = context.Request;
                logger.LogInformation("{timestamp} {method} {path} : 200", string.Format("{0:u}", DateTime.Now), req.Method, req.Path);
            }
        }
        catch (Exception ex)
        {
            await handler.HandleAsync(ex);
        }
    }
}
