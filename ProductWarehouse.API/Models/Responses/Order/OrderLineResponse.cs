namespace ProductWarehouse.API.Models.Responses.Order;

public class OrderLineResponse
{
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public Guid SizeId { get; set; }
}