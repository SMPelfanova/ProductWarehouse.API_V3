using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetBrand;

public record GetBrandQuery(Guid Id) : IRequest<BrandDto>;