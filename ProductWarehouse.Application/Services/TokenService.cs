using Microsoft.IdentityModel.Tokens;
using ProductWarehouse.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProductWarehouse.Application.Services;
public class TokenService : ITokenService
{
	public string GenerateJwtToken(string email, string role)
	{
		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CuYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SSA"));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[] { new Claim("email", email), new Claim("role", role) }),
			Expires = DateTime.Now.AddMinutes(1),
			SigningCredentials = credentials,
			Issuer = "http://localhost:3001",
			Audience = "http://localhost:3001",
		};
		//var tokeOptions = new JwtSecurityToken(
		//   issuer: "https://localhost:5001",
		//   audience: "https://localhost:5001",
		//   claims: new List<Claim>(new[] { new Claim("email", email), new Claim("role", role) }),
		//   expires: DateTime.Now.AddMinutes(1),
		//   signingCredentials: credentials
		//  );
		//var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);

		//return tokenString;
	}

	public string GenerateRefreshToken()
	{
		var randomNumber = new byte[32];
		using (var rng = RandomNumberGenerator.Create())
		{
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}
	}

	public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
	{
		var tokenValidationParameters = new TokenValidationParameters
		{
			ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
			ValidateIssuer = false,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CuYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SSA")),
			ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
		};
		var tokenHandler = new JwtSecurityTokenHandler();
		SecurityToken securityToken;
		var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
		var jwtSecurityToken = securityToken as JwtSecurityToken;
		if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			throw new SecurityTokenException("Invalid token");
		return principal;
	}
}
