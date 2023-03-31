using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;

using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;


using ErrorOr;

using MediatR;
using BuberDinner.Application.Authentication.Common;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{

  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;
  public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
  {
    // 1. Check if user exists
    if (_userRepository.GetUserByEmail(query.Email) is not User user)
    {
      return Errors.Authentication.InvalidCredentials;
    }
    if (user.Password != query.Password)
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