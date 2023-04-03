// <copyright file="DependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Reflection;

using Mapster;

using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping;
public static class DependencyInjection
{
  public static IServiceCollection AddMapping(this IServiceCollection services)
  {
    var config = TypeAdapterConfig.GlobalSettings;
    config.Scan(Assembly.GetExecutingAssembly());
    services.AddSingleton(config);
    services.AddSingleton<IMapper, ServiceMapper>();
    return services;
  }
}