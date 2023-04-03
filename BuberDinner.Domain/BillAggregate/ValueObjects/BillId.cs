// <copyright file="BillId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.BillAggregate.ValueObjects;
public sealed class BillId : ValueObject
{
  private BillId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static BillId CreateUnique()
  {
    return new BillId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}