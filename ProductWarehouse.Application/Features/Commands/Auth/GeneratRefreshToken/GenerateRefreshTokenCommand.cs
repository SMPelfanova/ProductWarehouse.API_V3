using MediatR;
using ProductWarehouse.Application.Models.User;

namespace ProductWarehouse.Application.Features.Commands.Auth.CreateRefreshToken;
public class GenerateRefreshTokenCommand: IRequest<UserDto>
{
	public string AccessToken { get; set; }
	public string RefreshToken { get; set; }
}
