using AutoMapper;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
