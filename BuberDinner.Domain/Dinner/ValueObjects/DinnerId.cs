namespace BuberDinner.Domain.Common.Models;
public sealed class DinnerId : ValueObject
{
  private DinnerId(Guid value)
  {
    Value = value;
  }
  public Guid Value { get; }
  public static DinnerId CreateUnique()
  {
    return new DinnerId(Guid.NewGuid());
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}