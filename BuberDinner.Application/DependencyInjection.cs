// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;

using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Common.Behaviors;

using ErrorOr;

using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;
public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssembly(typeof(RegisterCommandHandler).Assembly);
      cfg.RegisterServicesFromAssembly(typeof(LoginQueryHandler).Assembly);
      cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    });

    // services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    return services;
  }
}