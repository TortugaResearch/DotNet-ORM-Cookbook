# Single Model CRUD

This scenario covers the basic Create-Read-Update-Delete operations on a model that represents a single row in the database.

## Scenario Prototype

@snippet cs [..\Recipes\SingleModelCrud\ISingleModelCrudScenario`1.cs] ISingleModelCrudScenario{TEmployeeClassification}


## ADO.NET

With ADO.NET, the model does not actually participate in database operations so it needs no adornment.

@snippet cs [../Recipes.Ado/Models/EmployeeClassification.cs] EmployeeClassification

The repository methods use raw SQL strings. All other ORMs internally generate the same code. 

### SQL Server

To return a primary key from an `INSERT` statement, use `OUTPUT Inserted.EmployeeClassificationKey`.

@snippet cs [../Recipes.Ado/SingleModelCrud/SingleModelCrudScenario.cs] SingleModelCrudScenario

### PostgreSQL

To return a primary key from an `INSERT` statement, use `RETURNING EmployeeClassificationKey`.

@snippet cs [../Recipes.Ado/SingleModelCrud/SingleModelCrudPostgreSqlScenario.cs] SingleModelCrudPostgreSqlScenario

## Chain

Strictly speaking, Chain can use the same models as ADO.NET and Dapper so long as the column and property names match. However, it is more convenient to tag the class with what table it refers to.

@snippet cs [../Recipes.Tortuga.Chain\Models\EmployeeClassification.cs] EmployeeClassification

Without the Table attribute, the table name will have to be specified in every call in the repository.

Other information such as primary keys are read from the database's metadata.

@snippet cs [..\Recipes.Tortuga.Chain\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## Dapper

Dapper is essentially just ADO.NET with some helper methods to reduce the amount of boilerplate code.

@snippet cs [../Recipes.Dapper/SingleModelCrud/SingleModelCrudScenario.cs] SingleModelCrudScenario

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.
@end

### Dapper.Contrib

The Dapper.Contrib library can elimiante the boilerplate for some common scenarios. 

To enable it, models need to be decorated with `Table` and `Key` attributes. 

@snippet cs [../Recipes.Dapper\Models\EmployeeClassification.cs] EmployeeClassification

@snippet cs [../Recipes.Dapper/SingleModelCrud/SingleModelCrudScenarioContrib.cs] SingleModelCrudScenarioContrib

## Entity Framework 6

@snippet cs [..\Recipes.EntityFramework\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.
@end

### Entity Framework 6 - Improved

The design of Entity Framework 6 requires extraneous database calls when performing an update or delete operation. This revised version eliminates the extra calls.

@snippet cs [..\Recipes.EntityFramework\SingleModelCrud\SingleModelCrudScenario2.cs] SingleModelCrudScenario2

## Entity Framework Core

To use Entity Framework, one needs to create a DbContext class. Here is a minimal example:

```csharp
public partial class OrmCookbook : DbContext
{
    public OrmCookbook()
        : base("name=OrmCookbook")
    {
    }

    public virtual DbSet<EmployeeClassification> EmployeeClassifications { get; set; }

}
```

Depending on how you setup the DbContext, the model requires some further annotations such as which table it applies to and what the primary key is.

```csharp
[Table("HR.EmployeeClassification")]
public partial class EmployeeClassification
{
    [Key]
    public int EmployeeClassificationKey { get; set; }

    [StringLength(30)]
    public string EmployeeClassificationName { get; set; }
}
```

The context and model can be generated for you from the database using Entity Framework’s “Code First” tooling. (The name “code first” doesn’t literally mean the code has to be written before the database. Rather, it really means that you are not using EDMX style XML files.) For more information see https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx

Finally, there is the repository itself:

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.
@end

### Entity Framework Core - Improved

The design of Entity Framework Core requires extraneous database calls when performing an update or delete operation. This revised version eliminates the extra calls.

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudScenario2.cs] SingleModelCrudScenario2

## LINQ to DB

@snippet cs [..\Recipes.LinqToDB\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## LLBLGen Pro

LLBLGen Pro offers multiple ways to perform CRUD operations: via entity instances or directly on the data in the database, to avoid a fetch of entities first. The code below illustrates this and multiple query systems. Entity types are derived from a common base class.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## NHibernate

@snippet cs [../Recipes.NHibernate/Entities/EmployeeClassification.cs] EmployeeClassification

Instead of attributes, a mapping file is used to associate the model with a database table. There is one file per table and each is set to `Build Action: Embedded resource`. 

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeClassification.hbm.xml] .

A `SessionFactory` is needed to stitch the various configuration files together. 

@snippet cs [..\Recipes.NHibernate\Setup.cs] ConfigureSessionFactory

Finally there is the repository itself.

@snippet cs [..\Recipes.NHibernate\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

The rules on when you need to call `Flush` are complex. In some cases it will be called for you implicitly, but as a general rule you need to invoke it before leaving a block that includes modifications.

## RepoDb

When calling the *raw-SQL* operations, just like *Dapper*, RepoDB requires annotations on the classes. These are specific to RepoDb, you cannot use the standard `Table`, `Column`, and `Key` attributes from .NET.

@snippet cs [../Recipes.RepoDb\Models\EmployeeClassification.cs] EmployeeClassification

The repository resembles Dapper, but with far less SQL.

@snippet cs [..\Recipes.RepoDb\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## ServiceStack

ServiceStack requires the use of annotations on its models. These are specific to ServiceStack, you cannot use the standard `Table`, `Column`, and `Key` attributes from .NET.

@snippet cs [../Recipes.ServiceStack\Entities\EmployeeClassification.cs] EmployeeClassification

The repository resemebles Dapper, but with far less SQL.

@snippet cs [..\Recipes.ServiceStack\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

