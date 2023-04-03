using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId>
{
  public string FirstName { get; }
  public string LastEmail { get; }
  public string ProfileImage { get; }
  public AverageRating AverageRating { get; }
  public UserId UserId { get; }

  private readonly List<DinnerId> _upcomingDinnerIds = new();
  public IReadOnlyCollection<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.AsReadOnly();
  private readonly List<DinnerId> _pastDinnerIds = new();
  public IReadOnlyCollection<DinnerId> PastDinnerIds => _pastDinnerIds.AsReadOnly();
  private readonly List<DinnerId> _pendingDinnerIds = new();
  public IReadOnlyCollection<DinnerId> PendingDinnerIds => _pendingDinnerIds.AsReadOnly();
  private readonly List<BillId> _billIds = new();
  public IReadOnlyCollection<BillId> BillIds => _billIds.AsReadOnly();
  private readonly List<MenuReviewId> _menuReviewIds = new();
  public IReadOnlyCollection<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
  private readonly List<Rating> _ratings = new();
  public IReadOnlyCollection<Rating> Ratings => _ratings.AsReadOnly();
  public DateTime CreatedDateTime { get; }
  public DateTime UpdatedDateTime { get; }
  private Guest(
    GuestId guestId,
    string firstName,
    string lastEmail,
    string profileImage,
    AverageRating averageRating,
    UserId userId,
    DateTime createdDateTime,
    DateTime updatedDateTime
    ) : base(guestId)
  {
    FirstName = firstName;
    LastEmail = lastEmail;
    ProfileImage = profileImage;
    AverageRating = averageRating;
    UserId = userId;
    CreatedDateTime = createdDateTime;
    UpdatedDateTime = updatedDateTime;
  }
  public static Guest Create(
    string firstName,
    string lastEmail,
    string profileImage,
    UserId userId)
  {
    return new Guest(
      GuestId.CreateUnique(),
      firstName,
      lastEmail,
      profileImage,
      AverageRating.CreateNew(0, 0),
      userId,
      DateTime.UtcNow,
      DateTime.UtcNow);
  }
}