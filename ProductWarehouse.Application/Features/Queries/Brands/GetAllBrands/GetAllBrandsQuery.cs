using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
public record GetAllBrandsQuery() : IRequest<List<BrandDto>>;