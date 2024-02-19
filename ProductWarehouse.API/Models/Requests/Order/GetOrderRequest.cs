using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Models.Requests.Order;

public class GetOrderRequest
{
	[FromRoute(Name = "id")]
	public Guid Id { get; set; }

	[FromRoute(Name = "userId")]
	public Guid UserId { get; set; }
}
