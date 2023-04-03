using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities;
public sealed class Reservation : Entity<ReservationId>
{
  public int GuestCount { get; }
  public ReservationStatus ReservationStatus { get; }
  public GuestId GuestId { get; }
  public BillId BillId { get; }
  public DateTime? ArrivalDateTime { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private Reservation(
    ReservationId reservationId,
    GuestId guestId,
    int guestCount,
    ReservationStatus reservationStatus,
    BillId billId,
    DateTime? arrivalDateTime,
    DateTime createdDateTime,
    DateTime updatedDateTime) : base(reservationId)
  {
    GuestId = guestId;
    GuestCount = guestCount;
    ReservationStatus = reservationStatus;
    BillId = billId;
    ArrivalDateTime = arrivalDateTime;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }
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