using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Persistence.EF.Extensions;
public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistenceEF(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("WerehouseSQLDBConnectionString")));


        return services;
    }
}
