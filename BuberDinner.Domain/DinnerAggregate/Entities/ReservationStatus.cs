// <copyright file="ReservationStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BuberDinner.Domain.DinnerAggregate.Entities;
public enum ReservationStatus
{
  PendingGuestConfirmation,
  Reserved,
  Cancelled,
}