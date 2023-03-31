using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;
public static partial class Errors
{
  public static class Authentication
  {
    public static readonly Error InvalidCredentials = Error.Validation(
      code: "Auth.InvalidCredentials",
      description: "Invalid credentials");
  }
}