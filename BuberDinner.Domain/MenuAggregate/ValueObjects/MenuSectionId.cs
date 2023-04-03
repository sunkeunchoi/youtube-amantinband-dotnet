// <copyright file="MenuSectionId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuAggregate.ValueObjects;
public sealed class MenuSectionId : ValueObject
{
  private MenuSectionId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static MenuSectionId CreateUnique()
  {
    return new MenuSectionId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}