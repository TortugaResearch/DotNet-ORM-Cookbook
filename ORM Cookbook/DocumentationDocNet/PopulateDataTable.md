# Populate a DataTable

A `DataTable` is often used for holding the results of a report that are then displayed in a data grid of some sort. It is primarily used when the columns returned are dynamically chosen or when creating custom classes for each report is consider to be onerous.

A `DataTable` may also be used as a staging area before performing a bulk insert operation. 

## Scenario Prototype

@snippet cs [..\Recipes\PopulateDataTable\IPopulateDataTableScenario.cs] IPopulateDataTableScenario

## ADO.NET

`DataTable.Load` can be provided with an `IDataReader`.

@snippet cs [..\Recipes.Ado\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

## Chain

Chain natively supports `DataTable`.

@snippet cs [..\Recipes.Tortuga.Chain\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

## Dapper

`DataTable.Load` can be provided with an `IDataReader`.

@snippet cs [..\Recipes.Dapper\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

## Entity Framework 6

EF Core does not support `DataTable`. 

@snippet cs [..\Recipes.EntityFramework\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

You can generalize this using a reflection library.

@snippet cs [..\Recipes.EntityFramework\PopulateDataTable\PopulateDataTableScenario2.cs] PopulateDataTableScenario2

## Entity Framework Core

EF Core does not support `DataTable`. 

@snippet cs [..\Recipes.EntityFrameworkCore\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

You can generalize this using a reflection library.

@snippet cs [..\Recipes.EntityFrameworkCore\PopulateDataTable\PopulateDataTableScenario2.cs] PopulateDataTableScenario2

## LINQ to DB

TODO

## LLBLGen Pro

LLBLGen Pro natively supports `DataTable`.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

## NHibernate

NHibernate does not support `DataTable`, but you can add it using an `IResultTransformer`. 

@snippet cs [..\Recipes.NHibernate\DataTableResultTransformer.cs] DataTableResultTransformer

Note that inline SQL must be used inconjunction with the `IResultTransformer`.

@snippet cs [..\Recipes.NHibernate\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

## RepoDb

In RepoDb, the `DataTable.Load` can be provided with an `IDataReader` object from `ExecuteReader` method.

@snippet cs [..\Recipes.RepoDb\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\PopulateDataTable\PopulateDataTableScenario.cs] PopulateDataTableScenario



