using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Infrastructure.Configuration;
using ProductWarehouse.Infrastructure.Http;

namespace ProductWarehouse.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection DependencyRegistration(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MockyClientSettings>(
            config.GetSection(nameof(MockyClientSettings)));

        services.AddScoped<MockyClientService>();

        return services;
    }
}
