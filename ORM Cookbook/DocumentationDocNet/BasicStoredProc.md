﻿# Basic Stored Procedures

These scenarios demonstrate how to call basic stored procedures that return a single resultset. This can be interpreted as a value, a row, or a collection of rows. 

Future scenarios will cover topics such as:

* Multiple Result sets
* Output parameter(s)
* Return parameter

## Scenario Prototype

@snippet cs [..\Recipes\BasicStoredProc\IBasicStoredProcScenario`2.cs] IBasicStoredProcScenario{TEmployeeClassification, TEmployeeClassificationWithCount}

## Database Stored Procedures

@snippet text [..\OrmCookbookDB\HR\Programability\CountEmployeesByClassification.sql] .

@snippet text [..\OrmCookbookDB\HR\Programability\CreateEmployeeClassification.sql] .

@snippet text [..\OrmCookbookDB\HR\Programability\GetEmployeeClassifications.sql] .

## ADO.NET

@snippet cs [..\Recipes.Ado\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## Dapper

@snippet cs [..\Recipes.Dapper\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## Entity Framework Core

To use stored procedures that return values, a class is needed to receive the results. This is true even if a scalar value is returned.

The receiver class should be registered in the DbContext just like any other Entity, but with two additional requirements in the `modelBuilder` configuration:

* `entity.HasNoKey();`

@snippet cs [..\Recipes.EntityFrameworkCore\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO