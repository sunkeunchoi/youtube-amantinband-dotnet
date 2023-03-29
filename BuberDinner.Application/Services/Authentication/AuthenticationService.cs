using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

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

  public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
    // 1. Check if user already exists
    if (_userRepository.GetUserByEmail(email) is not null)
    {
      throw new Exception("User already exists");
    }
    // 2. Create User (generate unique ID)
    var user = new User(firstName, lastName, email, password);
    _userRepository.Add(user);
    // 3. Create JWT token

    string token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
    return new AuthenticationResult(
        user.Id,
        firstName,
        lastName,
        email,
        token
    );
  }

  public AuthenticationResult Login(string email, string password)
  {
    // 1. Check if user exists
    if (_userRepository.GetUserByEmail(email) is not User user)
    {
      throw new Exception("User does not exist");
    }
    if (user.Password != password)
    {
      throw new Exception("Password is incorrect");
    }
    var token = _jwtTokenGenerator.GenerateToken(user.Id, user.FirstName, user.LastName);
    return new AuthenticationResult(
        user.Id,
        user.FirstName,
        user.LastName,
        user.Email,
        token
    );
  }
}