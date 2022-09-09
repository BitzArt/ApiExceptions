using Microsoft.AspNetCore.Builder;

namespace BitzArt.ApiExceptions.AspNetCore;

public static class UseApiExceptionHandlerExtension
{
    public static void UseApiExceptionHandler(this IApplicationBuilder app)
        => app.UseApiExceptionHandler<ApiExceptionHandler>();

    public static void UseApiExceptionHandler<THandler>(this IApplicationBuilder app)
        where THandler : IApiExceptionHandler
    {
        app.UseMiddleware<ApiExceptionHandlingMiddleware<THandler>>();
    }
}
