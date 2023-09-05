using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BitzArt.ApiExceptions.AspNetCore;
using System.Diagnostics;

namespace BitzArt.ApiExceptions;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private static ApiExceptionHandlerOptions? _options;
    private static ILogger? _logger;

    public override void OnException(ExceptionContext context)
    {
        var httpContext = context.HttpContext;

        _options ??= httpContext.RequestServices.GetService<ApiExceptionHandlerOptions>();
        _options ??= new();

        _logger ??= httpContext.RequestServices.GetRequiredService<ILogger<IApiExceptionHandler>>();

        var exception = context.Exception;

        var problem = exception.GetProblemDetails(httpContext, _options);
        context.Result = new ObjectResult(problem);

        if (_options.EnableRequestLogging)
        {
            var req = httpContext.Request;
            _logger.LogInformation("{timestamp} {method} {path} : {statusCode}", string.Format("{0:u}", DateTime.Now), req.Method, req.Path, httpContext.Response.StatusCode);
        }
        if (_options.EnableErrorLogging)
        {
            _logger.LogError("{exception}", exception.ToStringDemystified());
        }
    }
}
