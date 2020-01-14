# Projecting with a Join

These use cases demonstrate how to define a join and project the reults into a simple object. 

See [CRUD Operations on Model with Object-Based Foreign Key](ModelWithLookupComplex.htm) and [CRUD Operations on Model with Child Records](ModelWithChildren.htm) for other examples of performing joins.

## Prototype Repository

For the purpose of these examples, a database view may not be used.

@snippet cs [..\Recipes.Core\Joins\IJoinsRepository`2.cs] IJoinsRepository{TEmployeeDetail, TEmployeeSimple}

## ADO.NET

@snippet cs [..\Recipes.Ado\Joins\JoinsRepository.cs] JoinsRepository

## Chain

Chain doesn't natively support joins, so raw SQL (or a view) has to be used as a fallback. 

@snippet cs [..\Recipes.Tortuga.Chain\Joins\JoinsRepository.cs] JoinsRepository

## Dapper

@snippet cs [..\Recipes.Dapper\Joins\JoinsRepository.cs] JoinsRepository

## Entity Framework Core

EF Core native supports joins, but not implicit projections. Multiple objects need to be explicitly mapped.

@snippet cs [..\Recipes.EntityFrameworkCore\Joins\JoinsRepository.cs] JoinsRepository

## LLBLGen Pro 

LLBLGen Pro native supports joins, but not implicit projections in the entity API. It does in the plain SQL API. 
In the entity API, multiple objects need to be explicitly mapped.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Joins\JoinsRepository.cs] JoinsRepository

Additionally, LLBLGen Pro supports design time projects over an entity graph, called Typed Lists. Here a Typed List, EmployeeJoined
has been created which is the same projection as the one in the queries in the normal linq repository.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Joins\JoinsRepositoryTypedList.cs] JoinsRepositoryTypedList

## NHibernate

NHibernate native supports joins, but not projections. Multiple objects need to be explicitly mapped.

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeDetail.hbm.xml] .

@snippet cs [..\Recipes.NHibernate\Joins\JoinsRepository.cs] JoinsRepository

## RepoDb

TODO

## ServiceStack

TODO
