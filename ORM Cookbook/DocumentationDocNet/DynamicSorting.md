# Sorting by Dynamically Chosen Columns

These scenarios demonstrate how to perform sorts where the column being sorted by is provided by a string parameter. 

See [Basic Sorting](Sorting.htm) for examples of sorting by a fixed column name.

## Scenario Prototype

@snippet cs [..\Recipes\DynamicSorting\IDynamicSortingScenario`1.cs] IDynamicSortingScenario{TEmployeeSimple}

For ORMs that don't directly support checking column names, a statically defined list is provided.

@snippet cs [..\Recipes\DynamicSorting\Utilities.cs] Utilities

For ORMs that use LINQ and `IQueryable`, these extensions are provided.

@snippet cs [..\Recipes\DynamicSorting\DynamicSortingExtensions.cs] DynamicSortingExtensions

## ADO.NET

ADO requires validation of sort columns against a statically defined list.

@snippet cs [..\Recipes.Ado\DynamicSorting\DynamicSortingScenario.cs] SortBy

## Chain

Columns to be sorted by are passed in as strings, but checked against the list of columns at runtime to prevent SQL injection attacks. A `SortExpression` object is needed for reverse sorting.

@snippet cs [..\Recipes.Tortuga.Chain\DynamicSorting\DynamicSortingScenario.cs] SortBy

## Dapper

Dapper requires validation of sort columns against a statically defined list.

@snippet cs [..\Recipes.Dapper\DynamicSorting\DynamicSortingScenario.cs] SortBy

## Entity Framework 6

Entity Framework does not natively support sorting by strings. However, this can be acomplished with `DynamicSortingExtensions`.

@snippet cs [..\Recipes.EntityFramework\DynamicSorting\DynamicSortingScenario.cs] SortBy

## Entity Framework Core

EF Core does not natively support sorting by strings. However, this can be acomplished with `DynamicSortingExtensions`.

@snippet cs [..\Recipes.EntityFramework\DynamicSorting\DynamicSortingScenario.cs] SortBy

## LINQ to DB

LinqToDB does not natively support sorting by strings. However, this can be acomplished with `DynamicSortingExtensions`.

@snippet cs [..\Recipes.LinqToDB\DynamicSorting\DynamicSortingScenario.cs] SortBy

## LLBLGen Pro 

LLBLGen Pro does natively support sorting by strings but it requires a little bit of verbose code using the low-level API of older versions. This
is illustrated in the code below in the first method. The second method shows the alternative using the `DynamicSortingExtensions`.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\DynamicSorting\DynamicSortingScenario.cs] SortBy

## NHibernate

NHibernate does not support sorting by strings.

## RepoDb

Columns to be sorted by are passed in as a collection of `OrderField` objects. They checked against the list of columns at runtime to prevent SQL injection attacks. 

@snippet cs [..\Recipes.RepoDb\DynamicSorting\DynamicSortingScenario.cs] SortBy

## ServiceStack

ServiceStack requires validation of sort columns against a statically defined list. ServiceStack will attempt to detect some instances of SQL injection, but potentially dangerous expressions are allowed.

@snippet cs [..\Recipes.ServiceStack\DynamicSorting\DynamicSortingScenario.cs] SortBy
