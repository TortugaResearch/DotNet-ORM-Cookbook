﻿# Bulk Inserts

This scenario demonstrate how to perform bulk inserts. In order to improve performance, this uses database-specific APIs rather than SQL. 

is used for large collections where SQL isn't appropriate.  operations on collections of 1,000 to 100,000 objects. Some ORMs require special handling for collections of this size. Others use the same pattern seen in .

Smaller collections should be handled with a batch insert. This is described in [CRUD Operations on Multiple Objects](MultipleCrud.htm) and [Batch Inserts with Large Collections](LargeBatch.htm)

## Scenario Prototype

@snippet cs [..\Recipes\BulkInsert\IBulkInsertScenario`1.cs] IBulkInsertScenario{TEmployeeSimple}

For ORMs that do not support bulk inserts from objects, this mapping function is provided.

@snippet cs [..\Recipes\BulkInsert\Utilities.cs] CopyToDataTable

## ADO.NET

@snippet cs [..\Recipes.ADO\BulkInsert\BulkInsertScenario.cs] BulkInsertScenario

## Chain

TODO

## Dapper

Dapper does not have support for bulk inserts.

## Entity Framework 6

Entity Framework does not have support for bulk inserts.

## Entity Framework Core

Entity Framework Core does not have support for bulk inserts.

## LINQ to DB

For more information see [Bulk Copy (Bulk Insert)](https://linq2db.github.io/articles/sql/Bulk-Copy.html)

TODO

## LLBLGen Pro 

TODO

## NHibernate

NHibernate does not have support for bulk inserts.

## RepoDb

TODO

## ServiceStack

ServiceStack does not have support for bulk inserts.