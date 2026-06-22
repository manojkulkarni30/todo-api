# TODO API

A simple .NET minimal Web API for managing TODO items. The API uses Entity Framework Core with a MySQL-compatible database (see `appsettings.json` connection string).

Key features:

- Create, read, update and delete TODO items
- Fields: Id (GUID stored as binary(16)), Title, Description, IsCompleted, Category, Priority, DueDate, ReminderDate, DateCreated, DateUpdated

Prerequisites:

- .NET 10 SDK
- MySQL

Running locally:

1. Configure the connection string in `appsettings.json` (key: `ConnectionStrings:DefaultConnection`).
2. Build and run the project from the solution folder:

```bash
dotnet build
dotnet run
```

Database: Create `Todos` table (MySQL)

Run the following SQL on your MySQL server to create the `Todos` table. This schema stores the `Id` as `BINARY(16)` (EF maps Guid to binary(16) in the DbContext).

```sql
CREATE TABLE `Todos` (
  `Id` binary(16) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Description` text,
  `IsCompleted` tinyint(1) NOT NULL DEFAULT '0',
  `DateCreated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `DateUpdated` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Category` tinyint unsigned NOT NULL DEFAULT '1',
  `Priority` tinyint unsigned NOT NULL DEFAULT '2',
  `DueDate` datetime DEFAULT NULL,
  `ReminderDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
);
```

## Scalar API

- Local scalar endpoint: [http://localhost:5159/scalar/](http://localhost:5159/scalar/)
