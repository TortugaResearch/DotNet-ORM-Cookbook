# Discover Tables and Columns

These scenarios demonstrate how to list the tables and columns in an unknown database. 

## Scenario Prototype

@snippet cs [..\Recipes\DiscoverTablesAndColumns\IDiscoverTablesAndColumnsScenario.cs] IDiscoverTablesAndColumnsScenario

## ADO.NET

The SQL needed to list tables, views, and columns is database-specific. 

* DB2: [Catalog Tables](https://www.ibm.com/support/knowledgecenter/en/SSEPEK_11.0.0/cattab/src/tpc/db2z_catalogtablesintro.html)
* MySQL: [Information Schema](https://dev.mysql.com/doc/refman/5.7/en/information-schema.html)
* Oracle: [Information Schema](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/oracle-schema-collections)
* PostgreSQL: [Information Schema](https://www.postgresql.org/docs/9.1/information-schema.html)
* SQL Server: [System Views]() or [Information Schema](https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-schema-collections)

@alert warning
While most databases expose Information Schema (e.g. `INFORMATION_SCHEMA.TABLES`), the column names may vary from vendor to vendor.
@end

@snippet cs [..\Recipes.Ado\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## Chain

Chain exposes information about the database via the `DatabaseMetadata` property. If you don't use the `Preload` method, only tables and views previously seen will be available.

@snippet cs [..\Recipes.Tortuga.Chain\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## Dapper

The SQL needed to list tables, views, and columns is database-specific. See the ADO.NET example above for links to the documentation. 

@snippet cs [..\Recipes.Dapper\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## DbConnector

TODO

## Entity Framework 6

TODO

## Entity Framework Core

The SQL needed to list tables, views, and columns is database-specific. See the ADO.NET example above for links to the documentation.

@snippet cs [..\Recipes.EntityFrameworkCore\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\DiscoverTablesAndColumns\DiscoverTablesAndColumnsScenario.cs] DiscoverTablesAndColumnsScenario

## LLBLGen Pro 

TODO

## NHibernate

TODO

## RepoDb

TODO

## ServiceStack

TODO
