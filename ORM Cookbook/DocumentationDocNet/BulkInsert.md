# Bulk Inserts

This scenario demonstrate how to perform bulk inserts. In order to improve performance, this uses database-specific APIs rather than SQL. 

is used for large collections where SQL isn't appropriate.  operations on collections of 1,000 to 100,000 objects. Some ORMs require special handling for collections of this size. Others use the same pattern seen in .

Smaller collections should be handled with a batch insert. This is described in [CRUD Operations on Multiple Objects](MultipleCrud.htm) and [Batch Inserts with Large Collections](LargeBatch.htm)

## Scenario Prototype

@snippet cs [..\Recipes\LargeBatch\ILargeBatchScenario`1.cs] ILargeBatchScenario{TEmployeeSimple}

## ADO.NET

TODO

## Chain

TODO

## Dapper

TODO

## Entity Framework Core

TODO

## LINQ to DB

TODO

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
