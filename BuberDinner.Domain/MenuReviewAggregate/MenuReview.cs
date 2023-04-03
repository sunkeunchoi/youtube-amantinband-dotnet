// <copyright file="MenuReview.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate.ValueObjects;
using BuberDinner.Domain.MenuReviewAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuReviewAggregate;
public sealed class MenuReview : AggregateRoot<MenuReviewId>
{
  private MenuReview(
    MenuReviewId menuReviewId,
    int rating,
    string comment,
    HostId hostId,
    MenuId menuId,
    GuestId guestId,
    DinnerId dinnerId,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(menuReviewId)
  {
    Rating = rating;
    Comment = comment;
    HostId = hostId;
    MenuId = menuId;
    GuestId = guestId;
    DinnerId = dinnerId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public int Rating { get; } // Is this a good idea?

  public string Comment { get; }

  public HostId HostId { get; }

  public MenuId MenuId { get; }

  public GuestId GuestId { get; }

  public DinnerId DinnerId { get; }

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

  public static MenuReview Create(
    int rating,
    string comment,
    HostId hostId,
    MenuId menuId,
    GuestId guestId,
    DinnerId dinnerId)
  {
    return new MenuReview(
      MenuReviewId.CreateUnique(),
      rating,
      comment,
      hostId,
      menuId,
      guestId,
      dinnerId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}