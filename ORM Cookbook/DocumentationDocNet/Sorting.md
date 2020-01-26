# Basic Sorting

These scenarios demonstrate how to perform basic sorts. 

Note: Sorting by dynamically chosed columns or by expressions will be handled in a separate scenarios.

## Scenario Prototype

@snippet cs [..\Recipes\Sorting\ISortingScenario`1.cs] ISortingScenario{TEmployee}

## ADO.NET

@snippet cs [..\Recipes.Ado\Sorting\SortingScenario.cs] SortingScenario

## Chain

Columns to be sorted by are passed in as strings, but checked against the list of columns at runtime to prevent SQL injection attacks. A `SortExpression` object is needed for reverse sorting.

@snippet cs [..\Recipes.Tortuga.Chain\Sorting\SortingScenario.cs] SortingScenario

## Dapper

@snippet cs [..\Recipes.Dapper\Sorting\SortingScenario.cs] SortingScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\Sorting\SortingScenario.cs] SortingScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\Sorting\SortingScenario.cs] SortingScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\Sorting\SortingScenario.cs] SortingScenario

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Sorting\SortingScenario.cs] SortingScenario

## NHibernate

@snippet cs [..\Recipes.NHibernate\Sorting\SortingScenario.cs] SortingScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\Sorting\SortingScenario.cs] SortingScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Sorting\SortingScenario.cs] SortingScenario

