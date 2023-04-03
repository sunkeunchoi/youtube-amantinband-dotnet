// <copyright file="IDateTimeProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Application.Common.Interfaces.Services;
public interface IDateTimeProvider
{
  DateTime UtcNow { get; }

  // DateTimeOffset Now { get; }
}