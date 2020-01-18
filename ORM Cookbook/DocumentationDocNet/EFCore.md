# Entity Framework Core

Entity Framework Core (EF Core) describes itself as "a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology."

EF Core assumes a one-to-one mapping between entity classes and tables. All access is performed via a `DbContext` class, which internally manages connections and tracks changes to entities.

## Supported Databases

Database specific providers are required. 

EF Core 3.x supports:

* Azure Cosmos DB
* MariaDB
* MySQL
* Oracle DB
* PostgreSQL
* SQL Server
* SQLite 

EF Core 2.x providers are not compatible with EF Core 3.x. 

## Libraries

See [Database Providers](https://docs.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli) for a current list of EF Core providers.

## Setup

EF Core requires creating a subclass of `DbContext`. This contains the configuration needed to map classes to tables. 

The [`Scaffold-DbContext`](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell#scaffold-dbcontext) command may be used to automatically generate the DBContext and the matching entity classes.

Alternately, the entities can be created first and be used to generate the database schema.

## Documentation and Tutorials 

* [Tutorial](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli)
* [Primary Documentation](https://docs.microsoft.com/en-us/ef/core/)

## Bug Reporting

Issues should be logged in the [dotnet/efcore repository](https://github.com/dotnet/efcore/issues).

## Licensing

EF Core itself is offered under the [Apache License 2.0](https://github.com/dotnet/efcore/blob/master/LICENSE.txt).

Individual EF Core providers may be licensed differently.

