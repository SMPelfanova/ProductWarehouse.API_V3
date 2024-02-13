using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.EF.Repositories;

namespace ProductWarehouse.Persistence.EF.Extensions;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPersistenceEF(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("WerehouseSQLDBConnectionString")),
			ServiceLifetime.Scoped);
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IGroupRepository, GroupRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IBasketRepository, BasketRepository>();
		services.AddScoped<IBasketLineRepository, BasketLineRepository>();
		services.AddScoped<IBrandRepository, BrandRepository>();
		services.AddScoped<ISizeRepository, SizeRepository>();
		services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IProductSizeRepository, ProductSizeRepository>();

		return services;
	}
}