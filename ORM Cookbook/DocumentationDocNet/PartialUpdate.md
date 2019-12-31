# Partial Updates

These use cases demonstrate how to perform partial updates on a row. 

## Prototype Repository

@snippet cs [..\Recipes.Core\PartialUpdate\IPartialUpdateRepository`1.cs] IPartialUpdateRepository{TEmployeeClassification}

## ADO.NET

@snippet cs [..\Recipes.Ado\PartialUpdate\PartialUpdateRepository.cs] Update

## Dapper

@snippet cs [..\Recipes.Dapper\PartialUpdate\PartialUpdateRepository.cs] Update

## Tortuga Chain

@snippet cs [..\Recipes.Tortuga.Chain\PartialUpdate\PartialUpdateRepository.cs] Update

## Entity Framework Core

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.EntityFrameworkCore\PartialUpdate\PartialUpdateRepository.cs] Update

## RepoDb

TODO

@snippet cs [..\Recipes.RepoDb\PartialUpdate\PartialUpdateRepository.cs] Update

## NHibernate

To perform a partial update, first fetch a record and then modify it.

@snippet cs [..\Recipes.NHibernate\PartialUpdate\PartialUpdateRepository.cs] Update






