# Services

This directory contains all microservices for the social media platform.

## Service Structure

Each service follows Clean Architecture with these layers:

```
ServiceName.API/          # Web API layer (Controllers, DTOs)
ServiceName.Application/  # Business logic and use cases
ServiceName.Domain/       # Domain entities and interfaces
ServiceName.Infrastructure/ # Data access, external services
```

## Available Services

### 1. Auth Service (Port: 5001)
- User authentication (login/register)
- JWT token generation
- Password management

### 2. User Service (Port: 5002)
- User profile management
- Follow/unfollow functionality
- User search

### 3. Post Service (Port: 5003)
- Create, edit, delete posts
- Post visibility settings
- Post metadata

### 4. Comment Service (Port: 5004)
- Add comments to posts
- Nested replies
- Comment moderation

### 5. Like Service (Port: 5005)
- Like/unlike posts
- Like count aggregation
- Reaction types

### 6. Feed Service (Port: 5006)
- Personalized news feed
- Feed caching with Redis
- Feed ranking algorithms

### 7. Media Service (Port: 5007)
- Image/video upload
- Media processing
- Storage integration (S3/Azure Blob)

### 8. Notification Service (Port: 5008)
- Push notifications
- Email notifications
- In-app notifications

### 9. Search Service (Port: 5009)
- User search
- Post search
- Full-text search capabilities

## Building Services

To create a new service API:

```bash
cd services/your-service
dotnet new webapi -n YourService.API
dotnet new classlib -n YourService.Application
dotnet new classlib -n YourService.Domain
dotnet new classlib -n YourService.Infrastructure
```

## Running Services

Each service can be run independently:

```bash
cd services/your-service/YourService.API
dotnet run
```

Or use Docker:

```bash
docker-compose up your-service
```

## Inter-Service Communication

- **Synchronous**: HTTP calls via HttpClient (use sparingly)
- **Asynchronous**: RabbitMQ events (preferred for loose coupling)
- **Gateway**: All external requests go through API Gateway
