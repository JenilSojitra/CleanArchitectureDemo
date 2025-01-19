# Clean Architecture .NET Solution Template

## 🌟 Overview
A modern, clean architecture template for .NET applications following domain-driven design principles and best practices. This template provides a solid foundation for building scalable, maintainable, and testable applications.

## 🏗️ Architecture Overview

```
CleanArchitectureDemo/
├── Domain/             # Enterprise/domain entities & business rules
├── Application/        # Business logic & use cases
├── Infrastructure/     # External concerns (database, file systems, etc.)
├── WebApi/            # User interface & API endpoints
└── UnitTests/         # Unit tests for all layers
```

### Layer Details

#### 🎯 Domain Layer
- Contains enterprise/business logic
- Entities
- Value Objects
- Domain Events
- Interfaces
- Business Rules
- No dependencies on other layers

#### 🔄 Application Layer
- Contains application logic
- Implements use cases
- DTOs
- Interfaces
- Service implementations
- Dependencies: Domain layer

#### 🛠️ Infrastructure Layer
- Implementation of interfaces from Domain/Application layers
- Database contexts
- Repositories implementations
- External service implementations
- Dependencies: Domain and Application layers

#### 🌐 WebApi Layer
- API Controllers
- API Models
- Middleware
- Dependencies: Application layer

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio 2022 or VS Code
- SQL Server (optional - template uses InMemory database by default)

### Installation

1. Clone the repository
```bash
git clone https://github.com/JenilSojitra/CleanArchitectureDemo.git
cd CleanArchitectureDemo
```

2. Build the solution
```bash
dotnet build
```

3. Run the tests
```bash
dotnet test
```

4. Run the application
```bash
cd CleanArchitecture.WebApi
dotnet run
```

### API Endpoints

#### Products API
```
GET     /api/products      # Get all products
GET     /api/products/{id} # Get product by id
POST    /api/products      # Create new product
PUT     /api/products/{id} # Update product
DELETE  /api/products/{id} # Delete product
```

## 🧪 Testing

### Unit Tests
The solution includes comprehensive unit tests for all layers:

- **Domain Tests**: Testing business rules and entity behavior
- **Application Tests**: Testing service implementations with mocked dependencies
- **Infrastructure Tests**: Testing repository implementations using in-memory database

Run unit tests:
```bash
dotnet test CleanArchitecture.UnitTests/CleanArchitecture.UnitTests.csproj
```

## 📝 Project Structure

```
CleanArchitecture/
├── Domain/
│   ├── Entities/
│   │   └── Product.cs
│   └── Interfaces/
│       └── IProductRepository.cs
│
├── Application/
│   ├── DTOs/
│   │   └── ProductDto.cs
│   ├── Interfaces/
│   │   └── IProductService.cs
│   └── Services/
│       └── ProductService.cs
│
├── Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   └── Repositories/
│       └── ProductRepository.cs
│
├── WebApi/
│   ├── Controllers/
│   │   └── ProductsController.cs
│   └── Program.cs
│
└── UnitTests/
    ├── Domain/
    │   └── ProductTests.cs
    ├── Application/
    │   └── ProductServiceTests.cs
    └── Infrastructure/
        └── ProductRepositoryTests.cs
```

## 🛠️ Technology Stack

- **.NET 8.0**: Modern, high-performance framework
- **Entity Framework Core**: ORM for data access
- **xUnit**: Testing framework
- **Moq**: Mocking framework for unit tests
- **Swagger/OpenAPI**: API documentation
- **InMemory Database**: For testing and development

## 🎯 Features

- ✅ Clean Architecture implementation
- ✅ Domain-Driven Design principles
- ✅ SOLID principles
- ✅ Unit testing with xUnit and Moq
- ✅ InMemory database for testing
- ✅ Swagger documentation
- ✅ API versioning
- ✅ Dependency Injection
- ✅ Async/await best practices

## 🙏 Acknowledgments

- Clean Architecture by Robert C. Martin
- Microsoft .NET Documentation
- Entity Framework Core Documentation
- xUnit Documentation

## 📞 Contact

Your Name - [@JEMSBON00966575](https://x.com/@JEMSBON00966575)

Project Link: [https://github.com/JenilSojitra/CleanArchitectureDemo.git](https://github.com/JenilSojitra/CleanArchitectureDemo.git)

---
⭐️ Star this repository if you find it helpful!