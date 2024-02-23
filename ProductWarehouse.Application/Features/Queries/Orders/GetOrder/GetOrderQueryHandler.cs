using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Order;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
	{
		var order = await _unitOfWork.Orders.GetOrderDetailsAsync(request.Id, cancellationToken);
		var result = _mapper.Map<OrderDto>(order);

		return result;
	}
}