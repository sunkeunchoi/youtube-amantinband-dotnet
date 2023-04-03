// <copyright file="RegisterRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Contracts.Authentication;
public record RegisterRequest
(
    string FirstName,
    string LastName,
    string Email,
    string Password);