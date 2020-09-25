# [RepoDB](http://repodb.net) - A hybrid ORM library for .NET.

It is an open-source .NET ORM library that bridges the gaps of micro-ORMs and full-ORMs. It helps you simplify the switch-over of when to use the BASIC and ADVANCE operations during the development.

You can use the library to work with [SQL Server](https://www.nuget.org/packages/RepoDb.SqlServer), [SQLite](https://www.nuget.org/packages/RepoDb.SqLite), [MySQL](https://www.nuget.org/packages/RepoDb.MySql) and [PostgreSQL](https://www.nuget.org/packages/RepoDb.PostgreSql) Relational Database Management Systems (RDBMS).

## Supported Databases

The execute methods below supports all RDBMS data providers.

- [ExecuteQuery](http://repodb.net/operation/executequery)
- [ExecuteNonQuery](http://repodb.net/operation/executenonquery)
- [ExecuteScalar](http://repodb.net/operation/executescalar)
- [ExecuteReader](http://repodb.net/operation/executereader)
- [ExecuteQueryMultiple](http://repodb.net/operation/executequerymultiple)

Whereas the fluent methods below only supports the [SQL Server](https://www.nuget.org/packages/RepoDb.SqlServer), [SQLite](https://www.nuget.org/packages/RepoDb.SqLite), [MySQL](https://www.nuget.org/packages/RepoDb.MySql) and [PostgreSQL](https://www.nuget.org/packages/RepoDb.PostgreSql) RDBMS data providers.

- [Query](http://repodb.net/operation/query)
- [Insert](http://repodb.net/operation/insert)
- [Merge](http://repodb.net/operation/merge)
- [Delete](http://repodb.net/operation/delete)
- [Update](http://repodb.net/operation/update)
 
Click [here](http://repodb.net/docs#operations) to see all the operations.

## Libraries

- [RepoDb.Core](https://www.nuget.org/packages/RepoDb)
- [RepoDb.SqlServer](https://www.nuget.org/packages/RepoDb.SqlServer)
- [RepoDb.SqlServer.BulkOperations](https://www.nuget.org/packages/RepoDb.SqlServer.BulkOperations)
- [RepoDb.MySql](https://www.nuget.org/packages/RepoDb.MySql)
- [RepoDb.MySqlConnector](https://www.nuget.org/packages/RepoDb.MySqlConnector)
- [RepoDb.PostgreSql](https://www.nuget.org/packages/RepoDb.PostgreSql)
- [RepoDb.SqLite](https://www.nuget.org/packages/RepoDb.SqLite)

## Setup

Please click any of the link below to let you get started with this library.

- [SqlServer](http://repodb.net/tutorial/get-started-sqlserver)
- [SqLite](http://repodb.net/tutorial/get-started-sqlite)
- [MySql](http://repodb.net/tutorial/get-started-mysql)
- [PostgreSql](http://repodb.net/tutorial/get-started-postgresql)

## Documentation and Tutorials 

Please visit our official documentation [here](http://repodb.net/docs).

## Bug Reporting

Submit an issue into [RepoDB > Issues](https://github.com/mikependon/RepoDb/issues) tab at GitHub.

We have some guidelines when filing an issue, please see our [Reporting an Issue](https://github.com/mikependon/RepoDB/blob/master/RepoDb.Docs/reporting-an-issue.md) page.

Otherwise, we also entertain via:

- [StackOverflow](https://stackoverflow.com/search?tab=newest&q=RepoDB) - for any technical questions.
- [Twitter](https://twitter.com/search?q=%23repodb) - for the latest news.
- [Gitter Chat](https://gitter.im/RepoDb/community) - for direct and live Q&A.

## Licensing

RepoDB is licensed under [Apache-2.0](http://apache.org/licenses/LICENSE-2.0.html).
