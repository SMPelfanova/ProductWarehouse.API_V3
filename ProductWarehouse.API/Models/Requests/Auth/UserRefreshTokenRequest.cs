namespace ProductWarehouse.API.Models.Requests.Auth;

public class UserRefreshTokenRequest
{
	public string Email { get; set; }
	public string RefreshToken { get; set; }
}
