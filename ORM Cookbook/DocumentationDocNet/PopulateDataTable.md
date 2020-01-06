# Populate a DataTable

A `DataTable` is often used for holding the results of a report that are then displayed in a data grid of some sort. It is primarily used when the columns returned are dynamically chosen or when creating custom classes for each report is consider to be onerous.

A `DataTable` may also be used as a staging area before performing a bulk insert operation. 

## Prototype Repository

@snippet cs [..\Recipes.Core\PopulateDataTable\IPopulateDataTableRepository.cs] IPopulateDataTableRepository

## ADO.NET

`DataTable.Load` can be provided with an `IDataReader`.

@snippet cs [..\Recipes.Ado\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

## Chain

Chain natively supports `DataTable`.

@snippet cs [..\Recipes.Tortuga.Chain\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

## Dapper

Dapper does not natively support `DataTable`. Use the ADO.NET pattern.

## Entity Framework Core

EF Core does not support `DataTable`. 

## NHibernate

In some cases you'll need to catch a `StaleStateException` as there is no TryUpdate or TryDelete.

## RepoDb

TODO

## ServiceStack

TODO



