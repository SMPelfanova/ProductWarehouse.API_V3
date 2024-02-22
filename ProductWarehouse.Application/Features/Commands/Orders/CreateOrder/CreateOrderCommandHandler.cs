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
		var orderStatuses = await _unitOfWork.OrdersStatuses.GetAllAsync();
		if (orderStatuses != null && orderStatuses.Any())
		{
			request.StatusId = orderStatuses.FirstOrDefault(x => x.Name.ToLowerInvariant() == "initial").Id;
		}

		foreach (var item in request.OrderLines)
		{
			await UpdateQuantityInStockAsync(item);
		}

		var order = _mapper.Map<Order>(request);
		var addedOrder = await _unitOfWork.Orders.Add(order);

		_unitOfWork.Basket.DeleteBasketLines(request.UserId);
		await _unitOfWork.SaveChangesAsync();

		var orderDto = _mapper.Map<OrderDto>(addedOrder);

		return orderDto;
	}

	private async Task UpdateQuantityInStockAsync(OrderLineDto orderLine)
	{
		var productSize = await _unitOfWork.Products.GetProductSizeAsync(orderLine.ProductId, orderLine.SizeId);
		if (productSize != null)
		{
			productSize.QuantityInStock -= orderLine.Quantity;
			_unitOfWork.Products.UpdateQuantityInStock(productSize);
		}
	}
}