// <copyright file="Errors.User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;
public static partial class Errors
{
  public static class User
  {
    public static readonly Error DuplicateEmail = Error.Conflict(
      code: "User.DuplicateEmail",
      description: "Email already exists");
  }
}