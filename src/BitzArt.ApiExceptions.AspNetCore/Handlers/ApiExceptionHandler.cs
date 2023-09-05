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
        var problem = exception.GetProblemDetails(_httpContext, _options);
        await _httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));

        if (_options.EnableRequestLogging)
        {
            var req = _httpContext.Request;
            _logger.LogInformation("{timestamp} {method} {path} : {statusCode}", string.Format("{0:u}", DateTime.Now), req.Method, req.Path, _httpContext.Response.StatusCode);
        }
        if (_options.EnableErrorLogging)
        {
            _logger.LogError("{exception}", exception.ToStringDemystified());
        }
    }
}
