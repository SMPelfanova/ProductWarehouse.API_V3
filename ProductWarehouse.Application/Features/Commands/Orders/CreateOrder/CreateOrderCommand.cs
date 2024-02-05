using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
public record CreateOrderCommand() : IRequest<Guid>
{
    public Guid StatusId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderDetailsDto> OrderDetails { get; set; }
}
