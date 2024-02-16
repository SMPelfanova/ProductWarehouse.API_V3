using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
	private readonly IUnitOfWork _unitOfWork;

	public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		var orderStatuses = await _unitOfWork.OrdersStatuses.GetAllAsync();
		var order = new Order
		{
			UserId = request.UserId,
			TotalAmount = request.TotalAmount,
			StatusId = orderStatuses.FirstOrDefault(x => x.Name.ToLowerInvariant() == "initial").Id,
			OrderLines = new List<OrderLine>()
		};

		var id = await _unitOfWork.Orders.Add(order);

		foreach (var item in request.OrderLines)
		{

			order.OrderLines.Add(new OrderLine
			{
				OrderId = id,
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

		await _unitOfWork.Basket.DeleteBasketLinesAsync(request.UserId);
		await _unitOfWork.SaveChangesAsync();

		return id;
	}
}