# LLBLGen Pro

LLBLGen Pro is a commercial, full ORM and entity modeling solution. Its first version was released in 2003. 
It comes with a visual designer and its own ORM framework, the LLBLGen Pro Runtime Framework. The designer supports, besides 
their own framework, Entity Framework/Entity Framework Core, Linq to Sql and NHibernate, and offers a rich set of features to 
use both model-first and database-first development (or a mix of both). Besides your entity model, you can also define multiple 
derived models on top of the entity model which can e.g. be used as DTOs

The runtime framework offers modern features like .NET Core (through .netstandard 2.0) support, multiple query systems like Linq and its own 
fluent API, disconnected Unit of work, batching, resultset caching, projections, eager loading and much more. It also offers a plain SQL API for
the occasions where you need to express your queries in SQL itself. Its performance is among the top of the field, often outperforming micro ORMs.

All licensees also have access to ORM Profiler, a multi-ORM profiler and query analyzer for .NET data-access code.

@alert info
The code in this repository uses interfaces on the entities. These are added in the designer as additional interfaces, where the code
generator merged them into the output. 
@end

## Supported Databases

LLBLGen Pro supports the following databases:

* SQL Server 2000 or higher / Express / CE Desktop / SQL Azure
* Oracle 9i or higher
* PostgreSQL v7.4 or higher
* IBM DB2 7.x or higher
* MySQL 4.x or higher (and compatible MariaDB variants)
* Google Cloud Spanner
* Firebird 1.5.x or higher
* MS Access 2000 or higher

Additionally it supports through its [Derived Model](https://www.llblgen.com/Documentation/5.6/Designer/Functionality%20Reference/AvailableDerivedModelFrameworks.htm#document-database) feature the following Document DBs:

* RavenDB
* MongoDB
* Microsoft Cosmos DB

## Libraries

LLBLGen Pro comes with everything you need in one installer. Additionally, you can pull the runtime framework's assemblies as packages
from NuGet:

- [https://www.nuget.org/packages/SD.LLBLGen.Pro.ORMSupportClasses/](https://www.nuget.org/packages/SD.LLBLGen.Pro.ORMSupportClasses/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.ORMSupportClasses.Web/](https://www.nuget.org/packages/SD.LLBLGen.Pro.ORMSupportClasses.Web/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.Access/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.Access/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.DB2/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.DB2/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.Firebird/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.Firebird/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.MySql/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.MySql/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.OracleMS/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.OracleMS/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.OracleODPNET/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.OracleODPNET/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.PostgreSql/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.PostgreSql/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.Spanner/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.Spanner/)
- [https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.SqlServer/](https://www.nuget.org/packages/SD.LLBLGen.Pro.DQE.SqlServer/)

## Setup

To get started, please see the [Quickstart videos](https://www.llblgen.com/Pages/Videos.aspx).

In text form:

- [LLBLGen Pro Runtime Framework](https://www.llblgen.com/Documentation/5.6/LLBLGen%20Pro%20RTF/getting_started.htm)
- [Entity Framework / Core](https://www.llblgen.com/Documentation/5.6/Entity%20Framework/Quickstartguides.htm)
- [Linq to SQL](https://www.llblgen.com/Documentation/5.6/Linq%20to%20Sql/Quickstartguides.htm)
- [NHibernate](https://www.llblgen.com/Documentation/5.6/NHibernate/Quickstartguides.htm)

## Documentation and Tutorials 

The complete LLBLGen Pro documentation is vast and has several different parts. They're all available on the 
[main documentation site](https://www.llblgen.com/Pages/documentation.aspx). Every install also comes with this 
documentation installed locally.

## Bug Reporting

Support is done via [the support forums](https://www.llblgen.com/tinyforum) where the support team and development team 
answer questions and pick up bug reports. Bug fixes are usually released within a day or two as hotfix builds for licensees.

## Licensing

LLBLGen Pro is a commercial system using a subscription model with a perpetual license, which means the license is valid forever: 
it won't expire if your subscription expires. Generated code and the runtime framework are royalty free and don't require a license to be used.
See [the website](https://www.llblgen.com/Pages/buy.aspx) for more details and the EULA.