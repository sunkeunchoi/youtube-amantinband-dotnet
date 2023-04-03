using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host;
public sealed class Host : AggregateRoot<HostId>
{
  public string FirstName { get; }
  public string LastName { get; }
  public string ProfileImage { get; }
  public AverageRating AverageRating { get; }
  public UserId UserId { get; }
  private readonly List<MenuId> _menuIds = new();
  public IReadOnlyCollection<MenuId> MenuIds => _menuIds.AsReadOnly();
  private readonly List<DinnerId> _dinnerIds = new();
  public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private Host(
    HostId hostId,
    string firstName,
    string lastName,
    string profileImage,
    AverageRating averageRating,
    UserId userId,
    DateTime createdDateTime,
    DateTime updatedDateTime
    ) : base(hostId)
  {
    FirstName = firstName;
    LastName = lastName;
    ProfileImage = profileImage;
    AverageRating = averageRating;
    UserId = userId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }
  public static Host Create(
    string firstName,
    string lastName,
    string profileImage,
    UserId userId)
  {
    return new Host(
      HostId.CreateUnique(),
      firstName,
      lastName,
      profileImage,
      AverageRating.CreateNew(0, 0),
      userId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}