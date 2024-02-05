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
        var status = await _unitOfWork.OrdersStatuses.GetByIdAsync(request.StatusId);
        if (status == null)
        {
            throw new ArgumentNullException(nameof(status));
        }

        var order = new Order
        {
            StatusId = request.StatusId,
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
            OrderDetails = new List<OrderDetails>()
        };
        var id = await _unitOfWork.Orders.Add(order);

        foreach (var item in request.OrderDetails)
        {
            order.OrderDetails.Add(new OrderDetails
            {
                OrderId = id,
                SizeId = item.SizeId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = item.Price
            });
        }
        
        await _unitOfWork.SaveChangesAsync();

        return id;
    }
}
