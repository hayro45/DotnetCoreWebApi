# bsStoreApp

`bsStoreApp` is a backend project developed using **ASP.NET Core Web API** and **PostgreSQL**, intended for managing store-related functionalities. This document provides an overview of the project, its features, and how to set it up.

## Features

- **Layered Architecture**: Ensures separation of concerns with a clean and maintainable codebase.
- **RESTful API Endpoints**: CRUD operations for managing entities related to a store application.
- **PostgreSQL Integration**: Uses PostgreSQL as the database management system.
- **Configuration-Driven**: Easily customizable using environment variables and configuration files.

## Technologies Used

- **.NET Core**: For building the backend Web API.
- **PostgreSQL**: As the database.
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
- [PostgreSQL](https://www.postgresql.org/download/)
- A REST client like [Postman](https://www.postman.com/) or [curl](https://curl.se/).

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/hayro45/DotnetCoreWebApi.git
   cd DotnetCoreWebApi/bsStoreApp
   ```

2. Configure the database:
   - Create a PostgreSQL database.
   - Update the `appsettings.json` file with your PostgreSQL connection string:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Database=YourDatabase;Username=YourUsername;Password=YourPassword"
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
├── Controllers/       # API Controllers
├── Data/              # Database context and migrations
├── Models/            # Entity models
├── Services/          # Business logic
├── appsettings.json   # Configuration file
├── Filters/           # Action filters for request handling
├── Mappings/          # AutoMapper profiles
├── Middlewares/       # Custom middleware implementations
└── Program.cs         # Entry point
```

## Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](../LICENSE) file for details.

---

For any questions or feedback, please feel free to contact the repository owner.
