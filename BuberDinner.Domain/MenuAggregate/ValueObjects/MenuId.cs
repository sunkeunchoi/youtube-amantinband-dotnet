// <copyright file="MenuId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;
public sealed class MenuId : ValueObject
{
  private MenuId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static MenuId CreateUnique()
  {
    return new MenuId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}