namespace ProductWarehouse.API.Models.Responses;

public class FilterResponse
{
	public decimal MinPrice { get; set; }
	public decimal MaxPrice { get; set; }
	public IEnumerable<string> Sizes { get; set; } = Enumerable.Empty<string>();
	public IEnumerable<string> CommonWords { get; set; } = Enumerable.Empty<string>();
}