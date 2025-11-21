namespace Shared.Events;

public class PostCreatedEvent
{
    public string PostId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<string> MediaUrls { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
