# RepoDb

A hybrid ORM library for .NET. It is an ORM that bridge the gaps between micro-ORMs and macro-ORMs. It helps the developer to simplify the switch-over of when to use the “basic” and “advance” operations during the development. 

## Supported Databases

Practically, RepoDb has supported all RDBMS data-providers. Developers has the freedom to write their own SQL statements and execute it against the database through the *Execute()* methods mentioned below.

- [ExecuteQuery](https://repodb.readthedocs.io/en/latest/pages/connection.html#executequery)
- [ExecuteNonQuery](https://repodb.readthedocs.io/en/latest/pages/connection.html#executenonquery)
- [ExecuteScalar](https://repodb.readthedocs.io/en/latest/pages/connection.html#executescalar)
- [ExecuteReader](https://repodb.readthedocs.io/en/latest/pages/connection.html#executereader)
- [ExecuteQueryMultiple](https://repodb.readthedocs.io/en/latest/pages/connection.html#executequerymultiple)

### Fully supported databases for fluent-methods

<img src="https://github.com/mikependon/RepoDb/blob/master/RepoDb.Raw/Images/SqlServer.png?raw=true" height="64px" title="SqlServer" /> <img src="https://raw.githubusercontent.com/mikependon/RepoDb/master/RepoDb.Raw/Images/SqLite.png" height="64px" title="SqLite" /> <img src="https://raw.githubusercontent.com/mikependon/RepoDb/master/RepoDb.Raw/Images/MySql.png" height="64px" title="MySql" /> <img src="https://raw.githubusercontent.com/mikependon/RepoDb/master/RepoDb.Raw/Images/PostgreSql.png" height="64px" title="PostgreSql" />

RepoDb has “fluent” methods in which the SQL Statements are automatically being constructed as part of the execution context. These methods are the most common operations being used by most developers (*please see the [operations](https://github.com/mikependon/RepoDb#operations) section*). In this regards, RepoDb only fully supported the *SQL Server*, *SQLite*, *MySQL* and *PostgreSQL* RDBMS data providers.

## Libraries

- SQL Server

	- [RepoDb.SqlServer](https://www.nuget.org/packages/RepoDb.SqlServer)
	- [RepoDb.SqlServer.BulkOperations](https://www.nuget.org/packages/RepoDb.SqlServer.BulkOperations)

- MySql

	- [RepoDb.MySql](https://www.nuget.org/packages/RepoDb.MySql)

- PostgreSql

	- [RepoDb.PostgreSql](https://www.nuget.org/packages/RepoDb.PostgreSql)

- SqLite

	- [RepoDb.SqLite](https://www.nuget.org/packages/RepoDb.SqLite)

## Setup

- SQL Server

	First, install the [RepoDb.SqlServer](https://www.nuget.org/packages/RepoDb.SqlServer) package.

	```csharp
	> Install-Package RepoDb.SqlServer
	```

	Then, call the bootstrapper once.

	```csharp
	SqlServerBootstrap.Initialize();
	```

- MySql

	First, install the [RepoDb.MySql](https://www.nuget.org/packages/RepoDb.MySql) package.

	```csharp
	> Install-Package RepoDb.MySql
	```

	Then, call the bootstrapper once.

	```csharp
	MySqlBootstrap.Initialize();
	```

- PostgreSql

	First, install the [RepoDb.PostgreSql](https://www.nuget.org/packages/RepoDb.PostgreSql) package.

	```csharp
	> Install-Package RepoDb.PostgreSql
	```

	Then, call the bootstrapper once.

	```csharp
	PostgreSqlBootstrap.Initialize();
	```

- SqLite

	First, install the [RepoDb.SqLite](https://www.nuget.org/packages/RepoDb.SqLite) package.

	```csharp
	> Install-Package RepoDb.SqLite
	```

	Then, call the bootstrapper once.

	```csharp
	SqLiteBootstrap.Initialize();
	```

## Documentation and Tutorials 

The library official documentation can be found at [ReadTheDocs](https://repodb.readthedocs.io/en/latest/).

For the practical implementations and some other references, please refer to our [Wiki](https://github.com/mikependon/RepoDb/wiki) page.

## Bug Reporting

Submit an issue into [RepoDb > Issues](https://github.com/mikependon/RepoDb/issues) tab at GitHub.

We have some guidelines when filing an issue, pleasse see our [Reporting an Issue](https://github.com/mikependon/RepoDb/tree/master/RepoDb.Docs/Reporting%20an%20Issue.md) page.

Otherwise, we also entertain via:

- [StackOverflow](https://stackoverflow.com/questions/tagged/repodb) - for any technical questions.
- [Twitter](https://twitter.com/search?q=%23repodb) - for the latest news.
- [Gitter Chat](https://gitter.im/RepoDb/community) - for direct and live Q&A.

## Licensing

RepoDb is licensed under [Apache-2.0](http://apache.org/licenses/LICENSE-2.0.html).
