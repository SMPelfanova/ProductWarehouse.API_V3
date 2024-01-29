using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Brands.GetBrand;
public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandDto>
{
    private readonly IBrandRepository _brandRepository;
    private readonly IMapper _mapper;

    public GetBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }

    public async Task<BrandDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
    {
        var result = await _brandRepository.GetByIdAsync(request.Id);
        var mapper = _mapper.Map<BrandDto>(result);

        return mapper;
    }
}