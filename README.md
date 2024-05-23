# Resort Management Application

## Description
This repository contains a comprehensive Resort Management Application built with .NET Core MVC, Entity Framework Core, and ASP.NET Core Identity. The project follows Clean Architecture principles to ensure a scalable, maintainable, and testable codebase. This application is designed to help users manage resort bookings, process payments, and handle administrative tasks through a user-friendly interface.

## Features
- **User Authentication and Authorization**: Secure login and role management using ASP.NET Core Identity.
- **Resort Management**: Full CRUD operations for managing resort details.
- **Booking System**: Manage bookings, including creating, updating, and canceling reservations.
- **Payment Processing**: Securely process payments with Stripe integration.
- **User Profiles**: Allow users to manage their profiles and view booking history.
- **Admin Interface**: An admin dashboard for overseeing resort operations and user management.
- **Dynamic Document Generation**: Export data to PPT, PDF, and Word formats.
- **Data Visualization**: Utilize charts for displaying key metrics and statistics.

## What I have Learnt
- Structure of ASP.NET Core MVC (.NET 8) Project
- Basic and advanced fundamentals of ASP.NET Core MVC (.NET 8)
- Clean Architecture in .NET 8
- Integrate Entity Framework Core with code-first migrations
- Stripe Payment Integration
- Repository Pattern to Access Database
- Seed Database Migrations Automatically
- Deploying the website on MyWindowsHosting
- Dynamic PPT/PDF/Word Exports
- Charts in .NET Core
- Custom .NET Identity using MVC (not Razor Class Library)

## Prerequisites
- **C# Knowledge**: At least 6 months of experience with C#.
- **Visual Studio 2022**: Development environment.
- **SQL Server Management Studio**: Tool for managing SQL Server databases.

## Technologies Used
- **.NET Core MVC (.NET 8)**: Framework for building web applications.
- **Entity Framework Core**: ORM for database interactions.
- **ASP.NET Core Identity**: Authentication and authorization framework.
- **Clean Architecture**: Architectural pattern for organizing code.
- **SQL Server**: Database management system.
- **Bootstrap**: Frontend framework for responsive design.

## Getting Started
1. **Clone the Repository**:
   ```sh
   git clone https://github.com/HieuMIU/WhiteLagoon.git
2. **Setup Database**:
   Configure SQL Server.
   Run migrations to set up the database schema.
3. **Configure Stripe**:
  Set up Stripe API keys for payment processing in the appsettings.json file.
4. **Run the Application**:
  Open the solution in Visual Studio 2022.
  Build and run the application.
