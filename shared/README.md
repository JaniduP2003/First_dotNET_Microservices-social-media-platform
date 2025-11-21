# Shared Library

This library contains common code shared across all microservices.

## Structure

### Events/
Event classes for RabbitMQ message passing:
- `PostCreatedEvent.cs`: Published when a post is created
- `UserFollowedEvent.cs`: Published when a user follows another
- `CommentAddedEvent.cs`: Published when a comment is added
- `LikeAddedEvent.cs`: Published when a post is liked

### Models/
Common domain models:
- `BaseEntity.cs`: Base class for all entities with common properties (Id, CreatedAt, etc.)

### Interfaces/
Common interfaces:
- `IMessageBus.cs`: Abstract message broker operations
- `IRepository.cs`: Generic repository pattern interface

## Usage

Reference this project in your microservice:

```xml
<ItemGroup>
  <ProjectReference Include="..\..\shared\Shared.csproj" />
</ItemGroup>
```

Then use in code:

```csharp
using Shared.Events;
using Shared.Interfaces;
using Shared.Models;

// Publish event
await _messageBus.PublishAsync("posts", "post.created", new PostCreatedEvent
{
    PostId = post.Id,
    UserId = post.UserId,
    CreatedAt = DateTime.UtcNow
});
```

## Adding New Shared Code

Only add code here if it's:
1. Used by multiple services
2. Stable and unlikely to change frequently
3. Has no service-specific logic

Keep services loosely coupled!
