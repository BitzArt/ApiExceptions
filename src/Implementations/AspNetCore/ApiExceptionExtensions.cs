using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BitzArt.ApiExceptions
{
    public static class ApiExceptionExtensions
    {
        public static void ConfigureApiExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = HttpStatusCode.InternalServerError;
                    if (contextFeature.Error is ApiException apiException)
                    {
                        statusCode = apiException.StatusCode;
                    }
                    context.Response.StatusCode = (int)statusCode;
                    context.Response.ContentType = "application/json";
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(contextFeature.Error.Message);
                    }
                });
            });
        }
    }
}
