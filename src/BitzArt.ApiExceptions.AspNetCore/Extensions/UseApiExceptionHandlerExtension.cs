using Microsoft.AspNetCore.Builder;

namespace BitzArt.ApiExceptions.AspNetCore;

public static class UseApiExceptionHandlerExtension
{
    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}
