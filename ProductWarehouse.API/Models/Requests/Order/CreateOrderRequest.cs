namespace ProductWarehouse.API.Models.Requests.Order;

public class CreateOrderRequest
{
	public Guid UserId { get; set; }
	public decimal TotalAmount { get; set; }
	public List<OrderLineRequest> OrderLines { get; set; }
}