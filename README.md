# E-Commerce Solution

This is a simple e-commerce api built with .NET 8 and Entity Framework Core (EF Core) to create Orders.

## Project Structure

The solution is divided into three projects:

1. **API**: This is the API layer of the application. It exposes endpoints for managing orders.

2. **Domain**: This is the domain layer of the application. It contains the business logic and domain models

3. **Infrastructure**: This is the infrastructure layer of the application. It contains data access logic and database configurations. It uses EF Core to interact with the SQL Server database and manage database migrations.


## Getting Started

### Prerequisites

- .NET 8
- SQL Server


## Usage

You can use the following endpoints to manage orders:

- `POST /api/order`: Creates a new order.

## License

This project is licensed under the MIT License - see the LICENSE.md file for details.
