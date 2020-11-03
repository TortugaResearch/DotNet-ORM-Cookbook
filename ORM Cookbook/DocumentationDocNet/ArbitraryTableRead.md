# Read from an Arbitrary Table

This scenario demonstrate how to read all of the rows/columns of a table when the table name is only known at run time. 

## Scenario Prototype

@snippet cs [..\Recipes\ArbitraryTableRead\IArbitraryTableReadScenario`1.cs] IArbitraryTableReadScenario{T}

## ADO.NET

@alert danger
Verify that the schema and table name exist to avoid SQL injection attacks.
@end

@snippet cs [..\Recipes.Ado\ArbitraryTableRead\ArbitraryTableReadScenario.cs] ArbitraryTableReadScenario

## Chain

Chain will verify the table exists before executing the query to ensure that SQL injection is not possible.

@snippet cs [..\Recipes.Tortuga.Chain\ArbitraryTableRead\ArbitraryTableReadScenario.cs] ArbitraryTableReadScenario

@snippet cs [..\Recipes.Tortuga.Chain\ArbitraryTableRead\ArbitraryTableReadScenario.cs] ArbitraryTableReadScenario2

## Dapper

@alert danger
Verify that the schema and table name exist to avoid SQL injection attacks.
@end

@snippet cs [..\Recipes.Dapper\ArbitraryTableRead\ArbitraryTableReadScenario.cs] ArbitraryTableReadScenario

## DbConnector

TODO

## Entity Framework 6

TODO

## Entity Framework Core

@alert danger
Verify that the schema and table name exist to avoid SQL injection attacks.
@end

@snippet cs [..\Recipes.EntityFrameworkCore\ArbitraryTableRead\ArbitraryTableReadScenario.cs] ArbitraryTableReadScenario

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
