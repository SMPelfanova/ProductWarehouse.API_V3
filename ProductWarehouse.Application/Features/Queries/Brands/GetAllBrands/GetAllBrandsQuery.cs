using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetAllBrands;
public class GetAllBrandsQuery() : IRequest<List<BrandDto>>;
