using Microsoft.Extensions.DependencyInjection;

namespace Blazor.NativeDOM.Extensions;

public static class NativeDOMExtensions
{
    public static IServiceCollection AddNativeDOM(this IServiceCollection services)
    {
        services.AddScoped<API.NativeDOM>();
        services.AddScoped<ExampleJsInterop>();
        return services;
    }
}