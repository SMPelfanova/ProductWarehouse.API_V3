using Microsoft.AspNetCore.Mvc;

namespace ProductWarehouse.API.Models.Requests.Base;

public class BaseRequestId
{

	[FromRoute(Name = "id")]
	public Guid Id { get; set; }

}
