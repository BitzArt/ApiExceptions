using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BitzArt.ApiExceptions.AspNetCore;

public class ApiExceptionHandler : IApiExceptionHandler
{
    private readonly ApiExceptionHandlerOptions _options;
    private readonly HttpContext _httpContext;

    public ApiExceptionHandler(ApiExceptionHandlerOptions options, IHttpContextAccessor contextAccessor)
    {
        _options = options;
        _httpContext = contextAccessor.HttpContext!;
    }

    public virtual async Task HandleAsync(Exception exception)
    {
        _httpContext.Response.ContentType = "application/problem+json";

        var problem = GetProblemDetails(exception);
        await _httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }

    private ProblemDetails GetProblemDetails(Exception exception)
    {
        if (exception is ApiExceptionBase apiException) return GetProblemDetails(apiException);

        _httpContext.Response.StatusCode = 500;
        return new ProblemDetails(exception);
    }

    private ProblemDetails GetProblemDetails(ApiExceptionBase apiException)
    {
        _httpContext.Response.StatusCode = apiException.StatusCode;

        var defaultErrorType = GetDefaultErrorType(apiException);
        if (defaultErrorType is not null) apiException.Payload.SetErrorType(defaultErrorType);

        return new ProblemDetails(apiException);
    }

    private string? GetDefaultErrorType(ApiExceptionBase apiException)
    {
        if (apiException.Payload.GetErrorType() is not null) return null;

        var useDefaultTypeValue = GetUseDefaultTypeValue(apiException);
        if (!useDefaultTypeValue) return null;

        var link = $"{Config.DocumentationLink}/{apiException.StatusCode}";
        return link;
    }

    private bool GetUseDefaultTypeValue(ApiExceptionBase apiException)
    {
        if (_options.DisableDefaultTypeValues) return false;

        var value = apiException.Payload
            .GetConfigurationEntry<bool?>(Config.UseDefaultErrorTypeKey);

        if (value is null) return true;

        return value.Value;
    }
}
