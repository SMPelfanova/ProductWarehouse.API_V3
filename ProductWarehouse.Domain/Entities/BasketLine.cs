namespace ProductWarehouse.Domain.Entities;

public class BasketLine : Entity
{
    public Baskets Basket { get; set; }
    public Guid BasketId { get; set; }
    public Product Product { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Size Size { get; set; }
    public Guid SizeId { get; set; }
}