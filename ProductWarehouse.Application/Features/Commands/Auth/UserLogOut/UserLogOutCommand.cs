using MediatR;

namespace ProductWarehouse.Application.Features.Commands.Auth.UserLogOut;
public class UserLogOutCommand: IRequest<bool>
{
	public string Email { get; set; }
	public string AuthorizationHeader { get; set; }
}
