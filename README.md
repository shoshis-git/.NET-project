# Bakery API

A .NET 8 Web API for managing a bakery system, including products, customers, and orders.  
The project uses Entity Framework Core, JWT authentication, and follows a layered architecture with repositories, services, DTOs, and controllers.

## Features

- **Products**: Manage bakery products (CRUD)
- **Customers**: Manage customer data (CRUD)
- **Orders**: Place and track orders, including status updates
- **Authentication**: JWT-based login and authorization
- **DTO Mapping**: Uses AutoMapper for mapping between entities and DTOs
- **Swagger**: API documentation and testing

## Project Structure

```
bakery/
├── bakery.API/           # ASP.NET Core Web API (controllers, startup)
├── bakery.Core/          # Entities, DTOs, interfaces
├── bakery.Data/          # EF Core DbContext, repositories
├── bakery.Services/      # Business logic (services)
```

### Main Entities

- **Products**: `Id`, `Name`, `Price`, `Orders`
- **Customers**: `Id`, `Name`, `Email`, `Phone`, `Orders`
- **Orders**: `Id`, `ProductId`, `CustomerId`, `Status`, `Customer`, `Product`
- **EnumStatuses**: `Invating`, `InProgress`, `Sending`, `Completed`, `Cancelled`

### DTOs

- `ProductDTO`
- `CustomerDto`
- `OrderDTO`

### Key Controllers

- `ProductsController`
- `CustomersController`
- `OrdersController`
- `AuthController` (for login/authentication)

### Authentication

- JWT-based authentication
- Claims include user name and role
- Secure endpoints with `[Authorize]` attribute

## Getting Started

1. **Clone the repository**
2. **Configure your database** in `appsettings.json`
3. **Run migrations** to create the database schema
4. **Run the API** (`dotnet run` or via Visual Studio)
5. **Access Swagger UI** at `/swagger` for API documentation and testing

## Example API Endpoints

- `GET /api/products` - List all products
- `POST /api/customers` - Add a new customer
- `POST /api/orders` - Place a new order
- `POST /api/auth/login` - Authenticate and receive JWT

## Technologies

- .NET 8
- Entity Framework Core
- AutoMapper
- JWT Authentication
- Swagger (OpenAPI)

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---


