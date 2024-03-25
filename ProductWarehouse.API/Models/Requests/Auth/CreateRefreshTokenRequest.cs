namespace ProductWarehouse.API.Models.Requests.Auth;

public class CreateRefreshTokenRequest
{
	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
}
