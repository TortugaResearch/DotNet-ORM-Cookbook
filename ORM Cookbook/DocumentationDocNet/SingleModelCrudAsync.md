# Single Model CRUD Async

This use case adds async support to the [Single Model CRUD use case](SingleModelCrud.htm).

## Prototype Repository

As a general rule, cancellation tokens are provided for read operations but not write operations. The reason is that users may wish to cancel loading a record or set of records, and this can be done safely. But if they try to cancel a write operation then it becomes a race condition between the database operation completing (including any open transactions) and the user's cancellation attempt. (There are exceptions, which will be handled in future use cases.)

@snippet cs [..\Recipes.Core\SingleModelCrudAsync\ISingleModelCrudAsyncRepository`1.cs] ISingleModelCrudAsyncRepository{TEmployeeClassification}

## ADO.NET

With ADO.NET, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [../Recipes.Ado/SingleModelCrudAsync/SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository

## Chain

With Tortuga Chain, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.Tortuga.Chain\SingleModelCrudAsync\SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository

## Dapper

For non-cancellable operation, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

If cancellation is required, then you must wrap your parameters in a `CommandDefinition`. For example,

Original:

@snippet cs [../Recipes.Dapper/SingleModelCrud/SingleModelCrudRepository.cs] GetByKey

Async with cancellation:

@snippet cs [../Recipes.Dapper/SingleModelCrudAsync/SingleModelCrudAsyncRepository.cs] GetByKeyAsync

Here is the full repository.

@snippet cs [../Recipes.Dapper/SingleModelCrudAsync/SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository

## Entity Framework Core

For non-cancellable operation, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

For cancellable operations, you may need to explicitly create object arrays for the parameters. Otherwise it may think that the cancellation token is another query parameter.

Original:

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudRepository.cs] GetByKey

Async:

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrudAsync\SingleModelCrudAsyncRepository.cs] GetByKeyAsync


@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrudAsync\SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository

## LLBLGen Pro

With LLBLGen Pro, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\SingleModelCrudAsync\SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository


## NHibernate

With NHibernate, the only changes are to add `await`, `async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [../Recipes.NHibernate/SingleModelCrudAsync/SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository

## RepoDb

With RepoDb, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.RepoDb\SingleModelCrudAsync\SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository

## ServiceStack

With ServiceStack, the only changes are to add `await`, `Async`, and `.ConfigureAwait(false)` to the appropriate places. 

@snippet cs [..\Recipes.ServiceStack\SingleModelCrudAsync\SingleModelCrudAsyncRepository.cs] SingleModelCrudAsyncRepository
