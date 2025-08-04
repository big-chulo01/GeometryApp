Geometry Calculator Application
Overview
This is a console application that calculates area and perimeter for different geometric shapes (Square, Rectangle, Triangle) using feature flags to control which shapes are available to users.

Features
Square: Calculate area and perimeter with one side length

Rectangle: Calculate area and perimeter with length and width

Triangle: Calculate area (using Heron's formula) and perimeter with three side lengths

Feature Management: Control shape availability via configuration

Input Validation: Handles invalid user input gracefully

Prerequisites
.NET 8.0 SDK or later

Visual Studio Code (with C# extension) or Visual Studio

Installation
Clone the repository:

bash
git clone https://github.com/yourusername/GeometryApp.git
cd GeometryApp
Restore dependencies:

bash
dotnet restore
Configuration
Feature flags are configured in GeometryConsole/Program.cs:

csharp
var featureManagement = new Dictionary<string, string?>
{
    { "FeatureManagement:Square", "true" },
    { "FeatureManagement:Rectangle", "true" },
    { "FeatureManagement:Triangle", "true" }
};
Set to "false" to disable a shape.

Running the Application
From the root directory:

bash
dotnet run --project GeometryConsole/GeometryConsole.csproj
Or from the GeometryConsole directory:

bash
dotnet run
Running Tests
Execute all tests from the root directory:

bash
dotnet test
Project Structure
text
GeometryApp/
├── GeometryApp.sln
├── GeometryConsole/           # Console application
│   ├── Program.cs            # Main application logic
│   └── GeometryConsole.csproj
├── GeometryLibrary/           # Class library
│   ├── IShape.cs             # Shape interface
│   ├── Square.cs             # Square implementation
│   ├── Rectangle.cs          # Rectangle implementation
│   ├── Triangle.cs           # Triangle implementation
│   └── GeometryLibrary.csproj
└── GeometryTests/            # Unit tests
    ├── GeometryTests.cs      # Test cases
    └── GeometryTests.csproj
How to Use
Run the application

Select a shape from the menu

Enter the required dimensions when prompted

View the calculated area and perimeter

Example workflow:

text
Welcome to Geometry Calculator!
Available shapes:
1. Square
2. Rectangle
3. Triangle
Enter your choice (1-3): 2
Enter length: 5
Enter width: 4
Area: 20
Perimeter: 18
Dependencies
Microsoft.FeatureManagement

Microsoft.Extensions.Configuration

Microsoft.Extensions.DependencyInjection

FluentAssertions (for testing)
