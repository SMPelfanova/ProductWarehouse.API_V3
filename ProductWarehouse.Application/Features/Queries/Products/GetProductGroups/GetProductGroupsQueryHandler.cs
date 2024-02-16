using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Queries.Products.GetProductGroups;

public class GetProductGroupsQueryHandler : IRequestHandler<GetProductGroupsQuery, List<GroupDto>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetProductGroupsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<List<GroupDto>> Handle(GetProductGroupsQuery request, CancellationToken cancellationToken)
	{
		var product = await _unitOfWork.Products.GetProductDetailsAsync(request.Id);

		var result = _mapper.Map<List<GroupDto>>(product.ProductGroups);

		return result;
	}
}