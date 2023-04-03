// <copyright file="MenuSection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;
public sealed class MenuSection : Entity<MenuSectionId>
{
  private readonly List<MenuItem> _items = new();

  private MenuSection(MenuSectionId menuSectionId, string name, string description)
    : base(menuSectionId)
  {
    Name = name;
    Description = description;
  }

  public string Name { get; }

  public string Description { get; }
  public IReadOnlyCollection<MenuItem> Items => _items.AsReadOnly();

  // public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
  // public IReadOnlyCollection<MenuItem> Items => _items.ToList();
  public static MenuSection Create(string name, string description)
  {
    return new MenuSection(MenuSectionId.CreateUnique(), name, description);
  }
}