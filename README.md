# Inventory Management System

## Projects
- **InventoryManagementSystem.Api**: Presentation Layer, providing endpoints and functionality for the platform.
- **InventoryManagementSystem.Db**: Data access Layer for managing database interactions. This includes the use of Entity Framework Core (EF Core) for working on Object-Relational Mapping (ORM).
- **InventoryManagementSystem**: Business Logic Layer, handles core business logic.
- **InventoryManagementSystem.Tests**: Contains unit tests to ensure the reliability and correctness of the platform.
- **InventoryManagementSystem.Common**: Utilities, and helpers.

## Frameworks
* xUnit - for testing

## Dependencies
- .NET Core 8 SDK
- PostgreSQL database

## Getting Started
This will guide you through the process of installing and configuring the necessary dependencies and getting the application running on your local machine.

1. **Prerequisites**<br>
Before you begin, ensure you have the following installed on your system:
	- .NET Core 8 SDK.
	- PostgreSQL.

2. **Configure the Database**<br>
Create a new database for the inventory management system:
```bash
CREATE DATABASE InventorySystem;
```

3. **Clone the Repository**<br>
To get the source code onto your machine, open your terminal or command prompt and run the following command:
```bash
git clone https://github.com/Reema-Khaseeb/Inventory-Management-System2.git
```

4. **Navigate to Root Directory**<br>
```bash
cd Inventory-Management-System2/InventoryManagementSystem
```

5. **Update the database Connection String in the appsettings.json file with your PostgreSQL details**<br>
```bash
"ConnectionStrings": {
  "DefaultConnection": "your conneciton string"
}
```

6. **Restore dependencies and build the project:**
```bash
dotnet restore
```
7. **Create the database schema:**
```bash
dotnet ef database update
```
8. **Run the Application**
```bash
dotnet run
```
