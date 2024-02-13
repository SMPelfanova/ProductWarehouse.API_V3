namespace ProductWarehouse.Application.Models;
public class ProductSizeDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public SizeDto Size { get; set; }
    public Guid SizeId { get; set; }
    public int QuantityInStock { get; set; }
}
