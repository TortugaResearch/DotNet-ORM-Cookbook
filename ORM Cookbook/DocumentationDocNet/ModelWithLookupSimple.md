# CRUD Operations on Model with Integer-Based Foreign Key

This use case demonstrates performing Create, Read, Update, and Delete operations on an object that has a foreign key reference to a lookup table. The FK reference is represented as an integer.

## Prototype Repository

@snippet cs [..\Recipes.Core\ModelWithLookup\IEmployeeSimple.cs] IEmployeeSimple

@snippet cs [..\Recipes.Core\ModelWithLookup\IModelWithLookupSimpleRepository`1.cs] IModelWithLookupSimpleRepository{TEmployee}

## ADO.NET

In order to promote code reuse, object population has been moved into the model's constructor.

@snippet cs [..\Recipes.Ado\ModelWithLookup\EmployeeSimple.cs] EmployeeSimple

@snippet cs [..\Recipes.Ado\ModelWithLookup\ModelWithLookupSimpleRepository.cs] ModelWithLookupSimpleRepository

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\ModelWithLookup\ModelWithLookupSimpleRepository.cs] ModelWithLookupSimpleRepository

## Dapper

@snippet cs [..\Recipes.Dapper\ModelWithLookup\ModelWithLookupSimpleRepository.cs] ModelWithLookupSimpleRepository

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\ModelWithLookup\ModelWithLookupSimpleRepository.cs] ModelWithLookupSimpleRepository

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
