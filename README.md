# HHA Management System

A training/personal project built with ASP.NET Core MVC, Entity Framework Core, SQL Server, Repository Pattern, Dependency Injection, AutoMapper, Authentication and Authorization.

## Features
- Admin login and role-based authorization
- Caregiver CRUD
- Patient CRUD
- Caregiver-patient assignments
- Visit scheduling and status management
- Dashboard
- EF Core + SQL Server
- Repository pattern
- Dependency injection
- AutoMapper
- Custom middleware
- Bootstrap UI

## Requirements
- .NET 8 SDK
- SQL Server / SQL Server Express / LocalDB
- Visual Studio 2022 or VS Code

## Run
1. Update the connection string in `appsettings.json`.
2. Run:
   `dotnet restore`
3. Create the database:
   `dotnet ef database update`
4. Run:
   `dotnet run`

If EF tools are not installed:
`dotnet tool install --global dotnet-ef`

## Demo Login
The seed data creates:
- Username: admin
- Password: Admin@123

Change demo credentials before using this outside local development.

## Architecture
Controller -> Service -> Repository -> DbContext -> EF Core -> SQL Server
