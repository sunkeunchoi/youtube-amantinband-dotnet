// <copyright file="IJwtTokenGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Authentication;
public interface IJwtTokenGenerator
{
  string GenerateToken(User user);
}