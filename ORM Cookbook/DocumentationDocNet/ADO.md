# ADO.NET

ADO.NET, also known as `System.Data`, is the foundational library for database access in .NET. This is done via a set of interfaces and abstract classes, allowing for a consistent experience.

Of these, the most important are [`IDbConnection`](https://docs.microsoft.com/en-us/dotnet/api/system.data.idbconnection), [`IDbCommand`](https://docs.microsoft.com/en-us/dotnet/api/system.data.idbcommand), and [`IDataReader`](https://docs.microsoft.com/en-us/dotnet/api/system.data.idatareader).

## Supported Databases

All databases that offer OleDB or ODBC connectivity are automatically supported. 

Most databases also implement their own ADO.NET provider.  that implements the ADO.NET interfaces and abstract classes. This allows greater access to the specific database's capabilities than using the generic OleDB or ODBC drivers.

ADO.NET requires the writing of SQL, which is often database specific.

@alert warning
Unless otherwise indicated, all examples of SQL are for SQL Server.
@end

## Libraries

ADO.NET is incorporated into .NET Framework. This includes the SQL Server, OleDB, and ODBC libraries.

For .NET Core, you'll need the [System.Data.Common](https://www.nuget.org/packages/System.Data.Common) package.

* Db2 [IBM.Data.DB2.Core](https://www.nuget.org/packages/IBM.Data.DB2.Core)
* Firebird: [FirebirdSql.Data.FirebirdClient](https://www.nuget.org/packages/FirebirdSql.Data.FirebirdClient)
* MySQL: [MySqlConnector](https://www.nuget.org/packages/MySqlConnector)
* Oracle DB: [Devart.Data.Oracle](https://www.nuget.org/packages/Devart.Data.Oracle)
* PostgreSQL: [Npgsql](https://www.nuget.org/packages/Npgsql)
* Progress OpenEdge [](https://www.nuget.org/packages/)
* SQL Server: [Microsoft.Data.SqlClient](https://www.nuget.org/packages/Microsoft.Data.SqlClient) or [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient)
* SQLite: [System.Data.SQLite.Core](https://www.nuget.org/packages/System.Data.SQLite.Core)

## Setup

No special setup is needed for ADO.NET beyond just a connection string. 

@snippet cs [..\Recipes.Ado\SqlServerScenarioBase.cs] OpenConnection()

The exact class names vary by database.

@snippet cs [..\Recipes.Ado\PostgreSqlScenarioBase.cs] OpenConnection()

For information on creating connection strings, try [The Connection Strings Reference](https://www.connectionstrings.com/).

## Documentation and Tutorials 

* [Primary Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.data)

Individual ADO.NET providers may have their own documentation as well. 

## Bug Reporting

Most ADO.NET bugs should be reported to their respective provider maintainers. 

For ADO.NET itself, issues should be logged in the [dotnet/runtime repository](https://github.com/dotnet/runtime/labels/area-System.Data).

## Licensing

ADO.NET itself is offered under the [The MIT License](https://github.com/dotnet/runtime/blob/master/LICENSE.TXT).

Individual ADO.NET providers may be licensed differently.
