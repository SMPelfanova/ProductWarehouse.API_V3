using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Orders.CreateOrder;
public record CreateOrderCommand() : IRequest<OrderDto>
{
	public Guid UserId { get; set; }
	public decimal TotalAmount { get; set; }
	public List<OrderLineDto> OrderLines { get; set; }
}