# Multiple Databases

These scenarios demonstrate how to support multiple databases with the same code. For demonstration purposes, SQL Server and PostgreSQL will be used.

## Scenario Prototype

@snippet cs [..\Recipes\MultipleDB\IMultipleDBScenario`1.cs] IMultipleDBScenario{TModel}

## ADO.NET

In order to support multiple databases with the same code, ADO.NET provides a `DbProviderFactory` implmentation for each database. This can be used to create the connection, command, and parameter objects.

@snippet cs [..\Recipes.Ado\MultipleDB\MultipleDBScenario_DbProviderFactory.cs] MultipleDBScenario_DbProviderFactory

Alternately, commands can be created from connections and parameters from commands.

@snippet cs [..\Recipes.Ado\MultipleDB\MultipleDBScenario_Chained.cs] MultipleDBScenario_Chained

## Chain

In Chain, each named `DataSource` exposes database-specific functionality. For functionality that's common across multiple databases, a set of interfaces are offered.

* `IClass0DataSource`: Raw SQL only. 
* `IClass1DataSource`: CRUD operations. Database reflection.
* `IClass2DataSource`: Functions and Stored procedures

@snippet cs [..\Recipes.Tortuga.Chain\MultipleDB\MultipleDBScenario.cs] MultipleDBScenario

## Dapper

TODO

## DbConnector

@snippet cs [..\Recipes.DbConnector\MultipleDB\MultipleDBScenario.cs] MultipleDBScenario

## Entity Framework 6

TODO

## Entity Framework Core

Conceptually, you just replace `.UseSqlServer(SqlServerConnectionString)` with `.UseNpgsql(PostgreSqlConnectionString)` to change databases.

Due to differences in naming conventions between the two, you may find that a naming converter is needed. 

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\Conventions\CaseConventionConverter.cs] CaseConventionConverter

The two most common conventions for PostgreSQL are snake_case and lowercase.

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\Conventions\SnakeCaseConverter.cs] SnakeCaseConverter

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\Conventions\LowerCaseConverter.cs] LowerCaseConverter

No changes were needed to the actual DB access code.

@snippet cs [..\Recipes.EntityFrameworkCore\MultipleDB\MultipleDBScenario.cs] MultipleDBScenario


## LINQ to DB

TODO

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
