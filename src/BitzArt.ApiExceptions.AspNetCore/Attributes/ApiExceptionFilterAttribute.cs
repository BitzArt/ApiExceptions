using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BitzArt.ApiExceptions.AspNetCore;
using System.Diagnostics;

namespace BitzArt.ApiExceptions;

/// <summary>
/// This attribute allows for the handling of exceptions thrown by the MVC controller.
/// </summary>
public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private static ApiExceptionHandlerOptions? _options;
    private static ILogger? _logger;

    /// <summary>
    /// Handles the exception and returns a problem details response.
    /// </summary>
    /// <param name="context"></param>
    public override void OnException(ExceptionContext context)
    {
        var httpContext = context.HttpContext;

        _options ??= httpContext.RequestServices.GetService<ApiExceptionHandlerOptions>();
        _options ??= new();

        _logger ??= httpContext.RequestServices.GetRequiredService<ILogger<IApiExceptionHandler>>();

        var exception = context.Exception;

        var problem = exception.GetProblemDetails(httpContext, _options);
        context.Result = new ObjectResult(problem);

        if (_options.LogRequests)
        {
            var req = httpContext.Request;
            _logger.LogInformation("{timestamp} {method} {path} : {statusCode}", string.Format("{0:u}", DateTime.Now), req.Method, req.Path, httpContext.Response.StatusCode);
        }
        if (_options.LogExceptions)
        {
            _logger.LogError("{exception}", exception.ToStringDemystified());
        }
    }
}
