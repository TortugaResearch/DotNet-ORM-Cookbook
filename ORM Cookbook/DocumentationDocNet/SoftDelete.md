# Soft Delete

These scenarios demonstrate how to use soft deletes (i.e. `IsDeleted` flag) rather than hard deletes. 

## Scenario Prototype

@snippet cs [..\Recipes\SoftDelete\ISoftDeleteScenario`1.cs] ISoftDeleteScenario{TDepartment}

## ADO.NET

TODO

## Chain

Chain requires that soft delete be configured at the `DataSource` level.

@snippet cs [..\Recipes.Tortuga.Chain\SoftDelete\SoftDeleteScenario.cs] SoftDeleteScenario

## Dapper

TODO

## Entity Framework 6

TODO

## Entity Framework Core

To generalize audit column management in EF Core, create an interface with the soft delete column(s). Then overide the `SaveChanges` method to provide the values.

For the select operations, you'll also need to add a `HasQueryFilter` for each entity that supported soft deletes.

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\ISoftDeletable.cs] ISoftDeletable

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\OrmCookbookContextWithSoftDelete.cs] SaveChanges()

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\OrmCookbookContextWithSoftDelete.cs] OnModelCreating(ModelBuilder)

@snippet cs [..\Recipes.EntityFrameworkCore\SoftDelete\SoftDeleteScenario.cs] SoftDeleteScenario

## LINQ to DB

TODO

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
