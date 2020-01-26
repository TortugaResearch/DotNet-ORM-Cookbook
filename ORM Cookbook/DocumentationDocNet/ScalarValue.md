# Reading a Scalar Value from a Row

These scenarios demonstrate how to read simple scalar values. For example, reading a single field from a row. 

For an example of reading a scalar value from a stored procedure, see [Basic Stored Procedures](BasicStoredProc.htm).

For an example of reading a row count, see [Row Counts](RowCount.htm).

## Scenario Prototype

@snippet cs [..\Recipes\ScalarValue\IScalarValueScenario.cs] IScalarValueScenario

## ADO.NET

In ADO.NET, `ExecuteScalar` returns the first column of the first row in the resultset. Everything else is discarded.

@snippet cs [..\Recipes.Ado\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## Dapper

@snippet cs [..\Recipes.Dapper\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## NHibernate

TODO

## RepoDb

@snippet cs [..\Recipes.RepoDb\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\ScalarValue\ScalarValueScenario.cs] ScalarValueScenario
