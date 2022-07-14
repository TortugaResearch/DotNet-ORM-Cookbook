## July 2022

### Shared Changes

Added indexes in order to reduce test run times. Thank you [Query Store](https://docs.microsoft.com/en-us/sql/relational-databases/performance/monitoring-performance-by-using-the-query-store) for showing which queries were causing the problem. Total run time dropped from around 7 minutes to less than 2.

ORMs that use `Microsoft.Data.SqlClient` need to add `TrustServerCertificate=True` to their connection string. Alternately, a trusted SSL Certificate can be installed in the database. For more information see [SqlConnectionStringBuilder.TrustServerCertificate](https://docs.microsoft.com/en-us/dotnet/api/microsoft.data.sqlclient.sqlconnectionstringbuilder.trustservercertificate?view=sqlclient-dotnet-standard-4.1).

Updated dependencies. If an ORM itself is updated, the new version number will be noted below.

### ADO

No changes other than dependencies.

### Dapper

No changes other than dependencies.

### DbConnector

No changes other than dependencies.

### Entity Framework

No changes other than dependencies.

### Entity Framework Core

* Update `Microsoft.EntityFrameworkCore.*` to version 6.0.6
* Update `Npgsql.EntityFrameworkCore.PostgreSQL` to version 6.0.5

### LinqToDB

* Update `linq2db` to version 4.1.0.
* Breaking change to API (see below).
* Replace `System.Data.SqlClient` with `Microsoft.Data.SqlClient`. Failing to do so is a runtime error.

This syntax is no longer allowed.

```csharp
public class OrmCookbook : DataConnection
{
	public ITable<Department> Department => GetTable<Department>();
```

Due to an API change, we now have to write,

```csharp
public class OrmCookbook : DataConnection
{
	public ITable<Department> Department => this.GetTable<Department>();
```

It appears that a method has been replaced by an extension method.

### LLBLGen Pro

* Update `SD.LLBLGen.Pro.*` to version 5.9.1.
* Reran code generator.

### NHibernate

* Update `NHibernate` to version 5.3.12

### RepoDB

* Update `RepoDb` to version 1.12.10
* Update `RepoDb.SqlServer` to version 1.1.5
* Update `RepoDb.SqlServer.BulkOperations` to version 1.1.6

The `SortByNonExistentColum` test is failing. See bug report https://github.com/mikependon/RepoDB/issues/1049

### ServiceStack

* Update `ServiceStack.OrmLite` to version 6.1.0
* Update `ServiceStack.OrmLite.SqlServer` to version 6.1.0

### Tortuga Chain

* Update `Tortuga.Chain.*` to version 4.3.0
* Replace obsolete `TableAndView` attribute with separate `Table` and `View` attributes.
* The `IClass1DataSource` interface no longer exists. Use feature interfaces such as `ICrudDataSource` instead. 
* The `DeleteWithFilter` method is now called `DeleteSet`.
* The `GetByKeyList` method is replaced by `GetByColumnList` when searching by a non-key column.

