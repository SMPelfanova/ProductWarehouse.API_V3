using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Size;

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
		var sizes = await _unitOfWork.Sizes.GetAllAsync(cancellationToken);
		var result = _mapper.Map<List<SizeDto>>(sizes);

		return result;
	}
}