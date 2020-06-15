# CRUD Operations on Model with Integer-Based Foreign Key

This scenario demonstrates performing Create, Read, Update, and Delete operations on an object that has a foreign key reference to a lookup table. The FK reference is represented as an integer.

## Scenario Prototype

@snippet cs [..\Recipes.Interfaces\IEmployeeSimple.cs] IEmployeeSimple

@snippet cs [..\Recipes\ModelWithLookup\IModelWithLookupSimpleScenario`1.cs] IModelWithLookupSimpleScenario{TEmployee}

## ADO.NET

In order to promote code reuse, object population has been moved into the model's constructor.

@snippet cs [..\Recipes.Ado\Models\EmployeeSimple.cs] EmployeeSimple

@snippet cs [..\Recipes.Ado\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## Dapper

@snippet cs [..\Recipes.Dapper\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## DbConnector

@snippet cs [..\Recipes.DbConnector\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## LINQ to DB

TODO

## LLBLGen Pro

@snippet cs [..\Recipes.LLBLGenPro\Recipes\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## NHibernate

TODO

## RepoDb

@snippet cs [..\Recipes.RepoDb\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\ModelWithLookup\ModelWithLookupSimpleScenario.cs] ModelWithLookupSimpleScenario
