# TryGet, TryUpdate, and TryDelete Operations

These scenarios demonstrate the difference between operations that fail silently and operations that fail with an exception.

## Scenario Prototype

@snippet cs [..\Recipes\TryCrud\ITryCrudScenario`1.cs] ITryCrudScenario{TEmployeeClassification}

## ADO.NET

The trick to the `Update` and `Delete` methods is to read back the row counts from `ExecuteNonQuery`.

@snippet cs [..\Recipes.Ado\TryCrud\TryCrudScenario.cs] TryCrudScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\TryCrud\TryCrudScenario.cs] TryCrudScenario

## Dapper

Like ADO.NET, this uses the row counts returned from the `Execute` command.

@snippet cs [..\Recipes.Dapper\TryCrud\TryCrudScenario.cs] TryCrudScenario

## DbConnector

DbConnector's `NonQuery` returns the number of affected rows, if the non-query ran successfully, from the ADO.NET `ExecuteNonQuery` command.

@snippet cs [..\Recipes.DbConnector\TryCrud\TryCrudScenario.cs] TryCrudScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\TryCrud\TryCrudScenario.cs] TryCrudScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\TryCrud\TryCrudScenario.cs] TryCrudScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\TryCrud\TryCrudScenario.cs] TryCrudScenario

## LLBLGen Pro

@snippet cs [..\Recipes.LLBLGenPro\Recipes\TryCrud\TryCrudScenario.cs] TryCrudScenario

## NHibernate

In some cases you'll need to catch a `StaleStateException` as there is no TryUpdate or TryDelete.

@snippet cs [..\Recipes.NHibernate\TryCrud\TryCrudScenario.cs] TryCrudScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\TryCrud\TryCrudScenario.cs] TryCrudScenario

## ServiceStack

Like ADO.NET, this uses the row counts returned from the `Execute` command.

@snippet cs [..\Recipes.ServiceStack\TryCrud\TryCrudScenario.cs] TryCrudScenario



