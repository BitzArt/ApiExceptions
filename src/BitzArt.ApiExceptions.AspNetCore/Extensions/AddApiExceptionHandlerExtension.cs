using Microsoft.Extensions.DependencyInjection;

namespace BitzArt.ApiExceptions.AspNetCore;

public static class AddApiExceptionHandlerExtension
{
    public static IServiceCollection AddApiExceptionHandler
        (this IServiceCollection services, Action<ApiExceptionHandlerOptions>? options = null)
    {
        services.AddHttpContextAccessor();

        ApiExceptionHandlerOptions option = new();
        options?.Invoke(option);
        services.AddSingleton(option);

        services.AddScoped<ApiExceptionHandler>();

        return services;
    }
}
