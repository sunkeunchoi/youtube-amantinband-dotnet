// <copyright file="MenuItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;
public sealed class MenuItem : Entity<MenuItemId>
{
  private MenuItem(MenuItemId menuItemId, string name, string description)
    : base(menuItemId)
  {
    Name = name;
    Description = description;
  }

  public string Name { get; }

  public string Description { get; }

  public static MenuItem Create(string name, string description)
  {
    return new MenuItem(MenuItemId.CreateUnique(), name, description);
  }
}