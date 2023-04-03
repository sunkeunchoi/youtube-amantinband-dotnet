// <copyright file="Host.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.HostAggregate;
public sealed class Host : AggregateRoot<HostId>
{
  private readonly List<MenuId> _menuIds = new();

  private readonly List<DinnerId> _dinnerIds = new();

  private Host(
    HostId hostId,
    string firstName,
    string lastName,
    string profileImage,
    AverageRating averageRating,
    UserId userId,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(hostId)
  {
    FirstName = firstName;
    LastName = lastName;
    ProfileImage = profileImage;
    AverageRating = averageRating;
    UserId = userId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public string FirstName { get; }

  public string LastName { get; }

  public string ProfileImage { get; }

  public AverageRating AverageRating { get; }

  public UserId UserId { get; }

  public IReadOnlyCollection<MenuId> MenuIds => _menuIds.AsReadOnly();

  public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

  public static Host Create(
    string firstName,
    string lastName,
    string profileImage,
    UserId userId)
  {
    return new Host(
      HostId.CreateUnique(),
      firstName,
      lastName,
      profileImage,
      AverageRating.CreateNew(0, 0),
      userId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}