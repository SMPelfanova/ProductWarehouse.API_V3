using MediatR;
using ProductWarehouse.Application.Models.Product;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductSizeCommand() : IRequest<ProductSizeDto>
{
	public Guid ProductId { get; set; }
	public Guid SizeId { get; set; }
	public int QuantityInStock { get; set; }
}