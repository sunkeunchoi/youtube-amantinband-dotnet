// <copyright file="Bill.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;
using BuberDinner.Domain.HostAggregate.ValueObjects;

namespace BuberDinner.Domain.Bill;
public sealed class Bill : AggregateRoot<BillId>
{
  private Bill(
    BillId billId,
    DinnerId dinnerId,
    GuestId guestId,
    HostId hostId,
    Price price,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(billId)
  {
    DinnerId = dinnerId;
    GuestId = guestId;
    HostId = hostId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
    Price = price;
  }

  public DinnerId DinnerId { get; }

  public GuestId GuestId { get; }

  public HostId HostId { get; }

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

  public Price Price { get; }

  public static Bill Create(
    DinnerId dinnerId,
    GuestId guestId,
    HostId hostId,
    Price price)
  {
    return new Bill(
      BillId.CreateUnique(),
      dinnerId,
      guestId,
      hostId,
      price,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}