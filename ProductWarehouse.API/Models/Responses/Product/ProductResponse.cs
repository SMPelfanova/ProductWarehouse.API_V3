using ProductWarehouse.API.Models.Responses.Group;
using ProductWarehouse.API.Models.Responses.Size;

namespace ProductWarehouse.API.Models.Responses;

public class ProductResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public Guid BrandId { get; set; }
	public string Brand { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public List<SizeResponse> Sizes { get; set; } = new List<SizeResponse>();
	public List<GroupResponse> Groups { get; set; } = new List<GroupResponse>();
}