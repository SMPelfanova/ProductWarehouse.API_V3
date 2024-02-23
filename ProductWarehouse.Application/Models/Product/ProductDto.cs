using ProductWarehouse.Application.Models.Group;
using ProductWarehouse.Application.Models.Size;

namespace ProductWarehouse.Application.Models.Product;

public class ProductDto
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public decimal Price { get; set; }
	public Guid BrandId { get; set; }
	public string Brand { get; set; }
	public string Photo { get; set; }
	public string Description { get; set; }
	public List<SizeDto> Sizes { get; set; }
	public List<GroupDto> Groups { get; set; }
}