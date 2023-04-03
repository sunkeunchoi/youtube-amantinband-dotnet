// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.UserAggregate;
public sealed class User : AggregateRoot<UserId>
{
  private User(
    UserId userId,
    string firstName,
    string lastName,
    string email,
    string password,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(userId)
  {
    FistName = firstName;
    LastName = lastName;
    Email = email;
    Password = password;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public string FistName { get; }

  public string LastName { get; }

  public string Email { get; }

  public string Password { get; } // Hash password

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

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