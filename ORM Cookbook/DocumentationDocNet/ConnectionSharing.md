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

The DataAccessAdapter class needs some small adjustments to support this scenario as the scenario actively exposes
objects owned by the adapter and by design this isn't directly supported. To adjust the DataAccessAdapter class we 
create a small partial class of DataAccessAdapter and add the following code:

@snippet cs [..\Recipes.LLBLGenPro\DatabaseSpecific\Extensions\DataAccessAdapter.cs] DataAccessAdapter

The scenario: 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\ConnectionSharing\ConnectionSharingScenario.cs] ConnectionSharingScenario

@alert Important
With some simple adjustments this scenario is supported by LLBLGen Pro, but it's very important to realize that the 
connection and transaction objects have to be managed by you as the controlling objects are out of scope. This means you
have to take care of closing and disposing the connection and committing/rolling back the transaction. 

A better way to do this is by passing the DataAccessAdapter around or use a Unit of Work to collect all work for a transaction, 
or use System.Transactions' TransactionScope for multi-connection transactions. 
@end

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
