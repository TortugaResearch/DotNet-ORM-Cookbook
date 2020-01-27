# Sorting by Dynamically Chosen Columns

These scenarios demonstrate how to perform sorts where the column being sorted by is provided by a string parameter. 

See [Basic Sorting](Sorting.htm) for examples of sorting by a fixed column name.

## Scenario Prototype

@snippet cs [..\Recipes\DynamicSorting\IDynamicSortingScenario`1.cs] IDynamicSortingScenario{TEmployeeSimple}

## ADO.NET

@snippet cs [..\Recipes.Ado\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## Chain

Columns to be sorted by are passed in as strings, but checked against the list of columns at runtime to prevent SQL injection attacks. A `SortExpression` object is needed for reverse sorting.

@snippet cs [..\Recipes.Tortuga.Chain\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## Dapper

@snippet cs [..\Recipes.Dapper\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## NHibernate

@snippet cs [..\Recipes.NHibernate\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\DynamicSorting\DynamicSortingScenario.cs] DynamicSortingScenario

