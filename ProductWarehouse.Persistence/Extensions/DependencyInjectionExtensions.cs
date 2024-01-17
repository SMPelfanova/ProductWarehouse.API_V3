using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Contracts;
using ProductWarehouse.Persistence.Repositories;

namespace ProductWarehouse.Persistence.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection DependencyRegistrationPersistence(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
