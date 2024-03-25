using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductWarehouse.API.Models.Requests.Auth;
using ProductWarehouse.Application.Features.Commands.Auth.CreateRefreshToken;
using ProductWarehouse.Application.Features.Commands.Auth.UserLogin;
using ProductWarehouse.Application.Features.Commands.Auth.UserLogOut;
using ProductWarehouse.Application.Models.User;

namespace ProductWarehouse.API.Controllers;

/// <summary>
/// Controller for managing user account.
/// </summary>
[Route("api/account/[action]")]
public class AuthController : BaseController
{

	[HttpPost]
	public async Task<IActionResult> LogIn(UserLoginRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper
		)
	{
		var command = mapper.Map<UserLoginCommand>(request);
		var result = await mediator.Send(command);
		if (result != null)
		{
			
			return Ok(new { AccessToken = result.AccessToken, RefreshToken = result.RefreshToken });
		}

		return Unauthorized();
	}

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> LogOut(
		[FromServices] IMediator mediator,
		[FromHeader(Name = "Authorization")] string authorizationHeader)
	{
		await mediator.Send(new UserLogOutCommand() { AuthorizationHeader = authorizationHeader});

		return Ok(new { Message = "Logout successful" });
	}


	[HttpPost("refresh-token")]
	public async Task<IActionResult> RefreshToken(UserRefreshTokenRequest request,
		[FromServices] IMediator mediator,
		[FromServices] IMapper mapper
		)
	{
	
		var command = mapper.Map<GenerateRefreshTokenCommand>(request);
		var user = await mediator.Send(command);
		if (user == null)
		{
			return Unauthorized();
		}

		return Ok(new { AccessToken = user.AccessToken, RefreshToken = user.RefreshToken });
	}

}
