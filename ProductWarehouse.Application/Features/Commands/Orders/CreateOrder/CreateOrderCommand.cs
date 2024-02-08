using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
public record CreateOrderCommand() : IRequest<Guid>
{
    public decimal TotalAmount { get; set; }
    public List<OrderLineDto> OrderDetails { get; set; }
}
