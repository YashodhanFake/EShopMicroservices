# EShopMicroservices

This is my implementation for the course [.NET 8 Microservices](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet).

## Catlog Service
- Patterns & Principles
  - Vertical Slice Architecture
  - CQRS Pattern
  - Mediator Pattern: for implement CQRS
  - Dependency Injection
  - Minimal APIs
  - ORM Pattern
- Library
  - MediatR for CQRS: This library simplifies the implementation of the CQRS pattern.
  - Carter for API Endpoints: Routing and handling HTTP request, easier to define API endpoints with clean and concise code.
  - Marten ORM for PostgreSQL Interaction: Use PostgreSQL as a Document DB. It leverages PostgreSQL's JSON capabilities for storing, querying, and managing documents.
  - Mapster for Object Mapping
  - FluentValidation for Input Validation
- Datastore
  - PostgreSQL used as a Document database (Marten ORM): By using PostgreSQL's JSON column features, Marten ORM transforms PostgreSQL into `.NET Transactional Document DB`
## Basket Service
- Patterns & Principles
  - Vertical Slice Architecture
  - CQRS Pattern
  - Mediator Pattern: for implement CQRS
  - Repository Pattern
  - Proxy Pattern: for implement Distributed cache
  - Decorator Pattern: for implement Distributed cache
  - Dependency Injection
  - Minimal APIs
  - ORM Pattern
- Library
  - MediatR for CQRS: This library simplifies the implementation of the CQRS pattern.
  - Carter for API Endpoints: Routing and handling HTTP request, easier to define API endpoints with clean and concise code.
  - Marten ORM for PostgreSQL Interaction: Use PostgreSQL as a Document DB. It leverages PostgreSQL's JSON capabilities for storing, querying, and managing documents.
  - Mapster for Object Mapping
  - FluentValidation for Input Validation
  - Scrutor for implement decorator pattern: By registering decorator in DI Container
  - gRPC for inter service communication
  - Redis for distributed cache
  - MassTransit for RabbitMQ operations
- Datastore
  - PostgreSQL used as a Document database (Marten ORM): By using PostgreSQL's JSON column features, Marten ORM transforms PostgreSQL into `.NET Transactional Document DB`
  - Redis distrubuted cache
