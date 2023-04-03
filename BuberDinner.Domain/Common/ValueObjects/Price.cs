// <copyright file="Price.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.Common.ValueObjects;
public sealed class Price : ValueObject
{
  private Price(double amount, string currency)
  {
    Amount = amount;
    Currency = currency;
  }

  public double Amount { get; }

  public string Currency { get; }

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