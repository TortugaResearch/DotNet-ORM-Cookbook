# Reading a Single Column from a Table

These scenarios demonstrate how to read a single column from a table. 

For an example of reading a scalar value, see [Reading a Scalar Value from a Row](SingleColumn.htm)

## Scenario Prototype

@snippet cs [..\Recipes\SingleColumn\ISingleColumnScenario.cs] ISingleColumnScenario

## ADO.NET

In ADO.NET, `ExecuteScalar` returns the first column of the first row in the resultset. Everything else is discarded.

@snippet cs [..\Recipes.Ado\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## Dapper

@snippet cs [..\Recipes.Dapper\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## DbConnector

@snippet cs [..\Recipes.DbConnector\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## NHibernate

TODO

## RepoDb

@snippet cs [..\Recipes.RepoDb\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\SingleColumn\SingleColumnScenario.cs] SingleColumnScenario
