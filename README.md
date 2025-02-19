# EShopMicroservices

This is my implementation for the course [.NET 8 Microservices](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet).

## Design Pattern
- Catalog Service
  - Vertical Slice Architecture
  - CQRS Pattern
  - Mediator Pattern
  - Dependency Injection
  - Minimal APIs
  - ORM Pattern
## Library
- Catalog Service
  - MediatR for CQRS: This library simplifies the implementation of the CQRS pattern.
  - Carter for API Endpoints: Routing and handling HTTP request, easier to define API endpoints with clean and concise code.
  - Marten ORM for PostgreSQL Interaction: Use PostgreSQL as a Document DB. It leverages PostgreSQL's JSON capabilities for storing, querying, and managing documents.
  - Mapster for Object Mapping
  - FluentValidation for Input Validation
