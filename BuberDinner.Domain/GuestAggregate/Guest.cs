// <copyright file="Guest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;
using BuberDinner.Domain.UserAggregate.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
  private readonly List<DinnerId> _upcomingDinnerIds = new();

  private readonly List<DinnerId> _pastDinnerIds = new();

  private readonly List<DinnerId> _pendingDinnerIds = new();

  private readonly List<BillId> _billIds = new();

  private readonly List<MenuReviewId> _menuReviewIds = new();

  private readonly List<Rating> _ratings = new();

  private Guest(
    GuestId guestId,
    string firstName,
    string lastEmail,
    string profileImage,
    AverageRating averageRating,
    UserId userId,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(guestId)
  {
    FirstName = firstName;
    LastEmail = lastEmail;
    ProfileImage = profileImage;
    AverageRating = averageRating;
    UserId = userId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public string FirstName { get; }

  public string LastEmail { get; }

  public string ProfileImage { get; }

  public AverageRating AverageRating { get; }

  public UserId UserId { get; }

  public IReadOnlyCollection<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();

  public IReadOnlyCollection<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();

  public IReadOnlyCollection<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();

  public IReadOnlyCollection<BillId> BillIds => _billIds.AsReadOnly();

  public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

  public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

  public static Guest Create(
    string firstName,
    string lastEmail,
    string profileImage,
    UserId userId)
  {
    return new Guest(
      GuestId.CreateUnique(),
      firstName,
      lastEmail,
      profileImage,
      AverageRating.CreateNew(0, 0),
      userId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}