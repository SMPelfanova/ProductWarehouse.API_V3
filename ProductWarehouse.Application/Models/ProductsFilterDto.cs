namespace ProductWarehouse.Application.Models;

public class ProductsFilterDto
{
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public List<string> Sizes { get; set; }
    public IEnumerable<string> CommonWords { get; set; } = Enumerable.Empty<string>();
    public List<ProductDto> Products { get; set; }
}
