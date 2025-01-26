# FlightBooking Reservation API

## About

This repository demonstrates my expertise in various architectures and design patterns, including:

- **API Design**
- **Clean Architecture**
- **Domain-Driven Design (DDD)**
- **Command Query Responsibility Segregation (CQRS)**
- **MediatR**
- **Specifications Pattern**
- **Repository Pattern**

## Project Structure

The project is built over multiple layers, each with a different responsibility, following the principles of Clean Architecture:

### Presentation/Endpoints Layer
- Responsible for exposing data, allowing third parties to make calls to the endpoints and GET or POST data.

### Mediator Layer
- Utilizes the MediatR pattern to facilitate communication between endpoints and backend services, ensuring cleaner and more organized code.

### Domain Layer
- Contains the core business logic, including models and services such as the Reservation service, following Domain-Driven Design (DDD) principles.

### Infrastructure Layer
- Manages data repositories, providing methods to add, remove, or list data. The Flight and Promotion repositories are seeded from JSON files whenever you run the application, implementing the Repository pattern.

### Specifications Pattern
- Used to encapsulate the logic of querying data, making the code more readable and maintainable.

### CQRS
- Separates the read and write operations to optimize performance and scalability.

## API Overview

1. The API exposes the following operations (see appendixes for further details):
    * [GET /Flight](AppendixI.md): Used to search for available flights on a certain date between two different locations.
    * [POST /Reservation](AppendixII.md): Used to create a reservation in the system.
    * [GET /Reservation](AppendixIII.md): Used to retrieve a reservation previously made.
2. Every endpoint returns appropriate error messages when the operation cannot be achieved for some reason.
3. For storage, we use in-memory collections to avoid external dependencies.
4. For the initial data state, use the [provided JSON](InitialState.json/initialStatePromotion.json).

## Swagger UI

You can explore the API using Swagger UI at:
[http://localhost:5005/swagger/index.html](http://localhost:5005/swagger/index.html)

---

