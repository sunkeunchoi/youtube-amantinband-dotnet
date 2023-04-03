// <copyright file="Reservation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.BillAggregate.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.DinnerAggregate.ValueObjects;
using BuberDinner.Domain.GuestAggregate.ValueObjects;

namespace BuberDinner.Domain.DinnerAggregate.Entities;
public sealed class Reservation : Entity<ReservationId>
{
  private Reservation(
    ReservationId reservationId,
    GuestId guestId,
    int guestCount,
    ReservationStatus reservationStatus,
    BillId billId,
    DateTime? arrivalDateTime,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(reservationId)
  {
    GuestId = guestId;
    GuestCount = guestCount;
    ReservationStatus = reservationStatus;
    BillId = billId;
    ArrivalDateTime = arrivalDateTime;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }

  public int GuestCount { get; }

  public ReservationStatus ReservationStatus { get; }

  public GuestId GuestId { get; }

  public BillId BillId { get; }

  public DateTime? ArrivalDateTime { get; }

  public DateTime CreatedDateTime { get; }

  public DateTime UpdatedDateTime { get; }

  public static Reservation Create(
    GuestId guestId,
    int guestCount,
    ReservationStatus reservationStatus,
    BillId billId,
    DateTime? arrivalDateTime)
  {
    return new Reservation(
      ReservationId.CreateUnique(),
      guestId,
      guestCount,
      reservationStatus,
      billId,
      arrivalDateTime,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}