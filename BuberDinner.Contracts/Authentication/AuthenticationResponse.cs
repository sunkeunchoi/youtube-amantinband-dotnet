// <copyright file="AuthenticationResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Contracts.Authentication;
public record AuthenticationResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);