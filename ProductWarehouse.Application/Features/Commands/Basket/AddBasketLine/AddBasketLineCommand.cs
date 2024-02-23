using MediatR;
using ProductWarehouse.Application.Models;

namespace ProductWarehouse.Application.Features.Commands.Basket.AddBasketLine;
public record AddBasketLineCommand() : IRequest<BasketLineDto>
{
	public Guid UserId { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public Guid SizeId { get; set; }
}