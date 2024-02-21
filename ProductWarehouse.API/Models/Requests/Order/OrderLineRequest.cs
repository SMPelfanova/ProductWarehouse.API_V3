namespace ProductWarehouse.API.Models.Requests.Order;

public class OrderLineRequest
{
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public decimal Price { get; set; }
	public Guid SizeId { get; set; }
}