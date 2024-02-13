namespace ProductWarehouse.API.Models.Requests;

public class UpdateProductRequest
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public string? Photo { get; set; }
}