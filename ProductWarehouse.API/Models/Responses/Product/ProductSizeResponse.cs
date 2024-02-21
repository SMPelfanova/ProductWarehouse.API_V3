namespace ProductWarehouse.API.Models.Responses.Product;

public class ProductSizeResponse
{
	public Guid ProductId { get; set; }
	public Guid SizeId { get; set; }
	public int QuantityInStock { get; set; }
}
