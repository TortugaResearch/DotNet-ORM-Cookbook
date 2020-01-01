# CRUD Operations on Immutable Objects

These use cases demonstrate how to perform Create, Read, Update, and Delete operations on immutable objects. 

## Prototype Repository

@snippet cs [..\Recipes.Core\Immutable\IImmutableRepository`1.cs] IImmutableRepository{TReadOnlyModel}

@snippet cs [..\Recipes.Core\Immutable\IReadOnlyEmployeeClassification.cs] IReadOnlyEmployeeClassification


## ADO.NET

Since ADO doesn't directly interact with models, no changes are needed for immutable objects other than to call a constructor instead of setting individual properties.

@snippet cs [..\Recipes.ADO\Immutable\ImmutableRepository.cs] ImmutableRepository

## Chain

Chain natively supports working with immutable objects, no conversions are needed.

To populate immutable objects, use either the `InferConstructor` option or a `.WithConstructor<...>` link to indicate that a non-default constructor should be used.

@snippet cs [..\Recipes.Tortuga.Chain\Immutable\ImmutableRepository.cs] ImmutableRepository

## Dapper

Dapper natively supports working with immutable objects, no conversions are needed.

No special handling is needed to call a non-default constructor.

@snippet cs [..\Recipes.Dapper\Immutable\ImmutableRepository.cs] ImmutableRepository

## Entity Framework Core

TODO

## NHibernate

NHibernate does not directly support immutable objects. You can overcome this by using a pair of conversions between the immutable object and the mutable entity.


@snippet cs [..\Recipes.NHibernate\Immutable\ReadOnlyEmployeeClassification.cs] <Constructor>(EmployeeClassification)

@snippet cs [..\Recipes.NHibernate\Immutable\ReadOnlyEmployeeClassification.cs] ToEntity

These conversions are used in the repository before write operations and after read operations.

@snippet cs [..\Recipes.NHibernate\Immutable\ImmutableRepository.cs] ImmutableRepository


## RepoDb

TODO

## ServiceStack

TODO
