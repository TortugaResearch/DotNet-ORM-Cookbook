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

## DbConnector

DbConnector requires audit columns to be manually merged into the object being inserted/updated. 

@snippet cs [..\Recipes.DbConnector\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

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

LLBLGen Pro has a built-in auditing system that works with separated Auditor classes which are provided by 
the developer and which are injected at runtime into the entity instances. These auditors act like recorders
of auditing information on various actions and can provide new entity instances (or existing ones) which are
then  persisted in the same transaction. 

The system is mainly designed to store auditing information separately from the audited entities, however it's
also usable in the scenario at hand here: setting auditing information in the entity being audited. The following
Auditor class is used for auditing on a DepartmentEntity instance:

@snippet cs [..\Recipes.LLBLGenPro\Injectables\DepartmentAuditor.cs] DepartmentAuditor

For every instance of a DepartmentEntity, an instance of this class is injected through the built-in Dependency Injection. This 
is setup in the AssemblyInit method of the Recipes code: 

```cs
RuntimeConfiguration.SetDependencyInjectionInfo(
	new List<Assembly>() { typeof(DepartmentAuditor).Assembly}, null);
```

Usually, user info is passed through e.g. a ThreadPrinciple however for simplicity the user PK is passed directly to 
the auditor instance of the entity in the scenario as is shown in the scenario code below:

@snippet cs [..\Recipes.LLBLGenPro\Recipes\AuditColumns\AuditColumnsScenario.cs] AuditColumnsScenario

For further information about the Auditing system in LLBLGen Pro: 
[Auditing in the official docs](https://www.llblgen.com/Documentation/5.6/LLBLGen%20Pro%20RTF/Using%20the%20generated%20code/gencode_auditing.htm)

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
