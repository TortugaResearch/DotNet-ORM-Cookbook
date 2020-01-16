# Frequently Asked Questions

## Can I add my favorite ORM?

Yes. If you are willing to abide by our basic conventions, you may add any .NET Core ORM you want to the project.

## What if my ORM doesn’t support SQL Server?

ORMs for other databases will be permitted once we create the associated database headers. This is currently in the planning phase.

## What do you mean by “scenario”?

In the context of this cookbook, a **scenario** is something that a developer wants to achieve in order to fulfill a business or design requirement. For example, the developer may be tasked with “create a function that returns an `EmployeeClassification` record or null if the record doesn’t exist”.

Generally speaking, the scenarios do not dictate *how* something is to be accomplished. Different ORMs are allowed to have different solutions so long as the test cases are passed.

## Why don’t you inject an open connection/DBContext/ISession?

> Connections to data sources are a fundamental part of the data layer. All data source connections should be managed by the data layer. Creating and managing connections uses valuable resources in both the data layer and the data source. To maximize performance and security, consider the following guidelines when designing for data layer connections:
>
> * In general, open connections as late as possible and close them as early as possible. Never hold connections open for excessive periods.

-- Microsoft Application Architecture Guide, 2nd Edition


## Why don’t you expose `IQueryable` in the repositories?

> **Encapsulate data access functionality within the data access layer.** The data access layer should hide the details of data source access. It should be responsible for managing connections, generating queries, and mapping application entities to data source structures. Consumers of the data access layer interact through abstract interfaces using application entities such as custom objects, TypedDataSets, and XML, and should have no knowledge of the internal details of the data access layer. Separating concerns in this way assists in application development and maintenance.

-- Microsoft Application Architecture Guide, 2nd Edition

Another reason is that not all databases expose an `IQueryable` interface. The intention is that scenarios are based around goals, not specific techniques/technologies.