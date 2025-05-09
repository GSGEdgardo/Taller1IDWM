﻿# Taller1IDWM

## Description

Implement a REST API using ASP.NET Core.

## Prerequisites

Before you begin, ensure you have met the following requirementes:

- **.NET SDK**:  This project is using .NET 8.

[Download and install .NET SDK](https://dotnet.microsoft.com/es-es/download)

## Installation

Follow these steps to set up your development environment:

**1. Clone the repository**

```
git clone https://github.com/GSGEdgardo/Taller1IDWM.git
```

**2. Enter the folder**

```
cd Taller1
```

**3. Restore dependencies**

```
dotnet restore
```

## Database

This project is using SQLite for database, if there's no migrations you need to run these commands on the CLI

```
dotnet ef migrations add InitialCreate
```

```
dotnet ef database update
```

With these commands the API create the migrations and build the database with seed data.

## Usage

To run the project, use the following command:

```
dotnet run
```

This will start the aplicacion and it will be available at `http://localhost:5126` by default.

It can be used `Swagger` to test the endpoints here `http://localhost:5126/Swagger/index.html`

and Postman collection were added to the repository by the name `Taller1-IDWM.postman_collection.json`.

## Project Structure

```graphql
/Taller1/Src
|-- /Controllers       # Contains the API controllers, responsible for handling HTTP requests and responses.
|-- /Data              # Contains the database context and migration files.
|-- /Dto               # Data Transfer Objects used for transferring data between layers.
|   |-- /ProductDtos   # DTOs specific to Product-related operations.
|-- /Helpers           # Utility classes and helper functions. Specifically cloudinary settings in this project.
|-- /Models            # Entity models that represent the data structure.
|-- /Profiles          # AutoMapper profiles for mapping between models and DTOs.
|-- /Repositories      # Repository pattern implementation for data access.
|   |-- /Implements    # Implementations of the repository interfaces.
|   |-- /Interfaces    # Repository interfaces.
|-- /Services          # Service layer for business logic.
    |-- /Implements    # Implementations of the service interfaces.
    |-- /Interfaces    # Service interfaces.
```

## Contact

**Students**: 

1. Edgardo Ortiz - edgardo.ortiz@alumnos.ucn.cl.
2. Matías Nuñez - matias.nunez01@alumnos.ucn.cl.
3. Matías Silva - matias.silva01@alumnos.ucn.cl.
