using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace BitzArt.ApiExceptions.AspNetCore;

/// <summary>
/// Default <see cref="IApiExceptionHandler"/> implementation.
/// </summary>
public class ApiExceptionHandler : IApiExceptionHandler
{
    private readonly ApiExceptionHandlerOptions _options;
    private readonly HttpContext _httpContext;
    private readonly ILogger _requestLogger;
    private readonly ILogger _exceptionLogger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ApiExceptionHandler"/> class.
    /// </summary>
    public ApiExceptionHandler(
        ApiExceptionHandlerOptions options,
        IHttpContextAccessor contextAccessor,
        ILoggerFactory loggerFactory)
    {
        _options = options;
        _httpContext = contextAccessor.HttpContext!;
        _requestLogger = loggerFactory.CreateLogger("Request");
        _exceptionLogger = loggerFactory.CreateLogger("ExceptionHandler");
    }

    /// <summary>
    /// Handles the exception and returns a problem details response.
    /// </summary>
    public virtual async Task HandleAsync(Exception exception)
    {
        var problem = exception.GetProblemDetails(_httpContext, _options);

        if (!_options.DisableDefaultProblemDetailsStatusValue)
        {
            problem.Status ??= _httpContext.Response.StatusCode;
        }

        await _httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));

        if (_options.LogRequests)
        {
            var req = _httpContext.Request;
            _requestLogger.LogInformation("{timestamp} {method} {path} : {statusCode}", string.Format("{0:u}", DateTime.Now), req.Method, req.Path, _httpContext.Response.StatusCode);
        }

        LogException(exception);
    }

    private void LogException(Exception exception)
    {
        if (!_options.LogExceptions)
        {
            return;
        }

        if (_options.DemoteUserErrors
            && exception is ApiExceptionBase apiException
            && apiException.StatusCode >= 400
            && apiException.StatusCode < 500)
        {
            _exceptionLogger.LogWarning("{exception}", exception.ToStringDemystified());
            return;
        }

        _exceptionLogger.LogError(exception, "{exception}", exception.ToStringDemystified());
    }
}
