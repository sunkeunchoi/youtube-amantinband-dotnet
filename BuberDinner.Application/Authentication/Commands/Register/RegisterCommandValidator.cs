// <copyright file="RegisterCommandValidator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;
public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
  public RegisterCommandValidator()
  {
    RuleFor(x => x.Email)
      .NotEmpty()
      .EmailAddress();
    RuleFor(x => x.Password)
      .NotEmpty()
      .MinimumLength(6);
    RuleFor(x => x.FirstName).NotEmpty();
    RuleFor(x => x.LastName).NotEmpty();
  }
}