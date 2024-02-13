namespace ProductWarehouse.Domain.Entities;

public class Payment : Entity
{
	public string Method { get; set; }
	public string Status { get; set; }
	public DateTime PaymentDate { get; set; }
	public Order Order { get; set; }
}