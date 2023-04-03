// <copyright file="AuthenticationResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Authentication.Common;
public record AuthenticationResult(
    User User,
    string Token);