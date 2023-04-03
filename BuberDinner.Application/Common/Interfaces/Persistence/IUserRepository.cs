// <copyright file="IUserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistence;
public interface IUserRepository
{
  User? GetUserByEmail(string email);

  void Add(User user);
}