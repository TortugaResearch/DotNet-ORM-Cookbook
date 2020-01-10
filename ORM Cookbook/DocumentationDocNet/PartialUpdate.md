# Partial Updates

These use cases demonstrate how to perform partial updates on a row. 

## Prototype Repository

@snippet cs [..\Recipes.Core\PartialUpdate\IPartialUpdateRepository`1.cs] UpdateWithObject

@snippet cs [..\Recipes.Core\PartialUpdate\IPartialUpdateRepository`1.cs] UpdateWithSeparateParameters

## ADO.NET

@snippet cs [..\Recipes.Ado\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.Ado\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.Tortuga.Chain\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## Dapper

@snippet cs [..\Recipes.Dapper\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.Dapper\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## Entity Framework Core

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.EntityFrameworkCore\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.EntityFrameworkCore\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## LLBLGen Pro

To perform a partial update, you can decide to first fetch a record and then modify it, or to update directly without fetching 
it first. 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.LLBLGenPro\Recipes\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## NHibernate

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.NHibernate\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.NHibernate\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## RepoDb

@snippet cs [..\Recipes.RepoDb\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.RepoDb\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters

## ServiceStack

In ServiceStack, partial updates have to be 'unpacked'. Updated columns are passed in one parameter and filter column(s) (e.g. primary key) in a separate parameter.

@snippet cs [..\Recipes.ServiceStack\PartialUpdate\PartialUpdateRepository.cs] UpdateWithObject

@snippet cs [..\Recipes.ServiceStack\PartialUpdate\PartialUpdateRepository.cs] UpdateWithSeparateParameters






