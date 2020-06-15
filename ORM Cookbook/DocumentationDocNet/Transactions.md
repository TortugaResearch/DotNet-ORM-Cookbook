# Working with Transactions

These scenarios demonstrate how to create a transaction and then commit or rollback. 

## Scenario Prototype

@snippet cs [..\Recipes\Transactions\ITransactionsScenario`1.cs] ITransactionsScenario{TEmployeeClassification}

## ADO.NET

While there is an open transaction against a connection, all commands must be explcitly provided with the transaction object. 

@snippet cs [..\Recipes.Ado\Transactions\TransactionsScenario.cs] TransactionsScenario

## Chain

When calling `DataSource.BeginTransaction()`, you get a `TransactionalDataSource` with the capabilities of the original `DataSource`. 

Unlike a normal `DataSource`, a `TransactionalDataSource` holds an open database connection and thus must be disposed after use.

@snippet cs [..\Recipes.Tortuga.Chain\Transactions\TransactionsScenario.cs] TransactionsScenario

## Dapper

While there is an open transaction against a connection, all commands must be explcitly provided with the transaction object. 

@snippet cs [..\Recipes.Dapper\Transactions\TransactionsScenario.cs] TransactionsScenario

## DbConnector

DbConnector will automatically create transactions for all `Non-Query` executions or when invoking `WithIsolationLevel` and setting a proper isolation level.

Otherwise, a custom transaction can be used and configured via the `Execute` functions.

@snippet cs [..\Recipes.DbConnector\Transactions\TransactionsScenario.cs] TransactionsScenario

## Entity Framework 6

Entity Framework will automatically create and commit a transaction when you call `SaveChanges()`. To override this behavior, you can explicitly create a transaction. 

When setting the isolation level, you need to use an extension method defined in `Microsoft.EntityFramework.RelationalDatabaseFacadeExtensions`.

@snippet cs [..\Recipes.EntityFramework\Transactions\TransactionsScenario.cs] TransactionsScenario

## Entity Framework Core

EF Core will automatically create and commit a transaction when you call `SaveChanges()`. To override this behavior, you can explicitly create a transaction. 

When setting the isolation level, you need to use an extension method defined in `Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions`.

@snippet cs [..\Recipes.EntityFrameworkCore\Transactions\TransactionsScenario.cs] TransactionsScenario

## LINQ to DB

While the transaction is open, all operations are automatically associated with the transaction.

@snippet cs [..\Recipes.LinqToDB\Transactions\TransactionsScenario.cs] TransactionsScenario

## LLBLGen Pro 

The `DataAccessAdapter` manages the transaction itself.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Transactions\TransactionsScenario.cs] TransactionsScenario

## NHibernate

While the transaction is open, all operations are automatically associated with the transaction.

@snippet cs [..\Recipes.NHibernate\Transactions\TransactionsScenario.cs] TransactionsScenario

## RepoDb

Simply call the `BeginTransaction()` method of the `DbConnection` object and pass the instance of `DbTransaction` when you are calling any of the operations.

@snippet cs [..\Recipes.RepoDb\Transactions\TransactionsScenario.cs] TransactionsScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Transactions\TransactionsScenario.cs] TransactionsScenario
