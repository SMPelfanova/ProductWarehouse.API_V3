using MediatR;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Application.Features.Commands.Auth.UserLogOut;
public class UserLogOutCommandHandler : IRequestHandler<UserLogOutCommand, bool>
{
	private readonly IUnitOfWork _unitOfWork;

	public UserLogOutCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(UserLogOutCommand request, CancellationToken cancellationToken)
	{
		string userRefreshToken = await _unitOfWork.User.GetUserRefreshToken(request.Email);
		string requestRefreshToken = ExtractRefreshToken(request.AuthorizationHeader);
		if (requestRefreshToken == userRefreshToken)
		{
			await _unitOfWork.User.DeleteUserRefreshToken(request.Email);
			return true;
		}

		return false;
	}
	private string ExtractRefreshToken(string authorizationHeader)
	{
		if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
		{
			return authorizationHeader.Substring("Bearer ".Length).Trim();
		}

		return null;
	}
}
