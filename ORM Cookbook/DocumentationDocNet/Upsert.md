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

## DbConnector

@snippet cs [..\Recipes.DbConnector\Upsert\UpsertScenario.cs] UpsertScenario

## Entity Framework 6

EF Core doesn't directly support an atomic upsert, so often a read must proceed the update.

@snippet cs [..\Recipes.EntityFramework\Upsert\UpsertScenario.cs] UpsertScenario

## Entity Framework Core

EF Core doesn't directly support an atomic upsert, so often a read must proceed the update.

@snippet cs [..\Recipes.EntityFrameworkCore\Upsert\UpsertScenario.cs] UpsertScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\Upsert\UpsertScenario.cs] UpsertScenario

## LLBLGen Pro 

LLBLGen Pro doesn't support an atomic upsert, so a read must proceed the update.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Upsert\UpsertScenario.cs] UpsertScenario

## NHibernate

NHibernate doesn't directly support an atomic upsert, so often a read must proceed the update.

@snippet cs [..\Recipes.NHibernate\Upsert\UpsertScenario.cs] UpsertScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\Upsert\UpsertScenario.cs] UpsertScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Upsert\UpsertScenario.cs] UpsertScenario
