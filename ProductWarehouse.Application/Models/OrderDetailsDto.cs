namespace ProductWarehouse.Application.Models;
public class OrderDetailsDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Guid SizeId{ get; set; }
}
