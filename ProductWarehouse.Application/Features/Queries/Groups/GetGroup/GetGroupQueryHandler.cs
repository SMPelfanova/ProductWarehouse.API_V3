using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Groups.GetGroup;

public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, GroupDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetGroupQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<GroupDto> Handle(GetGroupQuery request, CancellationToken cancellationToken)
	{
		var group = await _unitOfWork.Group.GetByIdAsync(request.Id);
		var result = _mapper.Map<GroupDto>(group);

		return result;
	}
}