namespace ProductWarehouse.Domain.Entities;

public class OrderLine
{
	public Guid Id { get; set; }
	public Order Orders { get; set; }
	public Guid OrderId { get; set; }
	public Product Product { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public Size Size { get; set; }
	public Guid SizeId { get; set; }
}