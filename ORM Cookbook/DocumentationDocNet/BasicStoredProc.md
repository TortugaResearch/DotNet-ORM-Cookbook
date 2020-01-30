# Basic Stored Procedures

These scenarios demonstrate how to call basic stored procedures that return a single resultset. This can be interpreted as a value, a row, or a collection of rows. 

Future scenarios will cover topics such as:

* Multiple Resultsets
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

## Entity Framework 6

TODO

## Entity Framework Core

To use stored procedures that return values, a class is needed to receive the results. This is true even if a scalar value is returned.

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\EmployeeClassificationWithCount.cs] EmployeeClassificationWithCount

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\EmployeeClassificationKeyHolder.cs] EmployeeClassificationKeyHolder

The receiver class should be registered in the DbContext as shown below:

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\OrmCookbookContext.BasicStoredProc.cs] OrmCookbookContext

@snippet cs [..\Recipes.EntityFrameworkCore\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## LINQ to DB

To use stored procedures that return values, a class is needed to receive the results. This is true even if a scalar value is returned.

@snippet cs [..\Recipes.LinqToDB\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## LLBLGen Pro 

To use stored procedures that return a resultset, a class is needed to receive the results.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## NHibernate

TODO

## RepoDb

@snippet cs [..\Recipes.RepoDb\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\BasicStoredProc\BasicStoredProcScenario.cs] BasicStoredProcScenario
