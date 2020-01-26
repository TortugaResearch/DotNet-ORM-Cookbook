# CRUD Operations on Immutable Objects

These scenarios demonstrate how to perform Create, Read, Update, and Delete operations on immutable objects. 

## Scenario Prototype

@snippet cs [..\Recipes\Immutable\IImmutableScenario`1.cs] IImmutableScenario{TReadOnlyModel}

@snippet cs [..\Recipes.Interfaces\IReadOnlyEmployeeClassification.cs] IReadOnlyEmployeeClassification


## ADO.NET

Since ADO doesn't directly interact with models, no changes are needed for immutable objects other than to call a constructor instead of setting individual properties.

@snippet cs [..\Recipes.ADO\Immutable\ImmutableScenario.cs] ImmutableScenario

## Chain

Chain natively supports working with immutable objects, no conversions are needed.

To populate immutable objects, use either the `InferConstructor` option or a `.WithConstructor<...>` link to indicate that a non-default constructor should be used.

@snippet cs [..\Recipes.Tortuga.Chain\Immutable\ImmutableScenario.cs] ImmutableScenario

## Dapper

Dapper natively supports working with immutable objects, no conversions are needed.

No special handling is needed to call a non-default constructor.

@snippet cs [..\Recipes.Dapper\Immutable\ImmutableScenario.cs] ImmutableScenario

## Entity Framework 6

Entity Framework does not directly support immutable objects. You can overcome this by using a pair of conversions between the immutable object and the mutable entity.

Objects need to be materialized client-side before being mapped to the immutable type.

@snippet cs [..\Recipes.EntityFramework\Models\ReadOnlyEmployeeClassification.cs] <Constructor>(EmployeeClassification)

@snippet cs [..\Recipes.EntityFramework\Models\ReadOnlyEmployeeClassification.cs] ToEntity

These conversions are used in the repository before write operations and after read operations.

@snippet cs [..\Recipes.EntityFramework\Immutable\ImmutableScenario.cs] ImmutableScenario

## Entity Framework Core

Entity Framework Core does not directly support immutable objects. You can overcome this by using a pair of conversions between the immutable object and the mutable entity.

@snippet cs [..\Recipes.EntityFrameworkCore\Models\ReadOnlyEmployeeClassification.cs] <Constructor>(EmployeeClassification)

@snippet cs [..\Recipes.EntityFrameworkCore\Models\ReadOnlyEmployeeClassification.cs] ToEntity

These conversions are used in the repository before write operations and after read operations.

@snippet cs [..\Recipes.EntityFrameworkCore\Immutable\ImmutableScenario.cs] ImmutableScenario

## LINQ to DB

LINQ to DB does not directly support immutable objects. You can overcome this by using a pair of conversions between the immutable object and the mutable entity.

@snippet cs [..\Recipes.LinqToDB\Models\ReadOnlyEmployeeClassification.cs] <Constructor>(EmployeeClassification)

@snippet cs [..\Recipes.LinqToDB\Models\ReadOnlyEmployeeClassification.cs] ToEntity

These conversions are used in the repository before write operations and after read operations.

@snippet cs [..\Recipes.LinqToDB\Immutable\ImmutableScenario.cs] ImmutableScenario

## LLBLGen Pro 

LLBLGen Pro supports 'action' specifications on entities, e.g. an entity can only be fetched, or fetched and updated, but e.g. not deleted. An entity that's marked as 'Read' can't be updated, deleted or inserted. The scope of the recipes in this cookbook however
focus on immutable data in-memory. LLBLGen Pro does not directly support these objects, You can overcome this by using a pair of conversions between the immutable object and the mutable entity.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Immutable\ReadOnlyEmployeeClassification.cs] <Constructor>(EmployeeClassificationEntity)

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Immutable\ReadOnlyEmployeeClassification.cs] ToEntity

These conversions are used in the repository before write operations and after read operations.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Immutable\ImmutableScenario.cs] ImmutableScenario

## NHibernate

NHibernate does not directly support immutable objects. You can overcome this by using a pair of conversions between the immutable object and the mutable entity.


@snippet cs [..\Recipes.NHibernate\Models\ReadOnlyEmployeeClassification.cs] <Constructor>(EmployeeClassification)

@snippet cs [..\Recipes.NHibernate\Models\ReadOnlyEmployeeClassification.cs] ToEntity

These conversions are used in the repository before write operations and after read operations.

@snippet cs [..\Recipes.NHibernate\Immutable\ImmutableScenario.cs] ImmutableScenario

## RepoDb

RepoDb does not directly support immutable objects. You have to manage the conversion between *mutable* and *immutable* objects in order to make it work.

Below is a sample snippet for *immutable* class.

@snippet cs [..\Recipes.RepoDb\Models\ReadOnlyEmployeeClassification.cs] ReadOnlyEmployeeClassification

Below is a sample snippet for *mutable* class.

@snippet cs [..\Recipes.RepoDb\Models\EmployeeClassification.cs] EmployeeClassification

Below is the *immutable repository*.

@snippet cs [..\Recipes.RepoDb\Immutable\ImmutableScenario.cs] ImmutableScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Immutable\ImmutableScenario.cs] ImmutableScenario
