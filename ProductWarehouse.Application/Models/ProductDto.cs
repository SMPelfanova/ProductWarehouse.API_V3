namespace ProductWarehouse.Application.Models;

public class ProductDto
{
    public required string Title { get; set; }
    public required decimal Price { get; set; }
    public required List<string> Sizes { get; set; }
    public required string Description { get; set; }
}
