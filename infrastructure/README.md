# Infrastructure

This directory contains configuration and setup for infrastructure components.

## Databases

Each service has its own database following the microservices pattern:

- **auth-db**: Authentication and authorization data
- **user-db**: User profiles and relationships
- **post-db**: Posts and related metadata
- **comment-db**: Comments on posts
- **like-db**: Likes and reactions
- **feed-db**: Cached feed data
- **search-db**: Search indexes
- **media-storage**: File storage configuration

## RabbitMQ

Message broker for asynchronous communication between services.

- Configuration files for exchanges, queues, and bindings
- Can be extended with custom RabbitMQ plugins

## Monitoring

Optional monitoring stack:

- **Prometheus**: Metrics collection
- **Grafana**: Visualization dashboards
- **Logs**: Centralized logging configuration

## Setup

All infrastructure components are configured in the root `docker-compose.yml` file.

To start infrastructure only:

```bash
docker-compose up -d rabbitmq redis auth-db user-db post-db comment-db like-db feed-db search-db
```
