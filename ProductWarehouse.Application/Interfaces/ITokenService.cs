using System.Security.Claims;

namespace ProductWarehouse.Application.Interfaces;
public interface ITokenService
{
	string GenerateJwtToken(string email, string role);
	string GenerateRefreshToken();
	ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}