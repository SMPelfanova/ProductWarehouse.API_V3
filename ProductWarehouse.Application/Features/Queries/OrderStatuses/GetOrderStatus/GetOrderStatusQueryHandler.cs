using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.Order;

namespace ProductWarehouse.Application.Features.Queries.OrderStatuses;

public class GetOrderStatusQueryHandler : IRequestHandler<GetOrderStatusQuery, OrderStatusDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public GetOrderStatusQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<OrderStatusDto> Handle(GetOrderStatusQuery request, CancellationToken cancellationToken)
	{
		var orderStatus = await _unitOfWork.OrdersStatuses.GetByIdAsync(request.Id);
		var result = _mapper.Map<OrderStatusDto>(orderStatus);

		return result;
	}
}