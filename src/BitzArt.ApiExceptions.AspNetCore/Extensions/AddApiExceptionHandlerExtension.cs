using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.ApiExceptions.AspNetCore;

public static class AddApiExceptionHandlerExtension
{
    public static IServiceCollection AddApiExceptionHandler
        (this IServiceCollection services, Action<ApiExceptionHandlerOptions>? configure = null)
        => services.AddApiExceptionHandler<ApiExceptionHandler>(configure);

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
