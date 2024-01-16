using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Behaviors;
using ProductWarehouse.Application.Mapping;

namespace ProductWarehouse.Application.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection DependencyRegistration(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjectionExtensions).Assembly;

            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(assembly);
            });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
