using BuberDinner.Api.Controller;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;

using ErrorOr;

using Microsoft.AspNetCore.Mvc;
namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
  private readonly IAuthenticationService _authenticationService;

  public AuthenticationController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
    return registerResult.Match<IActionResult>(
      success => Ok(MapAuthResult(success)),
      errors => Problem(errors)
    );
  }

  [HttpPost("login")]
  public IActionResult Login(LoginRequest request)
  {
    var authResult = _authenticationService.Login(request.Email, request.Password);
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