using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;
public sealed class Menu : AggregateRoot<MenuId>
{
  private readonly List<MenuSection> _sections = new();
  private readonly List<DinnerId> _dinnerIds = new();
  private readonly List<MenuReviewId> _menuReviewIds = new();
  private Menu(
    MenuId menuId,
    string name,
    string description,
    AverageRating averageRating,
    HostId hostId,
    DateTime createdDateTime,
    DateTime updatedDateTime
    ) : base(menuId)
  {
    Name = name;
    Description = description;
    AverageRating = averageRating;
    HostId = hostId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }
  public static Menu Create(string name, string description, HostId hostId)
  {
    return new Menu(
      MenuId.CreateUnique(),
      name,
      description,
      AverageRating.CreateNew(0, 0),
      hostId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }

  public string Name { get; }
  public string Description { get; }
  public AverageRating AverageRating { get; }
  public HostId HostId { get; }
  public IReadOnlyCollection<MenuSection> Sections => _sections.AsReadOnly();
  public IReadOnlyCollection<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
  public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
}