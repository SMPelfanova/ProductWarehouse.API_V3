using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Infrastructure.Configuration;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Infrastructure.Interfaces;
using ProductWarehouse.Infrastructure.Repositories;

namespace ProductWarehouse.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection DependencyRegistration(this IServiceCollection services, IConfiguration config)
    {
        services.AddTransient<IProductRepository, ProductRepository>();

        services.Configure<MockyClientSettings>(
            config.GetSection(nameof(MockyClientSettings)));

        services.AddScoped<HttpClientService>();

        return services;
    }
}
