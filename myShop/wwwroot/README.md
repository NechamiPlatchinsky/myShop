# ClientSideFiles
Html and css files for shop


# myShop - .NET 8 Web API Project

This project demonstrates a RESTful Web API built with .NET 8, adhering to key architectural principles to ensure scalability, maintainability, and clean code practices.

## Table of Contents
- [Project Overview](#project-overview)
- [API Documentation](#api-documentation)
- [Project Structure](#project-structure)
- [Data Transfer Objects (DTOs)](#data-transfer-objects-dtos)
- [Layered Architecture](#layered-architecture)
- [Dependency Injection (DI)](#dependency-injection-di)
- [Asynchronous Programming](#asynchronous-programming)
- [Database Integration](#database-integration)
- [Configuration Files](#configuration-files)
- [Error Handling](#error-handling)
- [Request Logging](#request-logging)
- [Clean Code](#clean-code)

## Project Overview
This project is a Web API built using .NET 8, designed to follow REST architectural principles. The API provides endpoints for managing categories, orders, products, and users within the system.

## API Documentation
The API is documented using Swagger. You can access the Swagger UI to explore and test the endpoints.

## Project Structure
The project is structured into various layers to promote separation of concerns and maintainability. Each layer has a specific responsibility, and the communication between layers is managed using Dependency Injection (DI).

### Data Transfer Objects (DTOs)
DTOs are used to encapsulate data and transfer it between layers. The conversion between different layer models is handled using AutoMapper.

### Layered Architecture
- **Presentation Layer**: Handles HTTP requests and responses.
- **Business Logic Layer**: Contains the core business logic.
- **Data Access Layer**: Manages data retrieval and storage.

### Dependency Injection (DI)
DI is used to manage dependencies between layers, promoting loose coupling and easier testing.

## Asynchronous Programming
To ensure scalability and better performance, asynchronous programming (async/await) is used throughout the project.

## Database Integration
The project uses SQL database with Code First approach for database creation and management. To create the database, use the provided commands in the project documentation.

## Configuration Files
Configuration settings are managed through config files, ensuring that configuration changes can be made without altering the code.

## Error Handling
All errors are handled using middleware. Errors are logged using a logger, and fatal errors are sent via email notifications.

## Request Logging
Every request to the system is logged for rating and analysis purposes.

## Clean Code
The project follows clean code principles to ensure readability, maintainability, and scalability.

## OpenAPI Specification
The following is a brief overview of the API endpoints and their specifications:

### Category Endpoints
- **GET /api/Category**: Retrieves a list of categories.

### Order Endpoints
- **GET /api/Order/{id}**: Retrieves an order by ID.
- **POST /api/Order**: Creates a new order.

### Product Endpoints
- **GET /api/Product**: Retrieves a list of products with optional filters (position, skip, desc, minPrice, maxPrice, categoryIds).
- **GET /api/Product/{id}**: Retrieves a product by ID.

### User Endpoints
- **GET /api/Users/{id}**: Retrieves a user by ID.
- **PUT /api/Users/{id}**: Updates a user by ID.
- **POST /api/Users**: Creates a new user.
- **POST /api/Users/login**: Authenticates a user.
- **POST /api/Users/password**: Resets a user's password.

## Components and Schemas
The OpenAPI specification includes detailed schemas for Category, Order, Product, User, and their corresponding DTOs. Refer to the Swagger UI for complete details on request and response models.

## Conclusion
This project serves as a comprehensive example of building a scalable, maintainable, and well-architected Web API using .NET 8. It demonstrates best practices in API design, layered architecture, dependency injection, asynchronous programming, error handling, and more.

## Contact
38214416448@mby.co.il