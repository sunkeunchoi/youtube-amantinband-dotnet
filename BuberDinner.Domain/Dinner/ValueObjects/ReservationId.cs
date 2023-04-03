using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public sealed class ReservationId : ValueObject
{
  private ReservationId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; }
  public static ReservationId CreateUnique()
  {
    return new ReservationId(Guid.NewGuid());
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}