# XPO

**eXpress Persistent Objects (XPO)** is an Object-Relational Mapping (ORM) tool that handles all aspects of database creation and object persistence, allowing you to concentrate on your application's business logic rather than database complexities. It offers Code First, Model First and Database First development workflows.

XPO uses smart loading by default, so you have not worry about loading child or linked objects: they will be loaded once you access them.

## Supported Databases

Database specific providers are required. 

XPO supports:

* Advantage
* ASA
* ASE
* DB2
* Firebird
* Microsoft Access
* Microsoft Sql Server 
* Microsoft Sql Server Compact Edition
* MySQL
* Oracle DB
* Pervasive
* PostgreSQL
* SQLite 
* VistaDB

## Libraries

See [Database Providers](https://docs.devexpress.com/XPO/2114/fundamentals/database-systems-supported-by-xpo) for a current list of EF Core providers.

## Setup

XPO requires a connection string to create a data layer. This data layer is used by Sessions and Units of Work.  

In this recipes we use a default data layer and a default session to work with  data bases, but we recommend you to use individual UnitOfWork objects.

Each data object derives the XPObject (or XPLiteObject). This makes these objects fully persistent.

## Documentation and Tutorials 

* [Tutorials](https://github.com/DevExpress/XPO/tree/master/Tutorials)
* [Primary Documentation](https://docs.devexpress.com/XPO/1998/express-persistent-objects)
* [GitHub Code Examples](https://github.com/DevExpress-Examples?q=eXpress+Persistent+Objects) 
* [Technical Support Knowledge Base](https://www.devexpress.com/sc) 
* [XPO Team blog](https://community.devexpress.com/blogs/xpo/default.aspx)

## Bug Reporting

Issues should be logged in the [DevExpress Support Center](https://www.devexpress.com/sc).

## Licensing

If you do not require technical assistance from the DevExpress Support Team, you can use fully-functional eXpress Persistent Objects (XPO) Library in your applications **free of charge**. 

Support is included with several [paid subscriptions](https://www.devexpress.com/products/net/orm/#Pricing).

