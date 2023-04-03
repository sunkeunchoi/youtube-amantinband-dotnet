// <copyright file="AggregateRoot.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.Common.Models;
public abstract class AggregateRoot<TId> : Entity<TId>
where TId : notnull
{
  protected AggregateRoot(TId id)
    : base(id)
  {
  }
}