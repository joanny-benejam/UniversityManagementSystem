# University Management System

## Overview
The **University Management System** is a modular application built with ASP.NET Core 8 and Entity Framework Core. It provides functionality for managing university-related data, such as students, courses, and more. The project is designed with a layered architecture to ensure scalability, maintainability, and separation of concerns.

---

## Features
- Modular architecture with separate layers for core logic, data access, and presentation.
- Support for multiple database providers (SQLite and SQL Server).
- Entity Framework Core for ORM and database migrations.
- Swagger integration for API documentation.
- Built with .NET 8 and C# 12.

---

## Project Structure
The solution is divided into the following projects:

### **1. UniversityManagementSystem.Core**
- Contains the core domain entities and business logic.
- Example entity: `Student`.

### **2. UniversityManagementSystem.Application**
- Handles application-level logic, such as services and DTOs.
- (To be implemented or expanded.)

### **3. UniversityManagementSystem.EntityFrameworkCore**
- Implements the data access layer using Entity Framework Core.
- Includes `DbContext` implementations for SQLite and SQL Server:
  - `UniversityManagementSystemSqLiteDbContext`
  - `UniversityManagementSystemSqlDbContext`

### **4. UniversityManagementSystem.Web**
- The entry point of the application.
- Configures services, middleware, and API endpoints.

---

## Configuration

### **Database Configuration**
The application supports multiple database providers. Configure the database in the `appsettings.json` file:

#### Example for SQLite:
```json
    "Database": {
        "Provider": "sqlite",
        "SqliteConnection": "Data Source=Data/UniversityManagementSystem.db"
      },
```
#### Example for SQL Server:
```json
    "Database": {
        "Provider": "sqlserver",
        "SqlServerConnection": "Server=localhost;Database=UniversityManagementSystemDb;User Id=sa;Password=password*;TrustServerCertificate=True;"
      },
```

### **Switching Database Providers**
The database provider is determined by the `Database:Provider` key in `appsettings.json`. Supported values:
- `sqlite`
- `sqlserver`

---

## Setup Instructions

### **1. Prerequisites**
- .NET 8 SDK installed.
- SQL Server (if using SQL Server as the database provider).

### **2. Clone the Repository**
```
    git clone https://github.com/joanny-benejam/UniversityManagementSystem.git
```

### **3. Install Dependencies**
Restore NuGet packages:
```
    dotnet restore
```

### **4. Configure the Database**
Update the `appsettings.json` file with the appropriate database provider and connection string.

### **5. Apply Migrations**
Run the following commands to create and apply migrations:
```
    dotnet ef migrations add Initial -c UniversityManagementSystemSqLiteDbContext 
    dotnet ef database update -c UniversityManagementSystemSqLiteDbContext
```

For SQL Server:
```
    dotnet ef migrations add Initial -c UniversityManagementSystemSqlDbContext 
    dotnet ef database update -c UniversityManagementSystemSqlDbContext
```

### **6. Run the Application**
Start the application:
```
    dotnet run --project UniversityManagementSystem.Web
```

---

## Usage
- Access the API documentation at `https://localhost:<7295>/swagger` (in development mode).
- Use the API endpoints to manage university data.

---

## Entities
### **Student**
- `Id` (GUID): Primary key.
- `Name` (string): Name of the student.
- `Email` (string): Email address of the student.
- `DateOfBirth` (DateTime?): Date of birth of the student.

---

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request.

---

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.