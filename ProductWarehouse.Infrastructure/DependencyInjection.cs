using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Domain.Repositories;
using ProductWarehouse.Infrastructure.Data;
using ProductWarehouse.Infrastructure.Repositories;

namespace ProductWarehouse.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ProductDbContext>();

            return services;
        }
    }
}
