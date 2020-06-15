# Reading from Views

These scenarios demonstrate how to read from a view. 

Note: While writing to views is supported by some databases, that capability is outside the scope of this scenario.

## Scenario Prototype

@snippet cs [..\Recipes\Views\IViewsScenario`2.cs] IViewsScenario{TEmployeeDetail, TEmployeeSimple}

## Database Views

@snippet text [..\OrmCookbookDB\HR\Views\EmployeeDetail.sql] .

## ADO.NET

@snippet cs [..\Recipes.Ado\Views\ViewsScenario.cs] ViewsScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\Views\ViewsScenario.cs] ViewsScenario


## Dapper

@snippet cs [..\Recipes.Dapper\Views\ViewsScenario.cs] ViewsScenario

## DbConnector

@snippet cs [..\Recipes.DbConnector\Views\ViewsScenario.cs] ViewsScenario

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\Views\ViewsScenario.cs] ViewsScenario

## Entity Framework Core

Starting with EF Core 3.0, views are treated like tables, but with two additional requirements in the `modelBuilder` configuration:

* `entity.HasNoKey();`
* `entity.ToView(name, schema);`

@snippet cs [..\Recipes.EntityFrameworkCore\Views\ViewsScenario.cs] ViewsScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\Views\ViewsScenario.cs] ViewsScenario

## LLBLGen Pro 

The views are mapped as regular entities and marked as 'readonly' in the designer. Alternatively we could have mapped them as Typed View
POCOs however these aren't able to participate in entity relationships.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\Views\ViewsScenario.cs] ViewsScenario

## NHibernate

In NHibernate, views require a unique ID column. They must also be configured as `mutable="false"`.

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeDetail.hbm.xml] .

@snippet cs [..\Recipes.NHibernate\Views\ViewsScenario.cs] ViewsScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\Views\ViewsScenario.cs] ViewsScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\Views\ViewsScenario.cs] ViewsScenario
