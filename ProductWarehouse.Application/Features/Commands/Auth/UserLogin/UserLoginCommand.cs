using MediatR;
using ProductWarehouse.Application.Models.User;

namespace ProductWarehouse.Application.Features.Commands.Auth.UserLogin;
public class UserLoginCommand : IRequest<UserDto>
{
    public string Email { get; set; }
    public string Password { get; set; }

}
