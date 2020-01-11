# CRUD Operations on Model with Child Records

This use case demonstrates performing Create, Read, Update, and Delete operations on an object that includes a collection of child records.

## Prototype Repository

@snippet cs [..\Recipes.Core\ModelWithChildren\IProductLine`1.cs] IProductLine{TProduct}
@snippet cs [..\Recipes.Core\ModelWithChildren\IProduct.cs] IProduct

@snippet cs [..\Recipes.Core\ModelWithChildren\IModelWithChildrenRepository`2.cs] IModelWithChildrenRepository{TProductLine, TProduct}



## ADO.NET

TODO

## Chain

Chain requires operating on the parent and child objects separately.

@snippet cs [..\Recipes.Tortuga.Chain\ModelWithChildren\ModelWithChildrenRepository.cs] ModelWithChildrenRepository

## Dapper

TODO

## Entity Framework Core

When performing an update, ensure that the `EntityState` is correctly set for each child record based on whether it is an insert or update.

For partial deletes, you have to explicitly find and delete the child rows that are no longer needed.

For deletes, ensure the child record in DBContext is setup with `.OnDelete(DeleteBehavior.Cascade)`

@snippet cs [..\Recipes.EntityFrameworkCore\ModelWithChildren\ModelWithChildrenRepository.cs] ModelWithChildrenRepository

## LLBLGen Pro

TODO

## NHibernate

By default, NHibernate does not support a clean separation between the data access layer and the rest of the application. This is due to the way the lazy-loading works, which requires an active `ISession` even when lazy-loading isn't desired.

The work-around is to explicitly trigger lazy-loading when the child rows are desired. When the child rows are not desired, block lazy-loading by setting the collection property to an empty list.

For partial deletes, you have to explicitly find and delete the child rows that are no longer needed. Furthermore, this must be done in a separate `ISession` to avoid a ` NonUniqueObjectException`.

@snippet cs [..\Recipes.NHibernate\ModelWithChildren\ModelWithChildrenRepository.cs] ModelWithChildrenRepository

## RepoDb

TODO

## ServiceStack

TODO
