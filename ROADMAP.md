# Development Roadmap

A step-by-step guide to building the social media microservices platform.

## Phase 1: Foundation ✅ COMPLETE

- [x] Create project structure
- [x] Set up docker-compose.yml
- [x] Configure API Gateway (Ocelot)
- [x] Create shared library
- [x] Set up infrastructure (databases, RabbitMQ, Redis)

## Phase 2: Core Services 🔨 IN PROGRESS

### Step 1: Auth Service
**Goal**: User registration and login with JWT tokens

Tasks:
- [ ] Create User entity in Auth.Domain
- [ ] Implement JWT token generation
- [ ] Create login/register endpoints
- [ ] Add password hashing (BCrypt)
- [ ] Configure database with EF Core
- [ ] Add Dockerfile

**Endpoints**:
- `POST /api/auth/register`
- `POST /api/auth/login`
- `POST /api/auth/refresh-token`

---

### Step 2: User Service
**Goal**: User profile management

Tasks:
- [ ] Create User profile entity
- [ ] Implement profile CRUD operations
- [ ] Add profile picture upload
- [ ] Follow/unfollow functionality
- [ ] Get followers/following lists
- [ ] Add Dockerfile

**Endpoints**:
- `GET /api/users/{id}`
- `PUT /api/users/{id}`
- `POST /api/users/{id}/follow`
- `DELETE /api/users/{id}/unfollow`
- `GET /api/users/{id}/followers`
- `GET /api/users/{id}/following`

---

### Step 3: Post Service
**Goal**: Create and manage posts

Tasks:
- [ ] Create Post entity
- [ ] Implement CRUD operations
- [ ] Add pagination for post lists
- [ ] Publish PostCreatedEvent to RabbitMQ
- [ ] Add visibility settings (public/private)
- [ ] Add Dockerfile

**Endpoints**:
- `POST /api/posts`
- `GET /api/posts/{id}`
- `PUT /api/posts/{id}`
- `DELETE /api/posts/{id}`
- `GET /api/posts/user/{userId}`

---

### Step 4: Comment Service
**Goal**: Comments on posts

Tasks:
- [ ] Create Comment entity
- [ ] Implement add/delete comments
- [ ] Add nested replies
- [ ] Publish CommentAddedEvent
- [ ] Subscribe to PostCreatedEvent
- [ ] Add Dockerfile

**Endpoints**:
- `POST /api/comments`
- `GET /api/comments/post/{postId}`
- `DELETE /api/comments/{id}`
- `POST /api/comments/{id}/reply`

---

### Step 5: Like Service
**Goal**: Like/unlike posts

Tasks:
- [ ] Create Like entity
- [ ] Implement like/unlike logic
- [ ] Add like count aggregation
- [ ] Publish LikeAddedEvent
- [ ] Add reaction types (like, love, etc.)
- [ ] Add Dockerfile

**Endpoints**:
- `POST /api/likes/post/{postId}`
- `DELETE /api/likes/post/{postId}`
- `GET /api/likes/post/{postId}/count`
- `GET /api/likes/user/{userId}/posts`

---

## Phase 3: Advanced Features 📊

### Step 6: Feed Service
**Goal**: Personalized news feed

Tasks:
- [ ] Implement feed aggregation logic
- [ ] Subscribe to PostCreatedEvent
- [ ] Cache feeds in Redis
- [ ] Implement feed ranking algorithm
- [ ] Add pagination
- [ ] Add Dockerfile

**Endpoints**:
- `GET /api/feed` (get user's personalized feed)
- `GET /api/feed/user/{userId}` (get specific user's posts)

---

### Step 7: Media Service
**Goal**: Image/video upload

Tasks:
- [ ] Implement file upload (multipart/form-data)
- [ ] Integrate AWS S3 or Azure Blob Storage
- [ ] Add image compression
- [ ] Generate thumbnails
- [ ] Add file type validation
- [ ] Add Dockerfile

**Endpoints**:
- `POST /api/media/upload`
- `GET /api/media/{id}`
- `DELETE /api/media/{id}`

---

### Step 8: Notification Service
**Goal**: Real-time notifications

Tasks:
- [ ] Subscribe to all relevant events
- [ ] Implement SignalR for real-time updates
- [ ] Add email notifications (optional)
- [ ] Store notification history
- [ ] Mark notifications as read
- [ ] Add Dockerfile

**Endpoints**:
- `GET /api/notifications`
- `PUT /api/notifications/{id}/read`
- `DELETE /api/notifications/{id}`

---

### Step 9: Search Service
**Goal**: Search users and posts

Tasks:
- [ ] Implement full-text search
- [ ] Index posts in database
- [ ] Search by username
- [ ] Search by post content
- [ ] Add search filters
- [ ] Add Dockerfile

**Endpoints**:
- `GET /api/search/users?q={query}`
- `GET /api/search/posts?q={query}`

---

## Phase 4: Integration & Testing 🧪

- [ ] Integration testing between services
- [ ] End-to-end API testing
- [ ] Load testing with k6 or JMeter
- [ ] RabbitMQ message flow testing
- [ ] Database migration testing

---

## Phase 5: Frontend Development 🎨

### Option 1: React/Next.js
- [ ] Set up Next.js project
- [ ] Create authentication pages
- [ ] Build news feed UI
- [ ] Implement post creation
- [ ] Add real-time notifications
- [ ] Deploy frontend

### Option 2: Blazor
- [ ] Set up Blazor WebAssembly project
- [ ] Create authentication pages
- [ ] Build news feed UI
- [ ] Implement post creation
- [ ] Add SignalR integration
- [ ] Deploy frontend

---

## Phase 6: DevOps & Deployment 🚀

### Docker
- [ ] Create Dockerfile for each service
- [ ] Optimize Docker images
- [ ] Update docker-compose.yml with all services

### CI/CD
- [ ] Set up GitHub Actions
- [ ] Automated testing on PR
- [ ] Automated deployment

### Kubernetes (Optional)
- [ ] Create Kubernetes manifests
- [ ] Set up Helm charts
- [ ] Deploy to AKS/EKS/GKE

### Monitoring
- [ ] Set up Prometheus
- [ ] Configure Grafana dashboards
- [ ] Add application logging
- [ ] Set up health checks

---

## Phase 7: Advanced Features (Optional) ⚡

- [ ] Direct messaging between users
- [ ] Stories (24-hour posts)
- [ ] Hashtags and trending
- [ ] User mentions (@username)
- [ ] Block/report users
- [ ] Two-factor authentication
- [ ] Rate limiting
- [ ] API versioning

---

## Time Estimates

| Phase | Estimated Time |
|-------|---------------|
| Phase 1 (Foundation) | ✅ 1 day |
| Phase 2 (Core Services) | 2-3 weeks |
| Phase 3 (Advanced Features) | 2-3 weeks |
| Phase 4 (Testing) | 1 week |
| Phase 5 (Frontend) | 2-3 weeks |
| Phase 6 (DevOps) | 1-2 weeks |
| Phase 7 (Optional) | Ongoing |

**Total**: 8-12 weeks for MVP

---

## Success Metrics

- [ ] All 9 services running independently
- [ ] Services communicate via RabbitMQ
- [ ] API Gateway routes all requests
- [ ] Frontend can perform all CRUD operations
- [ ] System handles 100+ concurrent users
- [ ] All tests passing
- [ ] Deployed to cloud (AWS/Azure)

---

## Getting Started with Phase 2

Start with **Auth Service**:

```bash
cd services/auth-service/Auth.API
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package BCrypt.Net-Next
dotnet add reference ../../../shared/Shared.csproj
```

Follow the step-by-step tasks in **Step 1: Auth Service** above.

---

## Resources

- **Documentation**: See README.md and QUICKSTART.md
- **Architecture**: Clean Architecture + Microservices
- **Patterns**: Repository, CQRS, Event-Driven
- **Technologies**: .NET 8, PostgreSQL, RabbitMQ, Docker

Happy coding! 🎉
