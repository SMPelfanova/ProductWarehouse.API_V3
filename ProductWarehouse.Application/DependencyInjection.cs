using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Behaviors;
using ProductWarehouse.Application.Profiles;
using ProductWarehouse.Application.Utilities;

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

            services.AddScoped<IKeywordHighlighter, KeywordHighlighter>();
            services.AddScoped<ICommonWordsFinder, CommonWordsFinder>();

            return services;
        }
    }
}
