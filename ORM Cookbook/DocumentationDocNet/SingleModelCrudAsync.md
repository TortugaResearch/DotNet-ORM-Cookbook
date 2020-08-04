﻿# Single Model CRUD Async

This scenario adds async support to the [Single Model CRUD scenario](SingleModelCrud.htm).

## Scenario Prototype

As a general rule, cancellation tokens are provided for read operations but not write operations. The reason is that users may wish to cancel loading a record or set of records, and this can be done safely. But if they try to cancel a write operation then it becomes a race condition between the database operation completing (including any open transactions) and the user's cancellation attempt. (There are exceptions, which will be handled in future scenarios.)

@snippet cs [..\Recipes\SingleModelCrudAsync\ISingleModelCrudAsyncScenario`1.cs] ISingleModelCrudAsyncScenario{TEmployeeClassification}

## ADO.NET

With ADO.NET, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [../Recipes.Ado/SingleModelCrudAsync/SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## Chain

With Tortuga Chain, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.Tortuga.Chain\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## Dapper

For non-cancellable operation, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

If cancellation is required, then you must wrap your parameters in a `CommandDefinition`. For example,

Original:

@snippet cs [../Recipes.Dapper/SingleModelCrud/SingleModelCrudScenario.cs] GetByKey

Async with cancellation:

@snippet cs [../Recipes.Dapper/SingleModelCrudAsync/SingleModelCrudAsyncScenario.cs] GetByKeyAsync

Here is the full repository.

@snippet cs [../Recipes.Dapper/SingleModelCrudAsync/SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with alternate implementations as shown below.
@end

### Dapper.Contrib

The Dapper.Contrib library can elimiante the boilerplate for some common scenarios. However, it doesn't support a `CancellationToken` so it may not be appropriate for all use cases.


@snippet cs [../Recipes.Dapper/SingleModelCrudAsync/SingleModelCrudAsyncScenarioContrib.cs] SingleModelCrudAsyncScenarioContrib

## DbConnector

For non-cancellable operation, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

If cancellation is required, then set the `CancellationToken` when invoking `Execute`. For example,

Original:

@snippet cs [../Recipes.DbConnector/SingleModelCrud/SingleModelCrudScenario.cs] GetByKey

Async with cancellation:

@snippet cs [../Recipes.DbConnector/SingleModelCrudAsync/SingleModelCrudAsyncScenario.cs] GetByKeyAsync

Here is the full repository.

@snippet cs [../Recipes.DbConnector/SingleModelCrudAsync/SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## Entity Framework 6

To make an Entity Framework repository asynchronous, you need to import the `System.Data.Entity` namespace. This exposes the async version of the LINQ extension methods needed. 

For non-cancellable operation, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

For cancellable operations, you may need to explicitly create object arrays for the parameters. Otherwise it may think that the cancellation token is another query parameter.

Original:

@snippet cs [..\Recipes.EntityFramework\SingleModelCrud\SingleModelCrudScenario.cs] GetByKey

Async:

@snippet cs [..\Recipes.EntityFramework\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] GetByKeyAsync


@snippet cs [..\Recipes.EntityFramework\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario


## Entity Framework Core

To make an Entity Framework repository asynchronous, you need to import the `System.Data.Entity` namespace. This exposes the async version of the LINQ extension methods needed. 

For non-cancellable operation, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

For cancellable operations, you may need to explicitly create object arrays for the parameters. Otherwise it may think that the cancellation token is another query parameter.

Original:

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudScenario.cs] GetByKey

Async:

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] GetByKeyAsync


@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## LINQ to DB

With LINQ to DB, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places.

@snippet cs [..\Recipes.LinqToDB\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## LLBLGen Pro

With LLBLGen Pro, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario


## NHibernate

With NHibernate, the only changes are to add `await`, `async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [../Recipes.NHibernate/SingleModelCrudAsync/SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## RepoDb

With RepoDb, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.RepoDb\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## ServiceStack

With ServiceStack, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.ServiceStack\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

## XPO

With XPO, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.Xpo\SingleModelCrudAsync\SingleModelCrudAsyncScenario.cs] SingleModelCrudAsyncScenario

@alert info
Due to cookbook architecture limitations, here we have to use default Sessions instead of Units Of Work. For sessions, we call explicit async transactions.
@end
