using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Behaviors;
using ProductWarehouse.Application.Mapping;

namespace ProductWarehouse.Application.Extensions;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		var assembly = typeof(DependencyInjectionExtensions).Assembly;
		services.AddValidatorsFromAssembly(assembly);

		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssembly(assembly);
			configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
		});

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

		services.AddAutoMapper(typeof(AutoMapperProfile));

		return services;
	}
}