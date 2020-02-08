# Connection Sharing

These scenarios demonstrate how to share a connection. This is especially important when combining two ORMs in the same transaction.

## Scenario Prototype

@snippet cs [..\Recipes\ConnectionSharing\IConnectionSharingScenario`4.cs] IConnectionSharingScenario{TModel, TConnection, TTransaction, TState}

## ADO.NET

Not applicable, ADO.NET always works directly on raw connection/transaction objecsts.

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

## Dapper

Not applicable, Dapper always works directly on raw connection/transaction objecsts.

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

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
