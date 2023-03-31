using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;

using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
  private readonly IUserRepository _userRepository;
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
  {
    _userRepository = userRepository;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
  {
    await Task.CompletedTask;
    // 1. Check if user already exists
    if (_userRepository.GetUserByEmail(command.Email) is not null)
    {
      return Errors.User.DuplicateEmail;
    }
    // 2. Create User (generate unique ID)
    var user = new User
    (
      command.FirstName,
      command.LastName,
      command.Email,
      command.Password
    );
    _userRepository.Add(user);
    // 3. Create JWT token

    string token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(
        user,
        token
    );
  }
}