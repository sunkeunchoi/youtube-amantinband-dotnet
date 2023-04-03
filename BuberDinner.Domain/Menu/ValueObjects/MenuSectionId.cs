using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;
public sealed class MenuSectionId : ValueObject
{
  private MenuSectionId(Guid value)
  {
    Value = value;
  }

  public Guid Value { get; }
  public static MenuSectionId CreateUnique()
  {
    return new MenuSectionId(Guid.NewGuid());
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}