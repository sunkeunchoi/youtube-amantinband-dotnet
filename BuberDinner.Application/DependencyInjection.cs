using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;

using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Application;
public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RegisterCommand>());
    services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginQuery>());
    return services;
  }
}