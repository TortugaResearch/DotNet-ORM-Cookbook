# Paging Results

These scenarios demonstrate how to page resutls. Three styles of pagination are shown:

* Page and Page Size
* Skip and Take
* Keyset Pagination (i.e. Skip-Past)

Keyset pagination is a technique where the previous result is used to determine where to starting point for the next set of results. If an index is available, this can be significantly faster than using an offset. For more information see [We need tool support for keyset pagination](https://use-the-index-luke.com/no-offset).

## Scenario Prototype

@snippet cs [..\Recipes\Pagination\IPaginationScenario`1.cs] IPaginationScenario{TEmployeeSimple}

## ADO.NET

@snippet cs [..\Recipes.Ado\Pagination\PaginationScenario.cs] PaginationScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\Pagination\PaginationScenario.cs] PaginationScenario

## Dapper

@snippet cs [..\Recipes.Dapper\Pagination\PaginationScenario.cs] PaginationScenario

## DbConnector

@snippet cs [..\Recipes.DbConnector\Pagination\PaginationScenario.cs] PaginationScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\Pagination\PaginationScenario.cs] PaginationScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\Pagination\PaginationScenario.cs] PaginationScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\Pagination\PaginationScenario.cs] PaginationScenario

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Pagination\PaginationScenario.cs] PaginationScenario

## NHibernate

@snippet cs [..\Recipes.NHibernate\Pagination\PaginationScenario.cs] PaginationScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\Pagination\PaginationScenario.cs] PaginationScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Pagination\PaginationScenario.cs] PaginationScenario
