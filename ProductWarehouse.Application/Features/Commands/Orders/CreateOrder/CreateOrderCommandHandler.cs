using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Application.Models.Order;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		var orderStatuses = await _unitOfWork.OrdersStatuses.GetAllAsync(cancellationToken);
		if (orderStatuses != null && orderStatuses.Any())
		{
			request.StatusId = orderStatuses.FirstOrDefault(x => x.Name.ToLowerInvariant() == "initial").Id;
		}

		foreach (var item in request.OrderLines)
		{
			await UpdateQuantityInStockAsync(item, cancellationToken);
		}

		var order = _mapper.Map<Order>(request);
		var addedOrder = await _unitOfWork.Orders.AddAsync(order, cancellationToken);

		await _unitOfWork.Basket.DeleteBasketLinesAsync(request.UserId, cancellationToken);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		var orderDto = _mapper.Map<OrderDto>(addedOrder);

		return orderDto;
	}

	private async Task UpdateQuantityInStockAsync(OrderLineDto orderLine, CancellationToken cancellationToken)
	{
		var productSize = await _unitOfWork.Products.GetProductSizeAsync(orderLine.ProductId, orderLine.SizeId, cancellationToken);
		if (productSize != null)
		{
			productSize.QuantityInStock -= orderLine.Quantity;
			await _unitOfWork.Products.UpdateQuantityInStockAsync(productSize, cancellationToken);
		}
	}
}