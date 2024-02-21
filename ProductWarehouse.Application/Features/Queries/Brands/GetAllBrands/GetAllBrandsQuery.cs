using MediatR;
using ProductWarehouse.Application.Models.Brand;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
public record GetAllBrandsQuery() : IRequest<List<BrandDto>>;