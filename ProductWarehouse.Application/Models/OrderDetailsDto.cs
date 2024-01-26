using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Models;
public class OrderDetailsDto
{
    public Order Orders { get; set; }
    public Guid OrderId { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Size Size { get; set; }
    public Guid SizeId { get; set; }
}
