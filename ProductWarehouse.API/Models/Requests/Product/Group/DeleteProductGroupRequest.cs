using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Models.Requests.Product.Group;

public class DeleteProductGroupRequest
{
	[FromRoute(Name = "id")]
	public Guid ProductId { get; set; }

	[FromRoute(Name = "groupId")]
	public Guid GroupId { get; set; }
}
