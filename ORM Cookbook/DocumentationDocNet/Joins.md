# Projecting with a Join

These scenarios demonstrate how to define a join and project the reults into a simple object. 

See [CRUD Operations on Model with Object-Based Foreign Key](ModelWithLookupComplex.htm) and [CRUD Operations on Model with Child Records](ModelWithChildren.htm) for other examples of performing joins.

## Scenario Prototype

For the purpose of these examples, a database view may not be used.

@snippet cs [..\Recipes\Joins\IJoinsScenario`2.cs] IJoinsScenario{TEmployeeDetail, TEmployeeSimple}

## ADO.NET

@snippet cs [..\Recipes.Ado\Joins\JoinsScenario.cs] JoinsScenario

## Chain

Chain doesn't natively support joins, so raw SQL (or a view) has to be used as a fallback. 

@snippet cs [..\Recipes.Tortuga.Chain\Joins\JoinsScenario.cs] JoinsScenario

## Dapper

@snippet cs [..\Recipes.Dapper\Joins\JoinsScenario.cs] JoinsScenario

## DbConnector

@snippet cs [..\Recipes.DbConnector\Joins\JoinsScenario.cs] JoinsScenario

## Entity Framework 6

Entity Framework natively supports joins, but not implicit projections. Multiple objects need to be explicitly mapped.

@snippet cs [..\Recipes.EntityFramework\Joins\JoinsScenario.cs] JoinsScenario

## Entity Framework Core

EF Core natively supports joins, but not implicit projections. Multiple objects need to be explicitly mapped.

@snippet cs [..\Recipes.EntityFrameworkCore\Joins\JoinsScenario.cs] JoinsScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\Joins\JoinsScenario.cs] JoinsScenario

## LLBLGen Pro 

LLBLGen Pro native supports joins, but not implicit projections in the entity API. It does in the plain SQL API. 
In the entity API, multiple objects need to be explicitly mapped.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Joins\JoinsScenario.cs] JoinsScenario

Additionally, LLBLGen Pro supports design time projects over an entity graph, called Typed Lists. Here a Typed List, EmployeeJoined
has been created which is the same projection as the one in the queries in the normal linq repository.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Joins\JoinsScenarioTypedList.cs] JoinsScenarioTypedList

## NHibernate

NHibernate native supports joins, but not projections. Multiple objects need to be explicitly mapped.

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeDetail.hbm.xml] .

@snippet cs [..\Recipes.NHibernate\Joins\JoinsScenario.cs] JoinsScenario

## RepoDb

RepoDb does not support joins by default, you have to right raw-SQLs to achieve this.

@snippet cs [..\Recipes.RepoDb\Joins\JoinsScenario.cs] JoinsScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Joins\JoinsScenario.cs] JoinsScenario
