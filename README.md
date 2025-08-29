# SKInet - Full-Stack E-Commerce Platform

A modern, full-featured e-commerce application built with ASP.NET Core 8 and Vue.js 2, featuring secure payment processing, user authentication, and real-time shopping cart functionality.

## 🚀 Features

### Core E-Commerce Functionality
- **Product Catalog** - Browse products with filtering, sorting, and pagination
- **Shopping Cart** - Real-time cart updates with Redis persistence
- **User Authentication** - JWT-based secure login and registration
- **Order Management** - Complete order processing and history tracking
- **Payment Processing** - Secure payments via Stripe integration
- **Product Search** - Advanced search with multiple filters
- **Responsive Design** - Mobile-friendly interface with Bootstrap

### Advanced Features
- **Multi-step Checkout** - Address validation and delivery options
- **Order History** - Complete order tracking for users
- **Admin Dashboard** - Product and order management
- **Real-time Updates** - Live cart synchronization across sessions
- **Error Handling** - Comprehensive API error responses

## 🛠️ Technology Stack

### Backend
- **ASP.NET Core 8** - Web API framework
- **Entity Framework Core** - ORM with PostgreSQL
- **PostgreSQL** - Primary database
- **Redis** - Caching and session storage
- **AutoMapper** - Object-to-object mapping
- **JWT Authentication** - Secure token-based auth
- **Stripe API** - Payment processing
- **Swagger/OpenAPI** - API documentation

### Frontend
- **Vue.js 2** - Progressive JavaScript framework
- **Vuex** - State management
- **Vue Router** - Client-side routing
- **Bootstrap 5** - CSS framework
- **Axios** - HTTP client
- **Bootstrap Icons** - Icon library
- **SCSS/Sass** - CSS preprocessing

### DevOps & Infrastructure
- **Docker** - Containerization
- **Docker Compose** - Multi-container orchestration
- **Git** - Version control

## 🏗️ Architecture

The project follows **Clean Architecture** principles with clear separation of concerns:

```
├── API/                    # Web API layer
│   ├── Controllers/        # API controllers
│   ├── DTOs/              # Data transfer objects
│   ├── Middleware/        # Custom middleware
│   └── Extensions/        # Service extensions
├── Core/                  # Domain layer
│   ├── Entities/          # Domain entities
│   ├── Interfaces/        # Repository interfaces
│   └── Specifications/    # Query specifications
├── Infrastructure/        # Data access layer
│   ├── Data/             # Entity Framework context
│   ├── Services/         # Business services
│   └── Identity/         # Identity configuration
└── client/               # Vue.js frontend
    ├── src/
    │   ├── components/   # Reusable components
    │   ├── views/        # Page components
    │   ├── store/        # Vuex store
    │   └── services/     # API services
    └── public/           # Static assets
```

## 🚦 Getting Started

### Prerequisites

Before running this project, make sure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v14 or higher)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Docker](https://www.docker.com/get-started) (optional, for Redis)
- [Git](https://git-scm.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/laithSM01/skinet.git
   cd skinet
   ```

2. **Set up PostgreSQL Database**
   - Install PostgreSQL and create two databases:
     - `skinet` (main application database)
     - `skinetIdentity` (identity/authentication database)

3. **Configure Connection Strings**
   
   Update `API/appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Port=5432;Database=skinet;User Id=your_username;Password=your_password;",
       "IdentityConnection": "Server=localhost;Port=5432;Database=skinetIdentity;User Id=your_username;Password=your_password;",
       "Redis": "localhost:6379"
     },
     "StripeSettings": {
       "SecretKey": "your_stripe_secret_key_here"
     }
   }
   ```

4. **Start Redis (using Docker)**
   ```bash
   docker-compose up -d
   ```
   
   This starts:
   - Redis server on port 6379
   - Redis Commander (web UI) on port 8081

5. **Set up the Backend**
   ```bash
   # Navigate to API directory
   cd API
   
   # Restore NuGet packages
   dotnet restore
   
   # Run database migrations (creates tables and seeds data)
   dotnet ef database update
   
   # Start the API server
   dotnet run
   ```
   
   The API will be available at: `https://localhost:5212`

6. **Set up the Frontend**
   ```bash
   # Navigate to client directory
   cd client
   
   # Install npm packages
   npm install
   
   # Start the development server
   npm run serve
   ```
   
   The frontend will be available at: `https://localhost:4200`

### 🔑 Default Credentials

The application seeds with sample data including:

- **Test User**: 
  - Email: `test@test.com`
  - Password: `Pa$$w0rd`

### 🌐 Access Points

- **Frontend Application**: https://localhost:4200
- **API Swagger Documentation**: https://localhost:5212/swagger
- **Redis Commander**: http://localhost:8081
  - Username: `root`
  - Password: `secret`

## 📝 API Endpoints

### Products
- `GET /api/products` - Get all products with filtering/pagination
- `GET /api/products/{id}` - Get product by ID
- `GET /api/products/brands` - Get all product brands
- `GET /api/products/types` - Get all product types

### Authentication
- `POST /api/account/login` - User login
- `POST /api/account/register` - User registration
- `GET /api/account` - Get current user

### Basket
- `GET /api/basket/{id}` - Get basket by ID
- `POST /api/basket` - Create/update basket
- `DELETE /api/basket/{id}` - Delete basket

### Orders
- `POST /api/orders` - Create new order
- `GET /api/orders` - Get user orders
- `GET /api/orders/{id}` - Get order by ID

### Payments
- `POST /api/payments/{basketId}` - Create payment intent
