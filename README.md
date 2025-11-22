UnitOfWorkAndxUnit

This repository demonstrates a clean and modular implementation of the Unit of Work and Generic Repository design patterns in a .NET environment, accompanied by xUnit unit tests. The project follows a layered architecture to ensure scalability, maintainability, and testability—making it a solid foundation for real-world enterprise-level API development.

---

FEATURES

* Full implementation of the Unit of Work Pattern
* Generic Repository Pattern for reusable data access logic
* xUnit test project with isolated and clean unit tests
* Layered architecture (Domain, Infrastructure, Application, API)
* Entity Framework Core integration
* Ready-to-use RESTful API structure
* Extensible codebase suitable for production environments
* Optional Docker support

---

PROJECT STRUCTURE

UnitOfWorkAndxUnit.sln
│
├── UnitOfWorkDemo.Domain
│   ├── Entities
│   ├── Interfaces
│   └── Base Domain Models
│
├── UnitOfWorkDemo.Infrastructure
│   ├── EF Core DbContext
│   ├── Generic Repository Implementations
│   ├── Unit of Work Implementation
│   └── Dependency Injection Containers
│
├── UnitOfWorkDemo.Application
│   ├── Services
│   ├── DTOs
│   └── Business Rules
│
├── UnitOfWorkDemo.Tests
│   ├── xUnit Test Cases
│   └── Mocked Dependencies
│
├── UnitOfWorkAndxUnit.ReportingApi
└── UnitOfWorkAndUnitTest.Api

---

TECHNOLOGIES USED

* C# / .NET
* Entity Framework Core
* xUnit
* Moq (if used)
* RESTful Web API
* Docker (optional)

---

GETTING STARTED

1. Clone the repository:
   git clone [https://github.com/UtkucanSahinoglu/UnitOfWorkAndxUnit.git](https://github.com/UtkucanSahinoglu/UnitOfWorkAndxUnit.git)
   cd UnitOfWorkAndxUnit

2. Restore packages:
   dotnet restore

3. Configure the database:
   Edit appsettings.json and update the connection string:
   "ConnectionStrings": {
   "DefaultConnection": "Server=.;Database=UnitOfWorkDb;Trusted_Connection=True;"
   }

4. Apply migrations:
   dotnet ef database update

5. Run the API:
   dotnet run --project UnitOfWorkAndUnitTest.Api

6. Run unit tests:
   dotnet test

---

ARCHITECTURE OVERVIEW

UNIT OF WORK PATTERN
Manages and coordinates multiple repository operations under a single transaction, ensuring consistency and atomicity.

GENERIC REPOSITORY PATTERN
Provides reusable CRUD operations for entities, reducing boilerplate and improving maintainability.

HIGH-LEVEL FLOW
Controller → Application Service → Unit of Work → Repository → DbContext

---

TESTING

The UnitOfWorkDemo.Tests project includes:

* Service-layer tests
* Repository tests
* Mocked dependencies
* Clean and repeatable xUnit test structures

Run all tests:
dotnet test

---

EXAMPLE USE CASES

This project demonstrates:

* Creating and managing entities using the generic repository
* Executing multiple operations inside a single Unit of Work
* Querying and updating data with consistent business rules
* Writing isolated and maintainable unit tests

---

DOCKER SUPPORT (Optional)

docker build -t unitofwork-api .
docker run -p 5000:80 unitofwork-api

---

CONTRIBUTING

1. Fork the repository
2. Create a new branch (feature/my-change)
3. Commit your updates
4. Submit a pull request

---

LICENSE

This project is licensed under the MIT License.
See the LICENSE file for details.

---

CONTACT

For questions, suggestions, or collaboration:
utkucannsahinoglu@gmail.com

