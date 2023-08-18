using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace BitzArt.ApiExceptions.AspNetCore;

public class ApiExceptionHandler : IApiExceptionHandler
{
    private readonly ApiExceptionHandlerOptions _options;
    private readonly HttpContext _httpContext;
    private readonly ILogger _logger;

    public ApiExceptionHandler(
        ApiExceptionHandlerOptions options,
        IHttpContextAccessor contextAccessor,
        ILogger<IApiExceptionHandler> logger)
    {
        _options = options;
        _httpContext = contextAccessor.HttpContext!;
        _logger = logger;
    }

    public virtual async Task HandleAsync(Exception exception)
    {
        _httpContext.Response.ContentType = "application/problem+json";

        var problem = GetProblemDetails(exception);
        await _httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));

        if (_options.EnableRequestLogging)
        {
            var req = _httpContext.Request;
            _logger.LogInformation("{timestamp} {method} {path} : {statusCode}", string.Format("{0:u}", DateTime.Now), req.Method, req.Path, _httpContext.Response.StatusCode);
            if (_options.EnableErrorLogging)
            {
                _logger.LogError("{exception}", exception.ToStringDemystified());
            }
        }
    }

    private ProblemDetails GetProblemDetails(Exception exception)
    {
        if (exception is ApiExceptionBase apiException) return GetProblemDetails(apiException);

        _httpContext.Response.StatusCode = 500;
        return new ProblemDetails(exception, addInner: _options.AddInnerExceptions);
    }

    private ProblemDetails GetProblemDetails(ApiExceptionBase apiException)
    {
        _httpContext.Response.StatusCode = apiException.StatusCode;

        var defaultErrorType = GetDefaultErrorType(apiException);
        if (defaultErrorType is not null) apiException.ErrorType = defaultErrorType;

        return new ProblemDetails(apiException);
    }

    private string? GetDefaultErrorType(ApiExceptionBase apiException)
    {
        if (apiException.ErrorType is not null) return null;

        var useDefaultTypeValue = GetUseDefaultTypeValue(apiException);
        if (!useDefaultTypeValue) return null;

        var link = $"{Config.DocumentationLink}/{apiException.StatusCode}";
        return link;
    }

    private bool GetUseDefaultTypeValue(ApiExceptionBase apiException)
    {
        if (_options.DisableDefaultTypeValues) return false;

        var value = apiException.UseDefaultErrorTypeValue;

        if (value is null) return true;

        return value.Value;
    }
}
