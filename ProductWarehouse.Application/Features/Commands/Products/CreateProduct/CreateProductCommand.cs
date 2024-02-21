using MediatR;
using ProductWarehouse.Application.Models.Group;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.Application.Models.Size;

namespace ProductWarehouse.Application.Features.Commands.Products;
public record CreateProductCommand : IRequest<ProductDto>
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string Photo { get; set; }
	public List<SizeDto> Sizes { get; set; }
	public List<GroupDto> Groups { get; set; }
	public Guid BrandId { get; set; }
	public decimal Price { get; set; }
}