using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Products.DeleteProductSize;
public record DeleteProductSizeCommand : IRequest
{
	public Guid ProductId { get; set; }
	public Guid SizeId { get; set; }
}