# Product Wherehouse API
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

- ASP.NET Core
- C#
- Repository, Dependency Injection
- MediatR and CQRS
- AutoMapper, FluentValidation
- Serilog and high-performance logging optimisation
- xUnit, AutoFixture, FakeItEasy, FluentAssertions for unit testing
- Swagger UI for documentation


### Endpoint

- **GET products**
  
  When the request has no parameters.

- **GET products/filter**

  Accepts four optional query parameters to filter products or highlight words in their description:

  - `MinPrice` (decimal): Minimum price for filtering products.
  - `MaxPrice` (decimal): Maximum price for filtering products.
  - `Highlight` (string): Comma-separated list of words to highlight in product descriptions.
  - `Size` (string): Size parameter for filtering products.

  Example: `/filter?MinPrice=10&MaxPrice=89&Highlight=red,blue&Size=Medium`

### Responses

- All products if the request has no parameters.
- A filtered subset of products if the request has filter parameters.
A filter object containing:
  - Minimum and maximum price of all products in the source URL.
  - An array of all sizes of all products in the source URL.
  - An array of the ten most common words in the product descriptions, excluding the most common five.

Additionally, HTML tags are added to product descriptions to highlight the words provided in the `Highlight` parameter.
