namespace ProductWarehouse.API.Models.Requests;

public class UpdateOrderRequest
{
	public Guid Id { get; set; }
	public Guid StatusId { get; set; }
	public decimal TotalAmount { get; set; }
}