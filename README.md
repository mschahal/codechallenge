
# Code Challenge

## Description
This is to demonstrate basic CRUD of customer entities using .net core and angular 

## Getting Started

### 1. Running the Angular App
#### a. Install Node.js and npm
Download and install Node.js from [Node.js website](https://nodejs.org/). npm is included with Node.js.

#### b. Install Angular CLI
Run the following command in your terminal:
```
npm install -g @angular/cli
```

#### c. Install Dependencies
Navigate to your Angular project directory and run:
```
npm install
```

#### d. Serve the Application
Run the Angular application with:
```
ng serve
```
Access the application at `http://localhost:4200`.

### 2. Initializing and Running EF Core Migration
#### a. Install EF Core CLI
Ensure you have the EF Core CLI installed by running:
```
dotnet tool install --global dotnet-ef
```

#### b. Create Migrations
In your .NET Core project directory, create a migration with:
```
dotnet ef migrations add InitialCreate
```

#### c. Update Database
Apply the migration to your database with:
```
dotnet ef database update
```

### 3. Running the .NET Core 6 App
#### a. Install .NET Core SDK
Make sure you have the .NET Core SDK installed, which can be found on the [.NET website](https://dotnet.microsoft.com/download).

#### b. Run the Application
Navigate to your .NET Core project directory and run:
```
dotnet run
```

