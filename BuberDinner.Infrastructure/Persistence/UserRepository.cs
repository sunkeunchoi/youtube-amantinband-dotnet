// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;
public class UserRepository : IUserRepository
{
  private static readonly List<User> _users = new();

  public User? GetUserByEmail(string email)
  {
    return _users.SingleOrDefault<User>(u => u.Email == email);
  }

  public void Add(User user)
  {
    _users.Add(user);
  }
}