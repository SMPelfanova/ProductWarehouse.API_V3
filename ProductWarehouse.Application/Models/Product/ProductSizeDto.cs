using ProductWarehouse.Application.Models.Size;

namespace ProductWarehouse.Application.Models.Product;

public class ProductSizeDto
{
    public Guid ProductId { get; set; }
    public SizeDto Size { get; set; }
    public Guid SizeId { get; set; }
    public int QuantityInStock { get; set; }
}