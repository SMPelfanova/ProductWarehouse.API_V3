using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.PostgreSQL.Repositories;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Extensions;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddPersistencePostgreSql(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.EnableSensitiveDataLogging();
			options.UseNpgsql(configuration.GetConnectionString("WerehouseNpgsqlDbConnectionString"));
		});

		services.AddScoped<IDbConnection>(provider =>
		{
			var connectionString = configuration.GetConnectionString("WerehouseNpgsqlDbConnectionString");
			return new NpgsqlConnection(connectionString);
		});
		
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