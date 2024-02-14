using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductSizeCommand() : IRequest<Guid>
{
	public Guid ProductId { get; set; }
	public Guid SizeId { get; set; }
	public int QuantityInStock { get; set; }
}