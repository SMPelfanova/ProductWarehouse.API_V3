using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Persistence.Extensions;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}