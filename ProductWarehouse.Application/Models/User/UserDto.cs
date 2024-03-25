namespace ProductWarehouse.Application.Models.User;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
	public string PasswordHash { get; set; }
	public string RoleName { get; set; }

	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
	public DateTime RefreshTokenExpiresAt{ get; set; }
}
