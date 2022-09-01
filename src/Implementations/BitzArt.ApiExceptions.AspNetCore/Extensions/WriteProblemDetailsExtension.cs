using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BitzArt.ApiExceptions;

public static class WriteProblemDetailsExtension
{
    public static async Task WriteProblemDetailsAsync(this HttpContext context)
    {
        var handlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (handlerFeature is null) return;

        context.Response.ContentType = "application/problem+json";

        ProblemDetails problem;

        if (handlerFeature.Error is ApiExceptionBase apiException)
        {
            context.Response.StatusCode = apiException.StatusCode;
            problem = new ProblemDetails(apiException);
            ConfigureDefaultType(problem, apiException);
        }
        else
        {
            context.Response.StatusCode = 500;
            problem = new ProblemDetails(handlerFeature.Error);
        }

        await context.Response.WriteAsync(JsonSerializer.Serialize(problem));
    }

    private static void ConfigureDefaultType(ProblemDetails problem, ApiExceptionBase apiException)
    {
        if (problem.Data.ContainsKey(ProblemDetails.Keys.ErrorType)) return;
        var useDefaultTypeValue = GetUseDefaultTypeValue(problem, apiException);
        if (useDefaultTypeValue)
        {
            var link = $"{Config.DocumentationLink}/{apiException.StatusCode}";
            problem.Data[ProblemDetails.Keys.ErrorType] = link;
        }
    }

    private static bool GetUseDefaultTypeValue(ProblemDetails problem, ApiExceptionBase apiException)
    {
        if (!apiException.Payload.Configurations.ContainsKey(Config.UseDefaultErrorTypeKey)) return true;

        var obj = problem.Data[Config.UseDefaultErrorTypeKey];
        if (obj is null) return true;
        return (bool)obj;
    }
}
