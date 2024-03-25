using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.User;

namespace ProductWarehouse.Application.Features.Commands.Auth.CreateRefreshToken;
public class GenerateRefreshTokenCommandHandler : IRequestHandler<GenerateRefreshTokenCommand, UserDto>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;
	private readonly ITokenService _tokenService;

	public GenerateRefreshTokenCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_tokenService = tokenService;
	}	

	public async Task<UserDto> Handle(GenerateRefreshTokenCommand request, CancellationToken cancellationToken)
	{
		string accessToken = request.AccessToken;
		string refreshToken = request.RefreshToken;

		var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
		var user = await _unitOfWork.User.GetUserByEmailAsync(principal.Identity.Name);
		if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiresAt <= DateTime.Now)
		{
			throw new Exception("Invalid client request");
		}

		string newRefreshToken = _tokenService.GenerateRefreshToken();

		user.RefreshToken = newRefreshToken;
		user.RefreshTokenExpiresAt = DateTime.Now.AddMinutes(1);


		await _unitOfWork.User.UpdateAsync(user);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		string newAccessToken = _tokenService.GenerateJwtToken(user.Email, user.UserRoles.FirstOrDefault().Role.Name);
		var userResult = _mapper.Map<UserDto>(user);
		userResult.AccessToken = newAccessToken;

		return userResult;
	}
}
