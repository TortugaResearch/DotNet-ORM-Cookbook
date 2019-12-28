# Single Model CRUD

This use case covers the basic CRUD operations on a model that represents a single row in the database.

## Prototype Repository

@snippet cs [..\Recipes.Core\SingleModelCrud\ISingleModelCrudRepository`1.cs] ISingleModelCrudRepository{TEmployeeClassification}


## ADO.NET

[TODO]

## Dapper

[TODO]

## Tortuga Chain

@snippet cs [..\Recipes.Tortuga.Chain\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository

## Entity Framework Core

To use Entity Framework Core, one needs to create a DbContext class. For more information see https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.
@end

### Entity Framework Core - Improved

The design of Entity Framework Core requires extraneous database calls in some scenarios. This revised version eliminates the extra calls.

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudRepository2.cs] SingleModelCrudRepository2

