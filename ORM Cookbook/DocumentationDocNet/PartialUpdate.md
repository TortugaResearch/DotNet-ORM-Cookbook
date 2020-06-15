# Partial Updates

These scenarios demonstrate how to perform partial updates on a row. 

## Scenario Prototype

@snippet cs [..\Recipes\PartialUpdate\IPartialUpdateScenario`1.cs] UpdateWithObject

@snippet cs [..\Recipes\PartialUpdate\IPartialUpdateScenario`1.cs] UpdateWithSeparateParameters

## ADO.NET

@snippet cs [..\Recipes.Ado\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.Ado\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.Tortuga.Chain\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## Dapper

@snippet cs [..\Recipes.Dapper\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.Dapper\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## DbConnector

@snippet cs [..\Recipes.DbConnector\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.DbConnector\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## Entity Framework 6

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.EntityFramework\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.EntityFramework\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## Entity Framework Core

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.EntityFrameworkCore\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.EntityFrameworkCore\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.LinqToDB\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## LLBLGen Pro

To perform a partial update, you can decide to first fetch a record and then modify it, or to update directly without fetching 
it first. 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.LLBLGenPro\Recipes\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## NHibernate

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.NHibernate\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.NHibernate\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## RepoDb

In RepoDb, you can either do the following.

- Limit the properties of your entity model for targetted columns.
- Specify the name of the targe table and pass the object (or *dynamic*).

The *ClassMappedNameCache* class  will help you extract the target table from the original entity.

Code snippets below resembles item #2 above.

@snippet cs [..\Recipes.RepoDb\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.RepoDb\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters

## ServiceStack

In ServiceStack, partial updates have to be 'unpacked'. Updated columns are passed in one parameter and filter column(s) (e.g. primary key) in a separate parameter.

@snippet cs [..\Recipes.ServiceStack\PartialUpdate\PartialUpdateScenario.cs] UpdateWithObject

@snippet cs [..\Recipes.ServiceStack\PartialUpdate\PartialUpdateScenario.cs] UpdateWithSeparateParameters






