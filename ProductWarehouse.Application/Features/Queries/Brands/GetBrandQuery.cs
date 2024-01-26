using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Brands;

public record GetBrandQuery(Guid Id) : IRequest<BrandDto>;