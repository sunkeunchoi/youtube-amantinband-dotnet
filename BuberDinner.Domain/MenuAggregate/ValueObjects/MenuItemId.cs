// <copyright file="MenuItemId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;
public sealed class MenuItemId : ValueObject
{
  private MenuItemId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static MenuItemId CreateUnique()
  {
    return new MenuItemId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}