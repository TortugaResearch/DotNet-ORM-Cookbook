# Audit Columns

These scenarios demonstrate how to ensure that audit columns are populated. 

For each operation, a `User` object will be supplied along with the object being created or updated.

## Scenario Prototype

@snippet cs [..\Recipes\AuditColumns\IAuditColumnsScenario`1.cs] IAuditColumnsScenario{TDepartment}

## ADO.NET

ADO requires that audit columns be manually supplied. This is usually done when the parameters are generated.

@snippet cs [..\Recipes.Ado\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

## Chain

Chain requires that the audit columns be configured at the `DataSource` level.

Then to supply the actual user data, use `dataSource.WithUser(user)`.

@snippet cs [..\Recipes.Tortuga.Chain\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

## Dapper

Dapper requires that audit columns be manually merged into the object being inserted/updated. 

@snippet cs [..\Recipes.Dapper\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

## Entity Framework 6

To generalize audit column management in Entity Framework, create an interface with the list of audit columns. Then overide the `SaveChanges` method to provide the audit values.

@snippet cs [..\Recipes.EntityFramework\Entities\IAuditableEntity.cs] IAuditableEntity

@snippet cs [..\Recipes.EntityFramework\Entities\OrmCookbookContextWithUser.cs] SaveChanges()

@snippet cs [..\Recipes.EntityFramework\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

@alert warning
This design pattern does not prevent someone from intentionally altering the CreatedBy/CreatedDate columns.
@end

## Entity Framework Core

To generalize audit column management in EF Core, create an interface with the list of audit columns. Then overide the `SaveChanges` method to provide the audit values.

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\IAuditableEntity.cs] IAuditableEntity

@snippet cs [..\Recipes.EntityFrameworkCore\Entities\OrmCookbookContextWithUser.cs] SaveChanges()

@snippet cs [..\Recipes.EntityFrameworkCore\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

@alert warning
This design pattern does not prevent someone from intentionally altering the CreatedBy/CreatedDate columns.
@end

## LINQ to DB

TODO

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
