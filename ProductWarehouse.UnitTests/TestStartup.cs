using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProductWarehouse.API.Mapping;

namespace ProductWarehouse.UnitTests;

public class TestStartup
{
    public static IMapper CreateMapper()
    {
        var services = new ServiceCollection();

        services.AddAutoMapper(typeof(AutoMapperProfile), typeof(Application.Mapping.AutoMapperProfile));

        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider.GetRequiredService<IMapper>();
    }
}