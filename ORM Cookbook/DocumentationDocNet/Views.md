# Reading from Views

These use cases demonstrate how to reads from a view. 

Note: While writing to views is supported by some databases, that capability is outside the scope of this use case.

## Prototype Repository

@snippet cs [..\Recipes.Core\Views\IViewsRepository`2.cs] IViewsRepository{TEmployeeDetail, TEmployeeSimple}


## ADO.NET

@snippet cs [..\Recipes.Ado\Views\ViewsRepository.cs] ViewsRepository

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\Views\ViewsRepository.cs] ViewsRepository


## Dapper

@snippet cs [..\Recipes.Dapper\Views\ViewsRepository.cs] ViewsRepository

## Entity Framework Core

Starting with EF Core 3.0, views are treated like tables, but with two additional requirements in the `modelBuilder` configuration:

* `entity.HasNoKey();`
* `entity.ToView(name, schema);`

@snippet cs [..\Recipes.EntityFrameworkCore\Views\ViewsRepository.cs] ViewsRepository

## LLBLGen Pro 

TODO

## NHibernate

In NHibernate, views require a unique ID column. They must also be configured as `mutable="false"`.

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeDetail.hbm.xml] .

@snippet cs [..\Recipes.NHibernate\Views\ViewsRepository.cs] ViewsRepository

## RepoDb

TODO

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Views\ViewsRepository.cs] ViewsRepository
