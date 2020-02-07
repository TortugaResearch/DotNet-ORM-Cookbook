# Connection Sharing

These scenarios demonstrate how to share a connection. This is especially important when combining two ORMs in the same transaction.

## Scenario Prototype

@snippet cs [..\Recipes\ConnectionSharing\IConnectionSharingScenario`3.cs] IConnectionSharingScenario{TModel, TConnection, TTransaction}

## ADO.NET

Not applicable, ADO.NET always works directly on raw connection/transaction objecsts.

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

## Dapper

Not applicable, Dapper always works directly on raw connection/transaction objecsts.

## Entity Framework 6

@snippet cs [..\Recipes.Tortuga.EntityFramework\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

## Entity Framework Core

@snippet cs [..\Recipes.Tortuga.EntityFrameworkCore\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

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
