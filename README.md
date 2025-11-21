# Social Media Platform - Microservices Architecture

A scalable social media platform built with .NET microservices architecture.

## Architecture Overview

```
Frontend → API Gateway → Microservices → Databases
                ↓
            RabbitMQ (Event Bus)
```

## Services

- **Auth Service**: Authentication & authorization (JWT)
- **User Service**: User profiles and management
- **Post Service**: Create, edit, delete posts
- **Comment Service**: Comments on posts
- **Like Service**: Likes and reactions
- **Feed Service**: News feed generation (aggregation)
- **Media Service**: Image/video upload and storage
- **Notification Service**: Push notifications
- **Search Service**: Search users and posts

## Tech Stack

- **.NET 8**: Backend framework
- **PostgreSQL**: Primary database for services
- **Redis**: Caching layer
- **RabbitMQ**: Message broker for event-driven communication
- **Docker**: Containerization
- **YARP/Ocelot**: API Gateway

## Getting Started

### Prerequisites

- Docker & Docker Compose
- .NET 8 SDK (for local development)

### Run with Docker

```bash
docker-compose up -d
```

### Access Services

- API Gateway: http://localhost:5000
- RabbitMQ Management: http://localhost:15672 (guest/guest)
- Grafana: http://localhost:3000

## Project Structure

```
/social-media-platform
├── gateway/                  # API Gateway
├── shared/                   # Shared libraries
├── services/                 # All microservices
├── infrastructure/           # Databases, message queues
└── docker-compose.yml
```

## Development

Each service follows Clean Architecture:
- **API**: Controllers and HTTP layer
- **Application**: Business logic and use cases
- **Domain**: Entities and domain models
- **Infrastructure**: Data access and external services

## Communication Patterns

- **Synchronous**: HTTP/REST via API Gateway
- **Asynchronous**: RabbitMQ events for decoupled communication

## License

MIT
