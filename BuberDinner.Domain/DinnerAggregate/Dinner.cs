// <copyright file="Dinner.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate;
using BuberDinner.Domain.DinnerAggregate.Entities;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.Dinner;
public sealed class Dinner : AggregateRoot<DinnerId>
{
  private readonly List<Reservation> _reservations = new();

  private Dinner(
    DinnerId dinnerId,
    string name,
    string description,
    DateTime startDateTime,
    DateTime endDateTime,
    DateTime? startedDateTime,
    DateTime? endedDateTime,
    DinnerStatus status,
    bool isPublic,
    int maxGuests,
    Price price,
    HostId hostId,
    MenuId menuId,
    string imageUrl,
    Location location,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(dinnerId)
  {
    Name = name;
    Description = description;
    StartDateTime = startDateTime;
    EndDateTime = endDateTime;
    StartedDateTime = startedDateTime;
    EndedDateTime = endedDateTime;
    Status = status;
    IsPublic = isPublic;
    MaxGuests = maxGuests;
    Price = price;
    HostId = hostId;
    MenuId = menuId;
    ImageUrl = imageUrl;
    Location = location;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public string Name { get; }

  public string Description { get; }

  public DateTime StartDateTime { get; }

  public DateTime EndDateTime { get; }

  public DateTime? StartedDateTime { get; }

  public DateTime? EndedDateTime { get; }

  public DinnerStatus Status { get; }

  public bool IsPublic { get; }

  public int MaxGuests { get; }

  public Price Price { get; }

  public HostId HostId { get; }

  public MenuId MenuId { get; }

  public string ImageUrl { get; }

  public Location Location { get; }

  public IReadOnlyCollection<Reservation> Reservations => _reservations.AsReadOnly();

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

  public static Dinner Create(
    string name,
    string description,
    DateTime startDateTime,
    DateTime endDateTime,
    bool isPublic,
    int maxGuests,
    Price price,
    HostId hostId,
    MenuId menuId,
    string imageUrl,
    Location location)
  {
    return new Dinner(
      DinnerId.CreateUnique(),
      name,
      description,
      startDateTime,
      endDateTime,
      null,
      null,
      DinnerStatus.Upcoming,
      isPublic,
      maxGuests,
      price,
      hostId,
      menuId,
      imageUrl,
      location,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}