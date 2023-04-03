using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User;
public sealed class User : AggregateRoot<UserId>
{
  public string FistName { get; }
  public string LastName { get; }
  public string Email { get; }
  public string Password { get; } // Hash password
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private User(
    UserId userId,
    string firstName,
    string lastName,
    string email,
    string password,
    DateTime createdDateTime,
    DateTime updatedDateTime
    ) : base(userId)
  {
    FistName = firstName;
    LastName = lastName;
    Email = email;
    Password = password;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }
  public static User Create(
    string firstName,
    string lastName,
    string email,
    string password)
  {
    return new User(
      UserId.CreateUnique(),
      firstName,
      lastName,
      email,
      password,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}