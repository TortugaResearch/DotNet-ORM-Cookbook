# Tortuga Chain

Tortuga Chain is based around the concept of database-reflection. Rather than using mapping files, it interrogates the database for its schema. Then it generates the SQL based the intersection between the tables and classes.

## Supported Databases

Full support is offered for:

* SQL Server
* MySQL
* PostgreSQL
* SQLite
* Microsoft Access (.NET Framework Only

Chain also supports any database that offers an ADO.NET provider, but without the database reflection and SQL generation capabilities.

ADO.NET requires the writing of SQL, which is often database specific.

## Libraries

Full Database Reflection Support

* SQL Server:
  * Using System.Data.SqlClient [Tortuga.Chain.SqlServer](https://www.nuget.org/packages/Tortuga.Chain.SqlServer)
  * Using Microsoft.Data.SqlClient [Tortuga.Chain.SqlServer.MDS](https://www.nuget.org/packages/Tortuga.Chain.SqlServer.MDS)
  * Using OleDB  [Tortuga.Chain.SqlServer.OleDb](https://www.nuget.org/packages/Tortuga.Chain.SqlServer.OleDb)
* SQLite: [Tortuga.Chain.SQLite](https://www.nuget.org/packages/Tortuga.Chain.SQLite)
* PostgreSql: [Tortuga.Chain.PostgreSql](https://www.nuget.org/packages/Tortuga.Chain.PostgreSql)
* Access: [Tortuga.Chain.Access](https://www.nuget.org/packages/Tortuga.Chain.Access)
* MySql: [Tortuga.Chain.MySql](https://www.nuget.org/packages/Tortuga.Chain.MySql)

Result-set Mapping Only

* Odbc: [Tortuga.Chain.Odbc](https://www.nuget.org/packages/Tortuga.Chain.Odbc)
* OleDb: [Tortuga.Chain.OleDb](https://www.nuget.org/packages/Tortuga.Chain.OleDb)
* Other: [Tortuga.Chain.Core](https://www.nuget.org/packages/Tortuga.Chain.Core)


## Setup

Chain internally handles connections using a thread-safe `DataSource` object. Normally only one `DataSource` is created per connection string so that database schema can be cached.

    PrimaryDataSource = new SqlServerDataSource(connectionString);

## Documentation and Tutorials 

* [Quick Start](https://docevaad.github.io/Chain/Introduction.htm)
* [Primary Documentation](https://docevaad.github.io/Chain/)

## Bug Reporting

Issues should be logged in the [docevaad/Chain repository](https://github.com/docevaad/Chain/issues).

## Licensing

Tortuga Chain is offered under the [MIT License](https://github.com/docevaad/Chain/blob/master/License.txt).
