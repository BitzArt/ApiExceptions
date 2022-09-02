using Microsoft.AspNetCore.Http;

namespace BitzArt.ApiExceptions.AspNetCore;

public class ApiExceptionHandlingMiddleware<THandler>
    where THandler : IApiExceptionHandler
{
    private readonly RequestDelegate _next;

    public ApiExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public virtual async Task InvokeAsync(HttpContext context, THandler handler)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await handler.HandleAsync(exception);
        }
    }
}
