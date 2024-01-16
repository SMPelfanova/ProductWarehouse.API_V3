namespace ProductWarehouse.Application.Models;

public class ProductDto
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> Sizes { get; set; } = new List<string>();
    public string Description { get; set; } = string.Empty;
}
