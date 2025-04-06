AB E-Commerce Web Application – Technical Overview
1. Project Overview
Project Name: AB

Framework: ASP.NET Core MVC

Programming Language: C#

Solution File: AB.sln

Project File: AB.csproj

Main Entry Point: Program.cs

Configuration Files: appsettings.json, appsettings.Development.json

2. Key Functionalities
Product browsing and viewing

Shopping cart with add/remove functionality

User authentication and registration (via ASP.NET Identity)

Order placement and tracking

Admin or base views for layout and shared components

3. Technologies Used
C# – main programming language

ASP.NET Core MVC – framework for web application structure

Razor Pages (.cshtml) – for dynamic web page rendering

Entity Framework – for database operations and ORM

HTML, CSS, JavaScript – for frontend styling and interactivity

ASP.NET Identity – for user management and authentication

JSON – for app configuration (appsettings.json)

4. Project Folder Structure
Controllers/

Manages HTTP requests and business logic.

Handles routing to corresponding views or data responses.

Models/

Defines the data structure and database entity classes.

Used by Entity Framework for database interaction.

Views/

Razor view files for rendering UI.

Subfolders:

Base/ – layout and shared views (e.g., master pages)

Cart/ – shopping cart pages

Home/ – landing or main page

Product/ – product listing and detail pages

Areas/Identity/Pages/

Contains views and logic for user authentication.

Supports login, registration, account management using ASP.NET Identity.

wwwroot/

Static files (CSS, JavaScript, images, frontend libraries)

Data/

Likely contains DbContext and database initialization classes.

Helpers/

Utility or service classes used across the application.
