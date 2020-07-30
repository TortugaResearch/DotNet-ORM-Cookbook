# Query filter

This scenario demonstrate how to get rows from database with Entity Framework Core's query filter feature. This is for
Multi-Tenancy scenarios.

## Scenario Prototype

@snippet cs [..\Recipes\QueryFilter\IQueryFilterScenario.cs] IQueryFilterScenario{TStudent}

## Entity Framework Core

A query filter is setup in the OnModelCreating event of the DB Context.

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\OrmCookbookContextWithQueryFilter.cs] OnModelCreating

Normally this would be done for each table. But by placing a marker interface (`ISchool` in this case) and some helper methods, it can be automatically applied to all tables.

@snippet cs [..\Recipes.EntityFrameworkCore\QueryFilter\Helpers\ModelBuilderExtensions.cs] 

@snippet cs [..\Recipes.EntityFrameworkCore\QueryFilter\Helpers\ExpressionExtensions.cs] 

This example shows it being used.

@snippet cs [..\Recipes.EntityFrameworkCore\QueryFilter\QueryFilterScenario.cs] QueryFilterScenario

