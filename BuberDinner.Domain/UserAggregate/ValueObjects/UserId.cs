// <copyright file="UserId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.UserAggregate.ValueObjects;
public sealed class UserId : ValueObject
{
  private UserId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static UserId CreateUnique()
  {
    return new UserId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}