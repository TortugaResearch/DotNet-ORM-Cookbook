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

`DataTable.Load` can be provided with an `IDataReader`.

@snippet cs [..\Recipes.Dapper\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

## Entity Framework Core

EF Core does not support `DataTable`. 

@snippet cs [..\Recipes.EntityFrameworkCore\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

You can generalize this using a reflection library.

@snippet cs [..\Recipes.EntityFrameworkCore\PopulateDataTable\PopulateDataTableRepository2.cs] PopulateDataTableRepository2

## LLBLGen Pro

LLBLGen Pro natively supports `DataTable`.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

## NHibernate

NHibernate does not support `DataTable`, but you can add it using an `IResultTransformer`. 

@snippet cs [..\Recipes.NHibernate\DataTableResultTransformer.cs] DataTableResultTransformer

Note that inline SQL must be used inconjunction with the `IResultTransformer`.

@snippet cs [..\Recipes.NHibernate\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

## RepoDb

In RepoDb, the `DataTable.Load` can be provided with an `IDataReader` object from `ExecuteReader` method.

@snippet cs [..\Recipes.RepoDb\PopulateDataTable\PopulateDataTableRepository.cs] PopulateDataTableRepository

## ServiceStack

TODO



