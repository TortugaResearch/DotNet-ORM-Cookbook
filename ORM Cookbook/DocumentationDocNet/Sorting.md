# Basic Sorting

These scenarios demonstrate how to perform basic sorts. 

Note: [Sorting by dynamically chosen columns](DynamicSorting) or by expressions will be handled in a separate scenarios.

## Scenario Prototype

@snippet cs [..\Recipes\Sorting\ISortingScenario`1.cs] ISortingScenario{TEmployeeSimple}

## ADO.NET

@snippet cs [..\Recipes.Ado\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.Ado\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.Ado\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## Chain

Columns to be sorted by are passed in as strings, but checked against the list of columns at runtime to prevent SQL injection attacks. A `SortExpression` object is needed for reverse sorting.

@snippet cs [..\Recipes.Tortuga.Chain\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.Tortuga.Chain\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.Tortuga.Chain\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## Dapper

@snippet cs [..\Recipes.Dapper\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.Dapper\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.Dapper\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## DbConnector

@snippet cs [..\Recipes.DbConnector\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.DbConnector\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.DbConnector\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.EntityFramework\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.EntityFramework\Sorting\SortingScenario.cs] SortByMiddleNameFirstName


## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.EntityFrameworkCore\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.EntityFrameworkCore\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.LinqToDB\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.LinqToDB\Sorting\SortingScenario.cs] SortByMiddleNameFirstName


## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## NHibernate

@snippet cs [..\Recipes.NHibernate\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.NHibernate\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.NHibernate\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## RepoDb

@snippet cs [..\Recipes.RepoDb\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.RepoDb\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.RepoDb\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Sorting\SortingScenario.cs] SortByFirstName

@snippet cs [..\Recipes.ServiceStack\Sorting\SortingScenario.cs] SortByMiddleNameDescFirstName

@snippet cs [..\Recipes.ServiceStack\Sorting\SortingScenario.cs] SortByMiddleNameFirstName

