using Microsoft.AspNetCore.Builder;

namespace BitzArt.ApiExceptions;

public static class UseApiExceptionHandlerExtension
{
    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                await context.WriteProblemDetailsAsync();
            });
        });
    }
}
