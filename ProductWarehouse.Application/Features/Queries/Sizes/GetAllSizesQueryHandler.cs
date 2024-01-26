using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Features.Queries.Brands;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;

public class GetAllSizesQueryHandler : IRequestHandler<GetAllSizesQuery, List<SizeDto>>
{
    private readonly ISizeRepository _sizeRepository;
    private readonly IMapper _mapper;

    public GetAllSizesQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
    {
        _sizeRepository = sizeRepository;
        _mapper = mapper;
    }

    public async Task<List<SizeDto>> Handle(GetAllSizesQuery request, CancellationToken cancellationToken)
    {
        var result = await _sizeRepository.GetAllAsync();
        var mapper = _mapper.Map<List<SizeDto>>(result);

        return mapper;
    }
}
