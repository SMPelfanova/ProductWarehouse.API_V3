using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Models.Requests.Product.Size;

public class DeleteProductSizeRequest
{
	[FromRoute(Name = "id")]
	public Guid ProductId { get; set; }

	[FromRoute(Name = "sizeId")]
	public Guid SizeId { get; set; }
}
