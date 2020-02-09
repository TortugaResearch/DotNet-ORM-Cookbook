# Dapper

Dapper describes itself as "a simple object mapper for .Net". It is one of the earilest "Micro-ORMs" and in keeping with that style, it is exposed as a set of extension methods over ADO.NET's `IDbConnection`.

Dapper's primary purpose is to handle mapping objects to database parameters and result sets to objects. It does not provide SQL generation.

## Supported Databases

Dapper supports any database that offers an ADO.NET provider.

ADO.NET requires the writing of SQL, which is often database specific.

@alert warning
Unless otherwise indicated, all examples of SQL are for SQL Server.
@end

## Libraries

* [ADO.NET](ADO.htm#libraries) Database Specific Provider 
* [Dapper](https://www.nuget.org/packages/Dapper)

## Setup

Dapper uess the same setup as [ADO.NET](ADO.htm#setup). No additional setup is required.

## Documentation and Tutorials 

* [Quick Start](https://github.com/StackExchange/Dapper)

## Bug Reporting

Issues should be logged in the [StackExchange/Dapper repository](https://github.com/StackExchange/Dapper/issues).

## Licensing

Dapper is offered under the [Apache License version 2](http://www.apache.org/licenses/LICENSE-2.0).
