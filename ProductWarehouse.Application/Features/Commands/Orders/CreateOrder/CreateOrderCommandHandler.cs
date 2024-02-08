using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            TotalAmount = request.TotalAmount,
            OrderLines = new List<OrderLine>()
        };

        var id = await _unitOfWork.Orders.Add(order);

        foreach (var item in request.OrderDetails)
        {
            order.OrderLines.Add(new OrderLine
            {
                OrderId = id,
                SizeId = item.SizeId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price
            });
            var productSize = await _unitOfWork.Products.GetProductSize(item.ProductId, item.SizeId);
            if (productSize != null)
            {
                productSize.QuantityInStock -= item.Quantity;
                _unitOfWork.Products.UpdateProductSize(productSize);
            }
        }

        //todo: delete basket and basket line
        await _unitOfWork.SaveChangesAsync();

        return id;
    }
}
