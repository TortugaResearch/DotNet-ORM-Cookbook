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

## DbConnector

@snippet cs [..\Recipes.DbConnector\SoftDelete\SoftDeleteScenario.cs] SoftDeleteScenario

## Entity Framework 6

To generalize soft delete support in EF 6, create an interface with the soft delete column(s). Then overide the `SaveChanges` method to provide the values.

For the select operations, you'll also need to manually filter out deleted columns. 

@snippet cs [..\Recipes.EntityFramework\Entities\ISoftDeletable.cs] ISoftDeletable

@snippet cs [..\Recipes.EntityFramework\Entities\OrmCookbookContextWithSoftDelete.cs] SaveChanges()

@snippet cs [..\Recipes.EntityFramework\SoftDelete\SoftDeleteScenario.cs] SoftDeleteScenario

@alert warning
This design pattern is only a partial solution. When including related objects, you'll also need to filter out those deleted rows. See https://github.com/Grauenwolf/DotNet-ORM-Cookbook/issues/229 for alternate implementations.
@end

## Entity Framework Core

To generalize soft delete support in EF Core, create an interface with the soft delete column(s). Then overide the `SaveChanges` method to provide the values.

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
