# Single Model CRUD

This scenario covers the basic Create-Read-Update-Delete operations on a model that represents a single row in the database.

## Scenario Prototype

@snippet cs [..\Recipes\SingleModelCrud\ISingleModelCrudScenario`1.cs] ISingleModelCrudScenario{TEmployeeClassification}


## ADO.NET

With ADO.NET, the model does not actually participate in database operations so it needs no adornment.

@snippet cs [../Recipes.Ado/Models/EmployeeClassification.cs] EmployeeClassification

The repository methods use raw SQL strings. All other ORMs internally generate the same code. 

@snippet cs [../Recipes.Ado/SingleModelCrud/SingleModelCrudScenario.cs] SingleModelCrudScenario

## Chain

Strictly speaking, Chain can use the same models as ADO.NET and Dapper so long as the column and property names match. However, it is more convenient to tag the class with what table it refers to.

@snippet cs [../Recipes.Tortuga.Chain\Models\EmployeeClassification.cs] EmployeeClassification

Without the Table attribute, the table name will have to be specified in every call in the repository.

Other information such as primary keys are read from the database's metadata.

@snippet cs [..\Recipes.Tortuga.Chain\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## Dapper

Dapper is essentially just ADO.NET with some helper methods to reduce the amount of boilerplate code.

@snippet cs [../Recipes.Dapper/SingleModelCrud/SingleModelCrudScenario.cs] SingleModelCrudScenario

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
LLBLGen Pro is a .NET ORM on the market since 2003 and has seen over 15 major releases since that date. The latest version is v5.6.1, released in October 2019. LLBLGen Pro is a commercial non-poco full ORM which also offers a full plain-SQL API so can be used as a micro ORM as well. 

As all entities derive from a base class, the class models and mappings have to be generated from an abstract entity model which is created in the LLBLGen Pro designer using either model first or database first development (or a mix of both). LLBLGen Pro supports two paradigms: Adapter and SelfServicing. The cookbook looks at Adapter. 

It offers multiple query systems (Linq, QuerySpec (a fluent API) and a low-level API). The recipes illustrate usage of all of these.

@snippet cs [..\Recipes.LLBLGenPro\Recipes\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## NHibernate

NHibernate is one of the oldest ORMs for the .NET Framework. Based on Java’s Hibernate, it heavily relies on XML configuration files and interfaces.

The models are interesting in that every property needs to be virtual. Without this, you’ll get a runtime error.

@snippet cs [../Recipes.NHibernate/Entities/EmployeeClassification.cs] EmployeeClassification

Instead of attributes, a mapping file is used to associate the model with a database table. There is one file per table and each is set to `Build Action: Embedded resource`. 

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeClassification.hbm.xml] .

A `SessionFactory` is needed to stitch the various configuration files together. 

@snippet cs [..\Recipes.NHibernate\Setup.cs] ConfigureSessionFactory

Finally there is the repository itself.

@snippet cs [..\Recipes.NHibernate\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

The rules on when you need to call `Flush` are complex. In some cases it will be called for you implicitly, but as a general rule you need to invoke it before leaving a block that includes modifications.

## RepoDb

RepoDb is a hybrid-ORM that supports both *raw-SQLs* and *fluent* calls. When calling the *raw-SQL* operations, just like *Dapper* it does need annotations.

However, by using a *fluent* calls in the repositories (as recommended), it often requires the use of annotations on its models. These are specific to RepoDb, you cannot use the standard `Table`, `Column`, and `Key` attributes from .NET.

@snippet cs [../Recipes.RepoDb\Models\EmployeeClassification.cs] EmployeeClassification

The repository resembles Dapper, but with far less SQL.

@snippet cs [..\Recipes.RepoDb\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

## ServiceStack

ServiceStack requires the use of annotations on its models. These are specific to ServiceStack, you cannot use the standard `Table`, `Column`, and `Key` attributes from .NET.

@snippet cs [../Recipes.ServiceStack\Entities\EmployeeClassification.cs] EmployeeClassification

The repository resemebles Dapper, but with far less SQL.

@snippet cs [..\Recipes.ServiceStack\SingleModelCrud\SingleModelCrudScenario.cs] SingleModelCrudScenario

