using AutoMapper;
using MediatR;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Models.User;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Features.Commands.Auth.UserLogin;
public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public UserLoginCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    public async Task<UserDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        //todo: check password
        var user = await _unitOfWork.User.GetUserByEmailAsync(request.Email);

        if (user == null && user.Password != request.Password)
        {
			throw new Exception("User not found.");
		}

		var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiresAt = DateTime.Now.AddMinutes(1);
        try
        {
			await _unitOfWork.User.SetUserRefreshToken(user.Email, user.RefreshToken);

			await _unitOfWork.SaveChangesAsync(cancellationToken);

			var accessToken = _tokenService.GenerateJwtToken(user.Email, user.UserRoles.FirstOrDefault().Role.Name);
			var userDto = _mapper.Map<UserDto>(user);
			userDto.AccessToken = accessToken;
			return userDto;

		}
		catch (Exception ex) { 
        return null;
		}


	}
}
