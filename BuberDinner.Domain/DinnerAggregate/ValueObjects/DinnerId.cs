// <copyright file="DinnerId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.DinnerAggregate.ValueObjects;
public sealed class DinnerId : ValueObject
{
  private DinnerId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static DinnerId CreateUnique()
  {
    return new DinnerId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}