using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProductSize;
public record UpdateProductSizeCommand : IRequest
{
	public Guid ProductId { get; set; }
	public Guid SizeId { get; set; }
	public int QuantityInStock { get; set; }
}