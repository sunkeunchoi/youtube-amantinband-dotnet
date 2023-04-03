// <copyright file="HostId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.HostAggregate.ValueObjects;
public sealed class HostId : ValueObject
{
  private HostId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static HostId CreateUnique()
  {
    return new HostId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}