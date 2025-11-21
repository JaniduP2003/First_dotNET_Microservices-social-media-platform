# Quick Start Guide

## Prerequisites

- Docker Desktop installed
- .NET 8 SDK (for local development)
- Git

## Getting Started

### 1. Clone and Navigate

```bash
cd social-media-platform
```

### 2. Start Infrastructure

```bash
# Start databases, RabbitMQ, and Redis
docker-compose up -d

# Verify services are running
docker ps
```

You should see:
- PostgreSQL databases (auth-db, user-db, post-db, etc.)
- RabbitMQ
- Redis

### 3. Access Services

| Service | URL | Credentials |
|---------|-----|-------------|
| RabbitMQ Management | http://localhost:15672 | guest/guest |
| Redis | localhost:6379 | - |
| Auth DB | localhost:5432 | postgres/postgres123 |
| User DB | localhost:5433 | postgres/postgres123 |
| Post DB | localhost:5434 | postgres/postgres123 |

### 4. Build Services (Coming Soon)

Each service needs to be built as Docker images:

```bash
# Example for Post Service
cd services/post-service/Post.API
dotnet build
dotnet run
```

### 5. Run API Gateway

```bash
cd gateway
dotnet restore
dotnet run
```

Gateway will be available at: http://localhost:5000

## Development Workflow

### Creating a New Service

1. Create the project structure:
```bash
cd services/your-service
dotnet new webapi -n YourService.API
dotnet new classlib -n YourService.Application
dotnet new classlib -n YourService.Domain
dotnet new classlib -n YourService.Infrastructure
```

2. Add reference to shared library:
```bash
cd YourService.API
dotnet add reference ../../shared/Shared.csproj
```

3. Add to docker-compose.yml

4. Update gateway routes in `gateway/Routes/routes.json`

### Testing RabbitMQ

1. Open RabbitMQ Management UI: http://localhost:15672
2. Login with guest/guest
3. Navigate to Exchanges → Create new exchange
4. Navigate to Queues → Create new queue
5. Bind queue to exchange

### Database Migrations (Example with EF Core)

```bash
cd services/post-service/Post.Infrastructure
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Troubleshooting

### Ports Already in Use

If ports are occupied, modify `docker-compose.yml`:

```yaml
ports:
  - "5433:5432"  # Change 5433 to another port
```

### Services Not Communicating

1. Check all services are on the same network: `social-media-network`
2. Use service names (not localhost) in connection strings
3. Check firewall settings

### Database Connection Issues

```bash
# Check database is running
docker logs auth-db

# Connect to database
docker exec -it auth-db psql -U postgres -d authdb
```

## Next Steps

1. ✅ Infrastructure is ready
2. ⬜ Implement Auth Service
3. ⬜ Implement User Service  
4. ⬜ Implement Post Service
5. ⬜ Add RabbitMQ integration
6. ⬜ Add Redis caching
7. ⬜ Create frontend application

## Useful Commands

```bash
# View all running containers
docker ps

# View logs
docker-compose logs -f [service-name]

# Stop all services
docker-compose down

# Remove volumes (clean slate)
docker-compose down -v

# Rebuild specific service
docker-compose up -d --build [service-name]
```

## Architecture Diagram

```
┌─────────────┐
│   Frontend  │
└──────┬──────┘
       │
┌──────▼──────────────┐
│   API Gateway       │
│   (Port 5000)       │
└──────┬──────────────┘
       │
       ├──────────────────────────┬──────────────┐
       │                          │              │
┌──────▼──────┐         ┌────────▼────┐  ┌─────▼─────┐
│ Auth Service│         │Post Service │  │User Service│
│  (Port 5001)│         │ (Port 5003) │  │(Port 5002) │
└──────┬──────┘         └──────┬──────┘  └─────┬──────┘
       │                       │                │
       │         ┌─────────────┴────────────────┘
       │         │
┌──────▼─────────▼────┐
│     RabbitMQ        │
│   (Event Bus)       │
└─────────────────────┘
```

Happy coding! 🚀
