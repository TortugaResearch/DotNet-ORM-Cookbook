# Single Model CRUD

This use case covers the basic Create-Read-Update-Delete operations on a model that represents a single row in the database.

## Prototype Repository

@snippet cs [..\Recipes.Core\SingleModelCrud\ISingleModelCrudRepository`1.cs] ISingleModelCrudRepository{TEmployeeClassification}


## ADO.NET

With ADO.NET, the model does not actually participate in database operations so it needs no adornment.

@snippet cs [../Recipes.Ado/SingleModelCrud/EmployeeClassification.cs] EmployeeClassification

The repository methods use raw SQL strings. All other ORMs internally generate the same code. 

@snippet cs [../Recipes.Ado/SingleModelCrud/SingleModelCrudRepository.cs] SingleModelCrudRepository

## Chain

Strictly speaking, Chain can use the same models as ADO.NET and Dapper so long as the column and property names match. However, it is more convenient to tag the class with what table it refers to.

@snippet cs [../Recipes.Tortuga.Chain\SingleModelCrud\EmployeeClassification.cs] EmployeeClassification

Without the Table attribute, the table name will have to be specified in every call in the repository.

Other information such as primary keys are read from the database's metadata.

@snippet cs [..\Recipes.Tortuga.Chain\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository

## Dapper

Dapper is essentially just ADO.NET with some helper methods to reduce the amount of boilerplate code.

@snippet cs [../Recipes.Dapper/SingleModelCrud/SingleModelCrudRepository.cs] SingleModelCrudRepository

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

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository

@alert info
The repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.
@end

### Entity Framework Core - Improved

The design of Entity Framework Core requires extraneous database calls when performing an update or delete operation. This revised version eliminates the extra calls.

@snippet cs [..\Recipes.EntityFrameworkCore\SingleModelCrud\SingleModelCrudRepository2.cs] SingleModelCrudRepository2

## NHibernate

NHibernate is one of the oldest ORMs for the .NET Framework. Based on Java’s Hibernate, it heavily relies on XML configuration files and interfaces.

The models are interesting in that every property needs to be virtual. Without this, you’ll get a runtime error.

@snippet cs [../Recipes.NHibernate/Entities/EmployeeClassification.cs] EmployeeClassification

Instead of attributes, a mapping file is used to associate the model with a database table. There is one file per table and each is set to `Build Action: Embedded resource`. 

@snippet xml [..\Recipes.NHibernate\Mappings\EmployeeClassification.hbm.xml] .

A `SessionFactory` is needed to stitch the various configuration files together. 

@snippet cs [..\Recipes.NHibernate\Setup.cs] ConfigureSessionFactory

Finally there is the repository itself.

@snippet cs [..\Recipes.NHibernate\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository

The rules on when you need to call `Flush` are complex. In some cases it will be called for you implicitly, but as a general rule you need to invoke it before leaving a block that includes modifications.

## RepoDb

RepoDb often requires the use of annotations on its models. These are specific to RepoDb, you cannot use the standard `Table`, `Column`, and `Key` attributes from .NET.

@snippet cs [../Recipes.RepoDb\SingleModelCrud\EmployeeClassification.cs] EmployeeClassification

The repository resemebles Dapper, but with far less SQL.

@snippet cs [..\Recipes.RepoDb\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository

## ServiceStack

ServiceStack requires the use of annotations on its models. These are specific to ServiceStack, you cannot use the standard `Table`, `Column`, and `Key` attributes from .NET.

@snippet cs [../Recipes.ServiceStack\Entities\EmployeeClassification.cs] EmployeeClassification

The repository resemebles Dapper, but with far less SQL.

@snippet cs [..\Recipes.ServiceStack\SingleModelCrud\SingleModelCrudRepository.cs] SingleModelCrudRepository









