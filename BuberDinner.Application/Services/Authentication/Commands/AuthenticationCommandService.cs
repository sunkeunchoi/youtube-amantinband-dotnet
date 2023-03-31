using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands;
public class AuthenticationCommandService : IAuthenticationCommandService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
}