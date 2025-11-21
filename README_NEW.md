# Social Media Platform

A full-stack social media application built with Next.js (Frontend) and .NET 8 (Backend).

## 🏗️ Architecture

```
┌─────────────┐
│   Next.js   │  ← Frontend (Port 3000)
│  Frontend   │
└──────┬──────┘
       │ HTTP/REST
┌──────▼──────┐
│   .NET 8    │  ← Backend API (Port 5000)
│  Web API    │
└──────┬──────┘
       │
┌──────▼──────┐
│ PostgreSQL  │  ← Database (Port 5432)
└─────────────┘
```

## 📁 Project Structure

```
First_dotNET_Microservices/
├── frontend/                    # Next.js Application
│   ├── src/
│   │   ├── app/                 # App router pages
│   │   ├── components/          # React components
│   │   ├── api/                 # API client
│   │   ├── hooks/               # Custom hooks
│   │   └── contexts/            # React contexts
│   ├── public/                  # Static assets
│   ├── styles/                  # CSS files
│   └── Dockerfile
│
├── backend/                     # .NET Web API
│   ├── SocialMedia.API/         # Controllers & Startup
│   ├── SocialMedia.Application/ # Business Logic
│   ├── SocialMedia.Domain/      # Entities
│   ├── SocialMedia.Infrastructure/ # Data Access
│   └── SocialMedia.sln
│
├── docker/                      # Docker configs
│   ├── nginx/                   # Reverse proxy
│   └── postgres/                # DB scripts
│
├── tests/                       # Test projects
└── docker-compose.yml           # Orchestration
```

## 🚀 Quick Start

### Prerequisites

- Docker & Docker Compose
- .NET 8 SDK (optional, for local dev)
- Node.js 18+ (optional, for local dev)

### Run with Docker

```bash
# Start all services
docker-compose up -d

# View logs
docker-compose logs -f
```

Access the application:
- **Frontend**: http://localhost:3000
- **Backend API**: http://localhost:5000
- **Swagger**: http://localhost:5000/swagger

### Local Development

#### Backend

```bash
cd backend
dotnet restore
dotnet run --project SocialMedia.API
```

#### Frontend

```bash
cd frontend
npm install
npm run dev
```

## 🛠️ Tech Stack

### Frontend
- **Next.js 14** - React framework with App Router
- **Tailwind CSS** - Utility-first CSS
- **Axios** - HTTP client
- **SWR** - Data fetching

### Backend
- **.NET 8** - Web API framework
- **Entity Framework Core** - ORM
- **PostgreSQL** - Database
- **Clean Architecture** - Project structure

### DevOps
- **Docker** - Containerization
- **Docker Compose** - Orchestration
- **Nginx** - Reverse proxy

## 📖 API Endpoints

### Posts

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/posts` | Get all posts |
| GET | `/api/posts/{id}` | Get single post |
| POST | `/api/posts` | Create post |
| PUT | `/api/posts/{id}` | Update post |
| DELETE | `/api/posts/{id}` | Delete post |

## 🔧 Configuration

### Environment Variables

Create `.env` file in root:

```env
# Database
POSTGRES_DB=socialmediadb
POSTGRES_USER=postgres
POSTGRES_PASSWORD=postgres123

# Backend
ASPNETCORE_ENVIRONMENT=Development
ConnectionStrings__DefaultConnection=Host=postgres;Port=5432;Database=socialmediadb;Username=postgres;Password=postgres123

# Frontend
NEXT_PUBLIC_API_URL=http://localhost:5000/api
```

## 🧪 Testing

```bash
# Backend tests
cd tests/backend-tests
dotnet test

# Frontend tests
cd tests/frontend-tests
npm test
```

## 📦 Building for Production

```bash
# Build all services
docker-compose -f docker-compose.prod.yml up -d --build
```

## 🔮 Roadmap

- [x] Basic CRUD operations
- [x] Docker setup
- [x] Frontend UI
- [ ] User authentication
- [ ] Image uploads
- [ ] Real-time updates
- [ ] Comments system
- [ ] Likes/reactions

## 📝 License

MIT

## 👥 Contributing

Pull requests are welcome!
