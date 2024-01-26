using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Orders.AddOrder;
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateOrderCommandHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.Add(new Order
        {
            Status = new OrderStatus() { Id = request.StatusId },
            OrderDate = request.OrderDate,
            TotalAmount = request.TotalAmount,
            OrderDetails = _mapper.Map<List<OrderDetails>>(request.OrderDetails)
        });
        await _unitOfWork.SaveChangesAsync();
    }
}
