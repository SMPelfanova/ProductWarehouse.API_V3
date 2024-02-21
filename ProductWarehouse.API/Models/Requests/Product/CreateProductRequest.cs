using ProductWarehouse.API.Models.Requests.Product.Group;

namespace ProductWarehouse.API.Models.Requests;

public class CreateProductRequest
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string? Photo { get; set; }
	public decimal Price { get; set; }
	public Guid BrandId { get; set; }
	public List<SizeRequest> Sizes { get; set; }
	public List<ProductGroupRequest> Groups { get; set; }
}