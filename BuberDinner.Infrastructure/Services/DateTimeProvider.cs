// <copyright file="DateTimeProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Application.Common.Interfaces.Services;

namespace BuberDinner.Infrastructure.Services
{
  public class DateTimeProvider : IDateTimeProvider
  {
    public DateTime UtcNow => DateTime.UtcNow;
  }
}