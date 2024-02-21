using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Models.Requests.Base;

public class BaseRequestUserId
{
	[FromRoute(Name = "userId")]
	public Guid UserId { get; set; }
}
