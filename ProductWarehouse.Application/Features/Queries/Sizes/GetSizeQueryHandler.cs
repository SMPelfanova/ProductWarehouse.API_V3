using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;
public class GetSizeQueryHandler : IRequestHandler<GetSizeQuery, SizeDto>
{
    private readonly ISizeRepository _sizeRepository;
    private readonly IMapper _mapper;

    public GetSizeQueryHandler(ISizeRepository sizeRepository, IMapper mapper)
    {
        _sizeRepository = sizeRepository;
        _mapper = mapper;
    }

    public async Task<SizeDto> Handle(GetSizeQuery request, CancellationToken cancellationToken)
    {
        var result = await _sizeRepository.GetAllAsync();
        var mapper = _mapper.Map<SizeDto>(result);

        return mapper;
    }
}