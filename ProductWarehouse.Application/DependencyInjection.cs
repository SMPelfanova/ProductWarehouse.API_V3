using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Behaviors;
using ProductWarehouse.Application.Profiles;

namespace ProductWarehouse.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

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
