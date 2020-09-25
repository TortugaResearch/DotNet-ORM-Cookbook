# CRUD Operations on Model with Child Records using Lazy Loading (a.k.a. deferred loading)

This scenario demonstrates performing Create, Read, Update, and Delete operations on an object that includes a collection of child records with lazy loading enabled.

## Scenario Prototype

@snippet cs [..\Recipes.Interfaces\IProductLine`1.cs] IProductLine{TProduct}
@snippet cs [..\Recipes.Interfaces\IProduct.cs] IProduct

@snippet cs [..\Recipes\ModelWithChildren\IModelWithChildrenScenario`2.cs] IModelWithChildrenScenario{TProductLine, TProduct}

## ADO.NET

Lazy loading is not supported.

## Chain

Lazy loading is not supported.

## Dapper

Lazy loading is not supported.

## DbConnector

TODO

## Entity Framework 6

TODO

## Entity Framework Core

TODO

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


## XPO

XPO Objects does lazy loading out of box, so you don't need to manually include or exclude linked objects and collections.

Use the [AggregatedAttribute](https://docs.devexpress.com/XPO/DevExpress.Xpo.AggregatedAttribute) to 
- automatically remove child objects once the parent object is removed,
- automatically update child rows when a parent row is updated.


@snippet cs [..\Recipes.Xpo\ModelWithChildrenLazyLoading\ModelWithChildrenLazyLoadingScenario.cs] ModelWithChildrenLazyLoadingScenario
