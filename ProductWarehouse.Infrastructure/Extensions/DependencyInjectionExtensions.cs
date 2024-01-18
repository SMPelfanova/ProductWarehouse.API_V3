using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Infrastructure.Configuration;
using ProductWarehouse.Infrastructure.Http;

namespace ProductWarehouse.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MockyClientOptions>(
            config.GetSection(nameof(MockyClientOptions.MockyClient)));

        services.AddScoped<MockyClientService>();

        return services;
    }
}
