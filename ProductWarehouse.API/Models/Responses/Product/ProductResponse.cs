using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Models.Responses;

public class ProductResponse
{
	public Guid Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Brand { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public List<SizeDto> Sizes { get; set; } = new List<SizeDto>();
	public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
}