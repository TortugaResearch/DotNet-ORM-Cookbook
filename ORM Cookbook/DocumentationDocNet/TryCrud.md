# TryGet, TryUpdate, and TryDelete Operations

These use cases demonstrate the difference between operations that fail silently and operations that fail with an exception.

## Prototype Repository

@snippet cs [..\Recipes.Core\TryCrud\ITryCrudRepository`1.cs] ITryCrudRepository{TEmployeeClassification}

## ADO.NET

The trick to the `Update` and `Delete` methods is to read back the row counts from `ExecuteNonQuery`.

@snippet cs [..\Recipes.Ado\TryCrud\TryCrudRepository.cs] TryCrudRepository

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\TryCrud\TryCrudRepository.cs] TryCrudRepository

## Dapper

Like ADO.NET, this uses the row counts returned from the `Execute` command.

@snippet cs [..\Recipes.Dapper\TryCrud\TryCrudRepository.cs] TryCrudRepository

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\TryCrud\TryCrudRepository.cs] TryCrudRepository

## LLBLGen Pro

@snippet cs [..\Recipes.LLBLGenPro\Recipes\TryCrud\TryCrudRepository.cs] TryCrudRepository

## NHibernate

In some cases you'll need to catch a `StaleStateException` as there is no TryUpdate or TryDelete.

@snippet cs [..\Recipes.NHibernate\TryCrud\TryCrudRepository.cs] TryCrudRepository

## RepoDb

TODO

@snippet cs [..\Recipes.RepoDb\TryCrud\TryCrudRepository.cs] TryCrudRepository

## ServiceStack

Like ADO.NET, this uses the row counts returned from the `Execute` command.

@snippet cs [..\Recipes.ServiceStack\TryCrud\TryCrudRepository.cs] TryCrudRepository



