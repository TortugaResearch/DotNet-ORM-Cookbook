# Upsert

These scenarios demonstrate how to perform an upsert (insert/update).

Where possible, this should be performed in a single statement.

## Scenario Prototype

@snippet cs [..\Recipes\Upsert\IUpsertScenario`1.cs] IUpsertScenario{TDivision}


## ADO.NET

This code demonstrates the MERGE syntax.

@snippet cs [..\Recipes.Ado\Upsert\UpsertScenario.cs] UpsertScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\Upsert\UpsertScenario.cs] UpsertScenario

## Dapper

@snippet cs [..\Recipes.Dapper\Upsert\UpsertScenario.cs] UpsertScenario

## Entity Framework Core

EF Core doesn't directly support upsert, so often a read must proceed the update.

@snippet cs [..\Recipes.EntityFrameworkCore\Upsert\UpsertScenario.cs] UpsertScenario

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
