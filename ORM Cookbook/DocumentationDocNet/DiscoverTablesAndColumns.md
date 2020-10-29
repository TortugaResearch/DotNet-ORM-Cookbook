# Discover Tables and Columns

These scenarios demonstrate how to list the tables and columns in an unknown database. 

## Scenario Prototype

@snippet cs [..\Recipes\DiscoverTablesAndColumns\IDiscoverTablesAndColumnsScenario.cs] IDiscoverTablesAndColumnsScenario

## ADO.NET

The SQL needed to list tables, views, and columns is database-specific. This example shows SQL Server.

@snippet cs [..\Recipes.Ado\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## Chain

Chain exposes information about the database via the `DatabaseMetadata` property. If you don't use the `Preload` method, only tables and views previously seen will be available.

Then to supply the actual user data, use `dataSource.WithUser(user)`.

@snippet cs [..\Recipes.Tortuga.Chain\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## Dapper

The SQL needed to list tables, views, and columns is database-specific. This example shows SQL Server.

@snippet cs [..\Recipes.Dapper\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## DbConnector

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
