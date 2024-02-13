namespace ProductWarehouse.Application.Models;

public class SizeDto
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public int QuantityInStock { get; set; }
}