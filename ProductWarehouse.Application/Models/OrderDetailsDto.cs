namespace ProductWarehouse.Application.Models;
public class OrderDetailsDto
{
    public Guid OrderId { get; set; }
    public ProductDto Product { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string SizeName { get; set; }
}
