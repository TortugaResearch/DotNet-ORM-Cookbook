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

EF Core native supports joins, but not projections. Multiple objects need to be explicitly mapped.

@snippet cs [..\Recipes.EntityFrameworkCore\Joins\JoinsRepository.cs] JoinsRepository

## LLBLGen Pro 

TODO

## NHibernate

EF Core native supports joins, but not projections. Multiple objects need to be explicitly mapped.

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeDetail.hbm.xml] .

@snippet cs [..\Recipes.NHibernate\Joins\JoinsRepository.cs] JoinsRepository

## RepoDb

TODO

## ServiceStack

TODO
