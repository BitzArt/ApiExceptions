using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BitzArt.ApiExceptions
{
    public static class ConfigureApiExceptionHandlerExtension
    {
        public static void ConfigureApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/problem+json";
                    if (contextFeature is null) return;

                    if (contextFeature.Error is ApiExceptionBase apiException)
                    {
                        context.Response.StatusCode = (int)apiException.StatusCode;
                        var problem = new ProblemDetails(apiException);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
                    }
                    else
                    {
                        var problem = new ProblemDetails(contextFeature.Error);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
                    }
                });
            });
        }
    }
}
