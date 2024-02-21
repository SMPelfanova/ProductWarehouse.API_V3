namespace ProductWarehouse.Application.Features.Commands.Orders.PartialUpdate;

public class PartialUpdateOrderCommandRequest
{
	public Guid Id { get; set; }
	public Guid? StatusId { get; set; }
	public decimal? TotalAmount { get; set; }
}