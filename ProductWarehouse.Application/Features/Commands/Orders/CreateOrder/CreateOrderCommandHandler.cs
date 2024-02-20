using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models;
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
		var order = new Order
		{
			UserId = request.UserId,
			TotalAmount = request.TotalAmount,
			StatusId = orderStatuses.FirstOrDefault(x => x.Name.ToLowerInvariant() == "initial").Id,
			OrderLines = new List<OrderLine>()
		};

		var addedOrder = await _unitOfWork.Orders.Add(order);

		foreach (var item in request.OrderLines)
		{

			order.OrderLines.Add(new OrderLine
			{
				OrderId = addedOrder.Id,
				SizeId = item.SizeId,
				ProductId = item.ProductId,
				Quantity = item.Quantity,
				Price = item.Price
			});
			var productSize = await _unitOfWork.Products.GetProductSizeAsync(item.ProductId, item.SizeId);
			if (productSize != null)
			{
				productSize.QuantityInStock -= item.Quantity;
				_unitOfWork.Products.UpdateProductSize(productSize);
			}
		}

		_unitOfWork.Basket.DeleteBasketLines(request.UserId);
		await _unitOfWork.SaveChangesAsync();

		var orderDto = _mapper.Map<OrderDto>(order);

		return orderDto;
	}
}