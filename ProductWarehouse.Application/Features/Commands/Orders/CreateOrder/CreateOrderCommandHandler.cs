using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Status = new OrderStatus() { Id = request.StatusId },
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
            OrderDetails = _mapper.Map<List<OrderDetails>>(request.OrderDetails)
        };

        await _unitOfWork.Orders.Add(order);

        await _unitOfWork.SaveChangesAsync();
    }
}
