using Microsoft.AspNetCore.Builder;

namespace BitzArt.ApiExceptions.AspNetCore;

/// <summary>
/// Contains extension methods for adding the API exception handler middleware.
/// </summary>
public static class UseApiExceptionHandlerExtension
{
    /// <summary>
    /// Configures the middleware to handle exceptions and return a problem details response.
    /// </summary>
    /// <param name="app"></param>
    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ApiExceptionHandlingMiddleware>();
    }
}
