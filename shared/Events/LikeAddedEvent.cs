namespace Shared.Events;

public class LikeAddedEvent
{
    public string LikeId { get; set; } = string.Empty;
    public string PostId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
