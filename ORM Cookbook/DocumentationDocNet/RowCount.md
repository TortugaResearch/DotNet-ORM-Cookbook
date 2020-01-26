# Row Counts

These scenarios demonstrate how to get a row count from a table. 

## Scenario Prototype

@snippet cs [..\Recipes\RowCount\IRowCountScenario`1.cs] IRowCountScenario{TEmployeeSimple}

## ADO.NET

In ADO.NET, `ExecuteScalar` returns the first column of the first row in the resultset. Everything else is discarded.

@snippet cs [..\Recipes.Ado\RowCount\RowCountScenario.cs] RowCountScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\RowCount\RowCountScenario.cs] RowCountScenario

## Dapper

@snippet cs [..\Recipes.Dapper\RowCount\RowCountScenario.cs] RowCountScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\RowCount\RowCountScenario.cs] RowCountScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\RowCount\RowCountScenario.cs] RowCountScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\RowCount\RowCountScenario.cs] RowCountScenario

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\RowCount\RowCountScenario.cs] RowCountScenario

## NHibernate

@snippet cs [..\Recipes.NHibernate\RowCount\RowCountScenario.cs] RowCountScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\RowCount\RowCountScenario.cs] RowCountScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\RowCount\RowCountScenario.cs] RowCountScenario
