# Batch Inserts with Large Collections

This scenario demonstrate how to perform insert operations on collections of 1,000 to 10,000 objects. Some ORMs require special handling for collections of this size. 

For other batch operations, see [CRUD Operations on Multiple Objects](LargeBatch.htm).

For better performance, consider using a [Bulk Insert](BulkInsert.htm) instead. 

## Scenario Prototype

@snippet cs [..\Recipes\LargeBatch\ILargeBatchScenario`1.cs] ILargeBatchScenario{TEmployeeSimple}

For ORMs that require breaking up the size of the batch, this function is provided.

@snippet cs [..\Recipes\LargeBatch\Utilities.cs] BatchAsLists{T}

## ADO.NET

Large collections need to be broken up into batches. For SQL Server, the maximum batch size is approximately `2100/number of columns`.

@snippet cs [..\Recipes.ADO\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## Chain

The `InsertMultipleBatch` command overcomes the database's limit on parameter counts, but doesn't offer as many features as `InsertBatch`. 

The `InsertMultipleBatch` command is not atomic and should be used in a transaction.

@snippet cs [..\Recipes.Tortuga.Chain\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## Dapper

Large collections need to be broken up into batches. For SQL Server, the maximum batch size is approximately `2100/number of columns`.

@snippet cs [..\Recipes.Dapper\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## Entity Framework 6

Entity Framework can suffer severe performance degration as the number of objects it tracks increases. To mitigate this effect, a new `DBContext` after every batch is necessary. Start with a batch size of 100 and adjust as needed.

@snippet cs [..\Recipes.EntityFramework\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## Entity Framework Core

No changes are needed. 

@snippet cs [..\Recipes.EntityFrameworkCore\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## LINQ to DB

LinqToDB only supports batch inserts from a collection of objects. 

Note the use of `BulkCopyType.MultipleRows`.

@snippet cs [..\Recipes.LinqToDB\BulkInsert\BulkInsertScenario.cs] BulkInsert

For more information see [Bulk Copy (Bulk Insert)](https://linq2db.github.io/articles/sql/Bulk-Copy.html)

## LLBLGen Pro 

No changes are needed. 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## NHibernate

No changes are needed. 

@snippet cs [..\Recipes.NHibernate\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## RepoDb

No changes are needed. 

@snippet cs [..\Recipes.RepoDb\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario

## ServiceStack

No changes are needed. 

@snippet cs [..\Recipes.ServiceStack\LargeBatch\LargeBatchScenario.cs] LargeBatchScenario
