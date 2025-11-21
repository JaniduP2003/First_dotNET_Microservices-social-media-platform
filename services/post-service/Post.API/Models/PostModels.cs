namespace Post.API.Models;

public class CreatePostDto
{
    public string Content { get; set; } = string.Empty;
    public List<string> MediaUrls { get; set; } = new();
    public string Visibility { get; set; } = "public"; // public, private, friends
}

public class PostDto
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<string> MediaUrls { get; set; } = new();
    public int LikesCount { get; set; }
    public int CommentsCount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
