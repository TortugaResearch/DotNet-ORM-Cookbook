# CRUD Operations on Multiple Objects

These scenarios demonstrate how to perform Create, Read, Update, and Delete operations on a collection of 100 objects. 

If the ORM supports it, the operation should be performed with a single SQL statement.

## Scenario Prototype

@snippet cs [..\Recipes\MultipleCrud\IMultipleCrudScenario`1.cs] IMultipleCrudScenario{TEmployeeSimple}

## ADO.NET

@snippet cs [..\Recipes.ADO\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## Chain

@snippet cs [..\Recipes.Tortuga.Chain\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## Dapper

@snippet cs [..\Recipes.Dapper\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.
@end

### Dapper.Contrib

The Dapper.Contrib library can elimiante the boilerplate for some common scenarios. 

@snippet cs [../Recipes.Dapper/MultipleCrud/MultipleCrudScenarioContrib.cs] MultipleCrudScenarioContrib

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## Entity Framework Core

@snippet cs [..\Recipes.EntityFrameworkCore\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## LINQ to DB

TODO

## LLBLGen Pro 

@snippet cs [..\Recipes.LLBLGenPro\Recipes\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## NHibernate

@snippet cs [..\Recipes.NHibernate\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## RepoDb

@snippet cs [..\Recipes.RepoDb\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario

## ServiceStack

@snippet cs [..\Recipes.ServiceStack\MultipleCrud\MultipleCrudScenario.cs] MultipleCrudScenario
