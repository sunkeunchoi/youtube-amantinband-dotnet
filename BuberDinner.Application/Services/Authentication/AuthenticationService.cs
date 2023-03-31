using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
  {
    // 1. Check if user already exists
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      return Errors.User.DuplicateEmail;
    }
    // 2. Create User (generate unique ID)
    var user = new User(firstName, lastName, email, password);
    _userRepository.Add(user);
    // 3. Create JWT token

    string token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(
        user,
        token
    );
  }

  public ErrorOr<AuthenticationResult> Login(string email, string password)
  {
    // 1. Check if user exists
    if (_userRepository.GetUserByEmail(email) is not User user)
    {
      return Errors.Authentication.InvalidCredentials;
    }
    if (user.Password != password)
    {
      return new[] { Errors.Authentication.InvalidCredentials };
    }
    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(
        user,
        token
    );
  }
}