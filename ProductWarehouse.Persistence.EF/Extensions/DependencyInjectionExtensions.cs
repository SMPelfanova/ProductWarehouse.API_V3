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
        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test"))
        //    .AddOptions();

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
