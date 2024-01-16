using AutoMapper;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDto, ProductResponse>();
    }
}
