using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;
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
                    context.Response.ContentType = "application/json";
                    if (contextFeature is not null)
                    {
                        if (contextFeature.Error is ApiException apiException)
                        {
                            context.Response.StatusCode = apiException.StatusCode;
                            var problem = new ProblemDetailsViewModel(apiException);
                            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
                        }
                        else
                        {
                            var problem = new ProblemDetailsViewModel(contextFeature.Error);
                            await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
                        }
                    }
                });
            });
        }
    }
}
