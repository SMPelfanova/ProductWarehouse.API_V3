using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Size;

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
		var size = await _unitOfWork.Sizes.GetByIdAsync(request.Id);
		var result = _mapper.Map<SizeDto>(size);

		return result;
	}
}