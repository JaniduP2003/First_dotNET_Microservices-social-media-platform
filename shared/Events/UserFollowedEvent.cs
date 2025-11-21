namespace Shared.Events;

public class UserFollowedEvent
{
    public string FollowerId { get; set; } = string.Empty;
    public string FollowedUserId { get; set; } = string.Empty;
    public DateTime FollowedAt { get; set; }
}
