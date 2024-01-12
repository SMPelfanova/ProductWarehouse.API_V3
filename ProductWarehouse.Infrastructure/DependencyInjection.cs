using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Domain.Repositories;
using ProductWarehouse.Infrastructure.Configuration;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Infrastructure.Repositories;

namespace ProductWarehouse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            services.Configure<ProductSourceSettings>(
                config.GetSection(nameof(ProductSourceSettings)));

            services.AddScoped<HttpClientService>();

            return services;
        }
    }
}
