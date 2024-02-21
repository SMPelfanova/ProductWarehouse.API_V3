namespace ProductWarehouse.API.Models.Requests.Product.Size;

public class CreateProductSizeRequest
{
	public Guid Id { get; set; }
	public Guid SizeId { get; set; }
	public int QuantityInStock { get; set; }
}