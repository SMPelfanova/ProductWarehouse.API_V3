using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using Serilog;

namespace ProductWarehouse.Application.Features.Queries.Orders.GetOrder;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ILogger _logger;

	public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
	{
		var order = await _unitOfWork.Orders.GetOrderDetailsAsync(request.Id);
		if (order == null)
		{
			_logger.Warning($"Order with id {request.Id} not found.");
			return null;
		}
		var result = _mapper.Map<OrderDto>(order);

		return result;
	}
}