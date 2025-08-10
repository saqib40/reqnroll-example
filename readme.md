## Overview of what I did

```bash
# === 1. Setting Up the Projects ===

# Create the main application project (which will become our class library)
dotnet new console -n CalculatorApp

# Create the test project using the MSTest framework
dotnet new mstest -n CalculatorApp.Tests

# Change the project type of CalculatorApp from an executable to a class library
# (This requires manually editing the .csproj file as shown previously)
# After editing, it will have <OutputType>Library</OutputType>

# === 2. Creating and Managing the Solution File ===

# Create a solution file in the root directory to manage the projects
dotnet new sln

# Add both projects to the solution file
dotnet sln add CalculatorApp/CalculatorApp.csproj
dotnet sln add CalculatorApp.Tests/CalculatorApp.Tests.csproj

# Add a reference from the test project to the main app project
dotnet add CalculatorApp.Tests/CalculatorApp.Tests.csproj reference CalculatorApp/CalculatorApp.csproj

# === 3. Installing Reqnroll Packages ===

# Navigate into the test project's directory
cd CalculatorApp.Tests

# Install the core Reqnroll package
dotnet add package Reqnroll

# Install the MSTest adapter for Reqnroll
dotnet add package Reqnroll.MSTest

# Install the build-time code generation tool
dotnet add package Reqnroll.Tools.MsBuild.Generation

# Navigate back to the root directory
cd ..

# === 4. Building and Testing ===

# Build the entire solution (both projects)
dotnet build

# Run all the tests discovered in the solution
dotnet test
```