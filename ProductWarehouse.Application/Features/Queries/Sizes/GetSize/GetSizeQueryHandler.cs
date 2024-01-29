using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Sizes;
public class GetSizeQueryHandler : IRequestHandler<GetSizeQuery, SizeDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSizeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SizeDto> Handle(GetSizeQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Sizes.GetByIdAsync(request.Id);
        var mapper = _mapper.Map<SizeDto>(result);

        return mapper;
    }
}