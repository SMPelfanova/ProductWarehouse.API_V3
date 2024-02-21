# Phase 2

# Phase 1 + 
- **EF Core with MSSQL**
- **EF Core - Code First Approach, Fluent API, Configuration Files**
- **Repository Pattern with Generic Approach**
- **CRUD operations**

  
![image](https://github.com/SMPelfanova/ProductWarehouse.API_V2/assets/90159933/4fbad368-161f-4449-8c3f-a6b46e4c4963)

# Phase 1 - Product Wherehouse API
The API endpoint allows users to retrieve products and apply filters, with the ability to highlight specific keywords in product descriptions.

## Overview
This .NET Core solution implements a clean architecture and consist of following projects:
- ProductWarehouse.API
- ProductWarehouse.Application
- ProductWarehouse.Domain
- ProductWarehouse.Infrastructure
- ProductWarehouse.Persistence
- ProductWarehouse.UnitTests

## Technologies Used

### Core Framework and Language
- **ASP.NET Core**
- **C#**

### Architectural Patterns and Practices
- **Repository Pattern**
- **Dependency Injection (DI)**

### Mediation and CQRS
- **MediatR**
  - Library for implementing the Mediator pattern in .NET applications.
- **CQRS (Command Query Responsibility Segregation)**
  - Design pattern for separating read and write operations.

### Object Mapping and Validation
- **AutoMapper**
  - Library for object-to-object mapping, simplifying DTO creation.
- **FluentValidation**
  - Library for building strongly-typed validation rules.

### Exception Handling
- **Global Exception Handler**
  - Custom exception handling logic using ASP.NET Core's `IExceptionHandler`.


### Logging
- **Serilog**
  - Logging library for .NET applications.
- **High-Performance Logging Optimization**
  - Custom optimizations for improving logging performance.

### Testing
- **xUnit**
  - Testing framework for unit testing .NET applications.
- **AutoFixture**
  - Library for simplifying the creation of test objects.
- **FakeItEasy**
  - Library for creating fake objects and mocking in unit tests.
- **FluentAssertions**
  - Library for fluent assertion syntax in unit tests.

### Documentation
- **Swagger UI**
  - Tool for documenting and visualizing APIs.


## Endpoint

- **GET products**
  
  When the request has no parameters.

- **GET products/filter**

  Accepts four optional query parameters to filter products or highlight words in their description:

  - `MinPrice` (decimal): Minimum price for filtering products.
  - `MaxPrice` (decimal): Maximum price for filtering products.
  - `Highlight` (string): Comma-separated list of words to highlight in product descriptions.
  - `Size` (string): Size parameter for filtering products.

  Example: `/filter?MinPrice=10&MaxPrice=89&Highlight=red,blue&Size=Medium`

## Responses

- All products if the request has no parameters.
- A filtered subset of products if the request has filter parameters.
A filter object containing:
  - Minimum and maximum price of all products in the source URL.
  - An array of all sizes of all products in the source URL.
  - An array of the ten most common words in the product descriptions, excluding the most common five.

Additionally, HTML tags are added to product descriptions to highlight the words provided in the `Highlight` parameter.
