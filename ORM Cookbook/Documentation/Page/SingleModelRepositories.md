# Single Model Repositories

This section demonstrates CRUD operations on a single model mapped to a class. 

## Prototype Repository


This is the interface that every example repository will implement. 

```csharp
    public interface IEmployeeClassificationRepository
    {
        EmployeeClassification GetByKey(int employeeClassificationKey);

        EmployeeClassification FindByName(string employeeClassificationName);

        IList<EmployeeClassification> GetAll();

        int Create(EmployeeClassification classification);
        void Update(EmployeeClassification classification);
        void Delete(EmployeeClassification classification);
        void Delete(int employeeClassificationKey);
    }
```

The class EmployeeClassification is defined as such:
```csharp [../Recipes.Core/Models/IEmployeeClassification.cs] IEmployeeClassification
```


## ADO.NET

With ADO.NET, the model does not acutally participate in database operations so it needs no adornment.

```csharp [../Recipes.Ado/Models/EmployeeClassification.cs] EmployeeClassification
```

The repository methods use raw SQL strings. All other ORMs internally generate the same code. 

```csharp [../Recipes.Ado/Repositories/EmployeeClassificationRepository.cs] EmployeeClassificationRepository
```

## Dapper

Dapper is essentially just ADO.NET with some helper methods to reduce the amount of boilerplate code.

```csharp [../Recipes.Dapper/Repositories/EmployeeClassificationRepository.cs] EmployeeClassificationRepository
```

## Tortuga Chain

Strictly speaking, Chain can use the same models as ADO.NET and Dapper so long as the column and property names match. However, it is more convenient to tag the class with what table it refers to.

```csharp [../Recipes.Tortuga.Chain/Models/EmployeeClassification.cs] EmployeeClassification
```
Without the Table attribute, the table name will have to be specified in every call in the repository.


```csharp [../Recipes.Tortuga.Chain/Repositories/EmployeeClassificationRepository.cs] EmployeeClassificationRepository
```


## Entity Framework

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

The model requires some annotations so that Entity Framework knows what table it applies to and what the primary key is.

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

The context and model can be generated for you from the database using Entity Framework’s “Code First” tooling. (The name “code first” doesn’t literally mean the code has to be written before the database. Rather, it really means that you are not using EDMX style XML files.)

Finally, there is the repository itself:

```csharp [../Recipes.EntityFramework/Repositories/EmployeeClassificationRepository.cs] EmployeeClassificationRepository
```
*Note that the repository methods are not normally virtual. This was done so that they could be overridden with better implementations as shown below.*

### Entity Framework Intermediate

The data access patterns in Entity Framework can be quite inefficient, so to reduce unnecessary database calls you can modify the code as shown below.

```csharp [../Recipes.EntityFramework/Repositories/EmployeeClassificationRepository_Intermediate.cs] EmployeeClassificationRepository_Intermediate
```

### NHibernate

NHibernate is one of the oldest ORMs for the .NET Framework. Based on Java’s Hibernate, it heavily relies on XML configuration files and interfaces.

The models are interesting in that every property needs to be virtual. Without this, you’ll get a runtime error.

```csharp [../Recipes.NHibernate/Models/EmployeeClassification.cs] EmployeeClassification
```

Instead of attributes, a mapping file is used to associate the model with a database table.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
                   assembly="Recipes.NHibernate"
                   namespace="Recipes.NHibernate.Models">

  <class name="EmployeeClassification" table="EmployeeClassification" schema="HR">

    <id name="EmployeeClassificationKey" >
      <generator class="native"/>
    </id>
    <property name="EmployeeClassificationName" />
  </class>

</hibernate-mapping>
```

The NHibernate documentation recommends create a session factory helper using this pattern:

```csharp [../Recipes.NHibernate/Repositories/EmployeeClassificationRepository.cs] EmployeeClassificationRepository
```

Finally there is the repository itself.

```csharp [../Recipes.NHibernate/Repositories/EmployeeClassificationRepository.cs] EmployeeClassificationRepository
```

The rules on when you need to call `Flush` are complex. In some cases it will be called for you implicitly, but as a general rule you need to invoke it before leaving a block that includes modifications.


