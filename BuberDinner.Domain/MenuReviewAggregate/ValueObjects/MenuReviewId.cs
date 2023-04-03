// <copyright file="MenuReviewId.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
public sealed class MenuReviewId : ValueObject
{
  private MenuReviewId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }

  public static MenuReviewId CreateUnique()
  {
    return new MenuReviewId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}