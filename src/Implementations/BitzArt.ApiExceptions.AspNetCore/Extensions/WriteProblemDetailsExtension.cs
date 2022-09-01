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
        if (problem.ErrorType is not null) return;
        var useDefaultTypeValue = GetUseDefaultTypeValue(problem, apiException);
        if (useDefaultTypeValue)
        {
            var link = $"{Config.DocumentationLink}/{apiException.StatusCode}";
            problem.ErrorType = link;
        }
    }

    private static bool GetUseDefaultTypeValue(ProblemDetails problem, ApiExceptionBase apiException)
    {
        var result = apiException.Payload.GetConfigurationEntry<bool?>(Config.UseDefaultErrorTypeKey);
        if (result is null) return true;
        return result.Value;
    }
}
