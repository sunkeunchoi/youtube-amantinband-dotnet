using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

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
    DateTime updatedDateTime) : base(billId)
  {
    DinnerId = dinnerId;
    GuestId = guestId;
    HostId = hostId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
    Price = price;
  }
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

  public DinnerId DinnerId { get; }
  public GuestId GuestId { get; }
  public HostId HostId { get; }
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  public Price Price { get; }
}