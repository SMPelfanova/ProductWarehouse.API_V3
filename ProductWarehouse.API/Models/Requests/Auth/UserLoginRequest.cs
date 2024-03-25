using System.ComponentModel.DataAnnotations;

namespace ProductWarehouse.API.Models.Requests.Auth;

public class UserLoginRequest
{
	[Required]
	public string Email { get; set; }

	[Required]
	public string Password { get; set; }
}