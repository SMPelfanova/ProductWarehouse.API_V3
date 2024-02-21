using MediatR;
using ProductWarehouse.Application.Models.Group;
using ProductWarehouse.Application.Models.Size;

namespace ProductWarehouse.Application.Features.Commands.Products.UpdateProduct;
public record UpdateProductCommand() : IRequest
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public string Photo { get; set; } = string.Empty;
	public List<SizeDto> Sizes { get; set; }
	public List<GroupDto> Groups { get; set; }
	public Guid BrandId { get; set; }
}