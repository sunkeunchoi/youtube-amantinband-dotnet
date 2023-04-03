
using BuberDinner.Domain.Common.Models;
namespace BuberDinner.Domain.Dinner.ValueObjects;
public sealed class Location : ValueObject
{
  private Location(string name, string address, double latitude, double longitude)
  {
    Name = name;
    Address = address;
    Latitude = latitude;
    Longitude = longitude;
  }
  public static Location Create(
    string name,
    string address,
    double latitude,
    double longitude)
  {
    return new Location(name, address, latitude, longitude);
  }
  public string Name { get; }
  public string Address { get; }
  public double Latitude { get; }
  public double Longitude { get; }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Name;
    yield return Address;
    yield return Latitude;
    yield return Longitude;
  }
}