# bsStoreApp

`bsStoreApp` is a backend project developed using **ASP.NET Core Web API** and **SQL Server**, intended for managing store-related functionalities. This document provides an overview of the project, its features, and how to set it up.

## Features

- **Layered Architecture**: Ensures separation of concerns with a clean and maintainable codebase.
- **RESTful API Endpoints**: CRUD operations for managing entities related to a store application.
- **SQL Server Integration**: Uses SQL Server as the database management system.
- **Configuration-Driven**: Easily customizable using environment variables and configuration files.

## Technologies Used

- **.NET Core**: For building the backend Web API.
- **SQL Server**: As the database.
- **Entity Framework Core**: For object-relational mapping (ORM).
- **Swagger**: For API documentation and testing.
- **Logging**: Implemented using NLog for efficient tracking and debugging.
- **AutoMapper**: Simplifies object-object mapping.
- **Asynchronous Code**: Improves application responsiveness and scalability.
- **Action Filters**: Enhances request handling with pre/post-processing.
- **HATEOAS**: Implements Hypermedia as the Engine of Application State.
- **Validation**: Ensures data integrity.
- **Content Negotiation**: Supports multiple data formats like JSON and XML.
- **Pagination, Filtering, Searching, Sorting**: Handles large datasets efficiently.
- **Global Error Handling**: Improves user experience and debugging.
- **Caching**: Optimizes performance by reducing redundant computations.
- **Rate Limiting**: Prevents abuse by limiting API requests.
- **JWT Authentication and Refresh Tokens**: Secures endpoints with token-based authentication.
- **API Versioning**: Ensures backward compatibility.

## Prerequisites

Ensure the following are installed on your system:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- A REST client like [Postman](https://www.postman.com/) or [curl](https://curl.se/).

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/hayro45/DotnetCoreWebApi.git
   cd DotnetCoreWebApi/bsStoreApp
   ```

2. Configure the database:
   - Create a SQL Server database.
   - Update the `appsettings.json` file with your SQL Server connection string:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=YourServerName;Database=YourDatabase;User Id=YourUsername;Password=YourPassword;"
     }
     ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. Access the API documentation:
   - Open a browser and navigate to `http://localhost:<port>/swagger` to explore the endpoints.

## Usage

Use a REST client like Postman or curl to interact with the API. Example requests:

- **GET** all products:
  ```bash
  curl -X GET http://localhost:<port>/api/products
  ```
- **POST** a new product:
  ```bash
  curl -X POST http://localhost:<port>/api/products \
       -H "Content-Type: application/json" \
       -d '{"name": "Product Name", "price": 100, "stock": 50}'
  ```

## Project Structure

```
bsStoreApp/
├── Entities/            # Data models and DTOs
├── ErrorModel/          # Error handling models
├── Exceptions/          # Custom exceptions
├── LinkModels/          # HATEOAS link management
├── LogModel/            # Logging-related models
├── Models/              # Additional entity models
├── RequestFeatures/     # Pagination, filtering, and sorting utilities
├── Presentation/
│   ├── ActionFilters/   # Request/response action filters
│   ├── Controllers/     # API controllers
│   └── Presentation.csproj
├── Repositories/
│   ├── Contracts/       # Repository interfaces
│   ├── EFCore/          # Entity Framework Core implementations
│   └── Repositories.csproj
├── Services/
│   ├── AuthenticationManager.cs # JWT and identity management
│   ├── BookLinks.cs             # Link generation for books
│   ├── BookManager.cs           # Business logic for books
│   ├── CategoryManager.cs       # Business logic for categories
│   ├── DataShaper.cs            # Dynamic data shaping
│   ├── LoggerManager.cs         # Logging manager
│   ├── ServiceManager.cs        # Service orchestration
│   └── Services.csproj
├── WebApi/
│   ├── ContextFactory/   # Database context factory
│   ├── Extensions/       # Extension methods
│   ├── Migrations/       # Database migrations
│   ├── Properties/       # Assembly properties
│   ├── Utilities/        # Utility classes
│   ├── Program.cs        # Entry point
│   ├── appsettings.json  # Configuration file
│   ├── nLog.config       # NLog configuration
│   └── WebApi.csproj
└── bin/Debug/net6.0/     # Build output
```

## Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.

---

For any questions or feedback, please feel free to contact the repository owner.
