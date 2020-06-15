# DbConnector

DbConnector is a performance-driven and ADO.NET data provider-agnostic ORM library for .NET developed for individuals who strive to deliver high-quality software solutions. Object-Relational Mapping (ORM) is a technique that lets you query and manipulate data from a database using an object-oriented paradigm. This highly efficient library helps with the task of projecting/mapping data from any database, with the support of any third party data provider, into .NET objects and is comparable to the use of raw ADO.NET data reader implementations. 

## Supported Databases

DbConnector supports any database that offers an ADO.NET provider.

ADO.NET requires the writing of SQL, which is often database specific.

@alert warning
Unless otherwise indicated, all examples of SQL are for SQL Server.
@end

## Libraries

* [ADO.NET](ADO.htm#libraries) Database Specific Provider 
* [DbConnector](https://www.nuget.org/packages/SavantBuffer.DbConnector)

## Setup

Once you've downloaded and/or included the package into your .NET project, you have to reference the DbConnector and your preferred ADO.NET data provider namespaces in your code:
    
    using DbConnector.Core;
    using System.Data.SqlClient; //Using SqlClient in this example.

Now, we can create an instance of the DbConnector using the targeted DbConnection type: 

    //Note: You can use any type of data provider adapter that implements a DbConnection.
    //E.g. PostgreSQL, Oracle, MySql, SQL Server

    //Example using SQL Server connection
    DbConnector<SqlConnection> _dbConnector = new DbConnector<SqlConnection>("connection string goes here");

@alert warning
This is a setup example for the C# language.
@end

## Documentation and Tutorials 

* [Quick Start](https://github.com/SavantBuffer/DbConnector)

## Bug Reporting

Issues should be logged in the [SavantBuffer/DbConnector repository](https://github.com/SavantBuffer/DbConnector/issues).

## Licensing

DbConnector is offered under the [Apache License version 2](http://www.apache.org/licenses/LICENSE-2.0).