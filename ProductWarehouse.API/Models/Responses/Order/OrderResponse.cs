using ProductWarehouse.Application.Models;

namespace ProductWarehouse.API.Models.Responses.Order;

public class OrderResponse
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public OrderStatusResponse Status { get; set; }
	public decimal TotalAmount { get; set; }
	public DateTime OrderDate { get; set; }
	public List<OrderLineResponse> OrderLines { get; set; }
}