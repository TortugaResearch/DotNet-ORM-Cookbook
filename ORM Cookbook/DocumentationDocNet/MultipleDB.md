# Multiple Databases

These scenarios demonstrate how to support multiple databases with the same code. For demonstration purposes, SQL Server and PostgreSQL will be used.

## Scenario Prototype

@snippet cs [..\Recipes\MultipleDB\IMultipleDBScenario`1.cs] IMultipleDBScenario{TModel}

## ADO.NET

In order to support multiple databases with the same code, ADO.NET provides a `DbProviderFactory` implmentation for each database. This is used to create the connection, command, and parameter objects.

@snippet cs [..\Recipes.Ado\MultipleDB\MultipleDBScenario.cs] MultipleDBScenario

## Chain

In Chain, each named `DataSource` exposes database-specific functionality. For functionality that's common across all database, a set of interfaces are offered.

* `IClass0DataSource`: Raw SQL only. 
* `IClass1DataSource`: CRUD operations. Database reflection.
* `IClass2DataSource`: Functions and Stored procedures

@snippet cs [..\Recipes.Tortuga.Chain\MultipleDB\MultipleDBScenario.cs] MultipleDBScenario

## Dapper

TODO

## Entity Framework 6

TODO

## Entity Framework Core

TODO

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
