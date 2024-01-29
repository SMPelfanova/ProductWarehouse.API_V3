using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Orders.UpdateOrder;
public class UpdateOrderCommand : IRequest
{
    public Guid OrderId { get; set; }
}