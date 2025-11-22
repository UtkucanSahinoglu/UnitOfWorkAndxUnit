# UnitOfWorkAndxUnit

This repository demonstrates a clean and modular implementation of the **Unit of Work** and **Generic Repository** design patterns in a .NET environment, accompanied by **xUnit** unit tests.  
The project follows a layered architecture to ensure scalability, maintainability, and testability—making it a solid foundation for enterprise-level API development.

---

## ⭐ Features

- Full implementation of the **Unit of Work Pattern**
- **Generic Repository Pattern** for reusable and maintainable data access
- **xUnit** test project with clean and isolated unit tests
- Layered architecture (Domain, Infrastructure, Application, API)
- Entity Framework Core integration
- Ready-to-use RESTful API structure
- Extensible codebase suitable for real-world applications
- Optional Docker support

---

## 📁 Project Structure

UnitOfWorkAndxUnit.sln
│
├── UnitOfWorkDemo.Domain
│ ├── Entities
│ ├── Interfaces
│ └── Base Domain Models
│
├── UnitOfWorkDemo.Infrastructure
│ ├── EF Core DbContext
│ ├── Generic Repository Implementations
│ ├── Unit of Work Implementation
│ └── Dependency Injection Containers
│
├── UnitOfWorkDemo.Application
│ ├── Services
│ ├── DTOs
│ └── Business Rules
│
├── UnitOfWorkDemo.Tests
│ ├── xUnit Test Cases
│ └── Mocked Dependencies
│
├── UnitOfWorkAndxUnit.ReportingApi
└── UnitOfWorkAndUnitTest.Api

---

## 🛠 Technologies Used

- **C# / .NET**
- **Entity Framework Core**
- **xUnit**
- **Moq** (if used)
- **RESTful Web API**
- **Docker** (optional)

---

## 🚀 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/UtkucanSahinoglu/UnitOfWorkAndxUnit.git
cd UnitOfWorkAndxUnit
dotnet restore
dotnet ef database update
dotnet run --project UnitOfWorkAndUnitTest.Api
dotnet test
🧩 Architecture Overview
🔹 Unit of Work Pattern

Coordinates multiple repository operations under a single transaction, ensuring atomicity and consistency.

🔹 Generic Repository Pattern

Provides reusable CRUD operations, minimizing boilerplate and improving maintainability.

🔹 High-Level Flow
Controller → Application Service → Unit of Work → Repository → DbContext

🧪 Testing

The UnitOfWorkDemo.Tests project includes:

Service-layer unit tests

Repository tests

Mocked dependencies (if used)

Clean and repeatable xUnit test structures

Run all tests:

dotnet test

📘 Example Use Cases

This project demonstrates:

Creating and managing entities using the generic repository

Executing multiple operations within a single Unit of Work

Querying and updating data following consistent business rules

Writing isolated, maintainable, and testable code

🐳 Docker Support (Optional)
docker build -t unitofwork-api .
docker run -p 5000:80 unitofwork-api

🤝 Contributing

Fork the repository

Create a new branch: feature/my-change

Commit your updates

Submit a pull request

📄 License

This project is licensed under the MIT License.
See the LICENSE file for more information.

📬 Contact

For questions, suggestions, or collaboration:
📧 utkucannsahinoglu@gmail.com
