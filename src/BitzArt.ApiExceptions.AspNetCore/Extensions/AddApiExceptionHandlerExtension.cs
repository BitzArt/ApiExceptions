using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.ApiExceptions.AspNetCore;

/// <summary>
/// Contains extension methods for adding the API exception handler to the service collection.
/// </summary>
public static class AddApiExceptionHandlerExtension
{
    /// <summary>
    /// Adds the API exception handler and all required services to the service collection.
    /// </summary>
    public static IServiceCollection AddApiExceptionHandler
        (this IServiceCollection services, Action<ApiExceptionHandlerOptions>? configure = null)
        => services.AddApiExceptionHandler<ApiExceptionHandler>(configure);

    /// <summary>
    /// Adds a custom API exception handler and all required services to the service collection.
    /// </summary>
    public static IServiceCollection AddApiExceptionHandler<THandler>
        (this IServiceCollection services, Action<ApiExceptionHandlerOptions>? configure = null)
        where THandler : class, IApiExceptionHandler
    {
        services.AddHttpContextAccessor();

        ApiExceptionHandlerOptions options = new();
        configure?.Invoke(options);
        services.AddSingleton(options);

        services.AddScoped<IApiExceptionHandler, THandler>();

        return services;
    }
}
