using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;

public class GetAllSizesQueryHandler : IRequestHandler<GetAllSizesQuery, List<SizeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllSizesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<SizeDto>> Handle(GetAllSizesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Sizes.GetAllAsync();
        var mapper = _mapper.Map<List<SizeDto>>(result);

        return mapper;
    }
}
