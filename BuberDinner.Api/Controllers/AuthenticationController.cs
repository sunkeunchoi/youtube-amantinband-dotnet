using BuberDinner.Api.Controller;
using BuberDinner.Application.Services.Authentication.Commands;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries;
using BuberDinner.Contracts.Authentication;

using ErrorOr;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
  private readonly IAuthenticationCommandService _authenticationCommandService;
  private readonly IAuthenticationQueryService _authenticationQueryService;

  public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
  {
    _authenticationCommandService = authenticationCommandService;
    _authenticationQueryService = authenticationQueryService;
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(request.FirstName, request.LastName, request.Email, request.Password);
    return registerResult.Match<IActionResult>(
      success => Ok(MapAuthResult(success)),
      errors => Problem(errors)
    );
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var authResult = _authenticationQueryService.Login(request.Email, request.Password);
    return authResult.Match(
      success => Ok(MapAuthResult(success)),
      errors => Problem(errors)
    );
  }
  private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
  {
    return new AuthenticationResponse(
              authResult.User.Id,
              authResult.User.FirstName,
              authResult.User.LastName,
              authResult.User.Email,
              authResult.Token
          );
  }
}