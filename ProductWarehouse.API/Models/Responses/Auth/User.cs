using ProductWarehouse.Application.Models.User;

namespace ProductWarehouse.API.Models.Responses.Auth;

public class User
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
}