# University Management System

## Overview
The **University Management System** is a modular application built with ASP.NET Core 8 and Entity Framework Core. It provides functionality for managing university-related data, such as students, courses, enrollments, and more. The project is designed with a layered architecture to ensure scalability, maintainability, and separation of concerns.

---

## Features
- Modular architecture with separate layers for core logic, data access, and presentation.
- Support for multiple database providers (SQLite and SQL Server).
- Entity Framework Core for ORM and database migrations.
- Swagger integration for API documentation.
- Built with .NET 8 and C# 12.
- Comprehensive API for managing:
  - Students
  - Courses
  - Enrollments
- Validation to prevent duplicate enrollments.
- Transaction management using the Unit of Work pattern.

---

## Project Structure
The solution is divided into the following projects:

### **1. UniversityManagementSystem.Core**
- Contains the core domain entities and business logic.
- Example entities:
  - `Student`
  - `Course`
  - `Enrollment`

### **2. UniversityManagementSystem.Application**
- Handles application-level logic, such as services and DTOs.
- Implements validation, mapping, and business rules.
- Example services:
  - `StudentService`
  - `CourseService`
  - `EnrollmentService`

### **3. UniversityManagementSystem.EntityFrameworkCore**
- Implements the data access layer using Entity Framework Core.
- Includes `DbContext` implementations for SQLite and SQL Server:
  - `UniversityManagementSystemSqLiteDbContext`
  - `UniversityManagementSystemSqlDbContext`
- Repositories for managing database operations:
  - `StudentRepository`
  - `CourseRepository`
  - `EnrollmentRepository`

### **4. UniversityManagementSystem.Web**
- The entry point of the application.
- Configures services, middleware, and API endpoints.
- Includes controllers for:
  - Students
  - Courses
  - Enrollments

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

For SQLite:
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

### **API Endpoints**
#### **Students**
- `GET /api/students/withcourses`: Get all students with their enrolled courses.
- `POST /api/students`: Add a new student.

#### **Courses**
- `GET /api/courses/withstudents`: Get all courses with their enrolled students.
- `GET /api/courses/student/{email}`: Get all courses for a specific student by email.
- `POST /api/courses`: Add a new course.

#### **Enrollments**
- `POST /api/enrollments`: Enroll a student in a course.
- `GET /api/enrollments/exists`: Check if a student is already enrolled in a course.

---

## Entities
### **Student**
- `Id` (GUID): Primary key.
- `Name` (string): Name of the student.
- `Email` (string): Email address of the student.
- `DateOfBirth` (DateTime?): Date of birth of the student.

### **Course**
- `Id` (GUID): Primary key.
- `Name` (string): Name of the course.
- `Code` (string): Unique code for the course.
- `Credits` (int?): Number of credits for the course.

### **Enrollment**
- `Id` (GUID): Primary key.
- `StudentId` (GUID): Foreign key referencing `Student`.
- `CourseId` (GUID): Foreign key referencing `Course`.
- `EnrollmentDate` (DateTime): Date when the student was enrolled.

---

## Features Added
1. **Validation**:
   - Prevent duplicate enrollments (same student, same course).
   - Ensure required fields are provided for all entities.

2. **Transaction Management**:
   - Implemented the Unit of Work pattern to handle database transactions.

3. **Enhanced Queries**:
   - Fetch students with their courses in a single query.
   - Fetch courses with their enrolled students in a single query.
   - Fetch courses for a specific student by email.

4. **Error Handling**:
   - Return appropriate HTTP status codes for validation errors, conflicts, and not found scenarios.

---

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request.

---

## License
This project is licensed under the MIT License. See the `LICENSE` file for details.
