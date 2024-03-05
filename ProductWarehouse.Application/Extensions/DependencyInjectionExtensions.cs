using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Behaviors;
using ProductWarehouse.Application.Features.Commands.Products;
using ProductWarehouse.Application.Features.Commands.Products.CreateProduct;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Mapping;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Persistence.Abstractions.Exceptions;

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

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingPipelineBehavior<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
		services.AddTransient<IRequestExceptionHandler<CreateProductCommand, ProductDto, DatabaseException>, CreateProductCommandExceptionHandler>();

		services.AddAutoMapper(typeof(AutoMapperProfile));

		return services;
	}
}