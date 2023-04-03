// <copyright file="LoginQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Authentication.Common;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;
public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;