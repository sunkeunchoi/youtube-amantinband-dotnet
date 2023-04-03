using BuberDinner.Domain.Common.Models;
public sealed class Price : ValueObject
{
  private Price(double amount, string currency)
  {
    Amount = amount;
    Currency = currency;
  }
  public double Amount { get; }
  public String Currency { get; }
  public static Price Create(double amount, string currency)
  {
    return new Price(amount, currency);
  }
  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Amount;
    yield return Currency;
  }
}