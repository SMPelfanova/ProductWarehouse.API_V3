using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Basket.UpdateBasketLine;
public record UpdateBasketLineCommand() : IRequest<Guid>
{
	public Guid UserId { get; set; }
	public Guid Id { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public Guid SizeId { get; set; }
}