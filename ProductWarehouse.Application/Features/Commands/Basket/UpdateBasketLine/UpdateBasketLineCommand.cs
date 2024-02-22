using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
public record UpdateBasketLineCommand() : IRequest<BasketLineDto>
{
	public Guid UserId { get; set; }
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public Guid SizeId { get; set; }
}