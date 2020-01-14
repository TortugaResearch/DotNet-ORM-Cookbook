# Basic Sorting

These use cases demonstrate how to perform basic sorts. 

Note: Sorting by dynamically chosed columns or by expressions will be handled in a separate use case.

## Prototype Repository

@snippet cs [..\Recipes.Core\Sorting\ISortingRepository`1.cs] ISortingRepository{TEmployee}

## ADO.NET

@snippet cs [..\Recipes.Ado\Sorting\SortingRepository.cs] SortingRepository

## Chain

Columns to be sorted by are passed in as strings, but checked against the list of columns at runtime to prevent SQL injection attacks. A `SortExpression` object is needed for reverse sorting.

@snippet cs [..\Recipes.Tortuga.Chain\Sorting\SortingRepository.cs] SortingRepository

## Dapper

@snippet cs [..\Recipes.Dapper\Sorting\SortingRepository.cs] SortingRepository

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\Sorting\SortingRepository.cs] SortingRepository

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Sorting\SortingRepository.cs] SortingRepository

## NHibernate

@snippet cs [..\Recipes.NHibernate\Sorting\SortingRepository.cs] SortingRepository

## RepoDb

@snippet cs [..\Recipes.RepoDb\Sorting\SortingRepository.cs] SortingRepository

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Sorting\SortingRepository.cs] SortingRepository

