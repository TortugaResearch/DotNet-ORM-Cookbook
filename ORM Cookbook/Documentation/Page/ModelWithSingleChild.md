# Model with Single Child

In this use case, the Department model has a single child object of type Division. 

## ADO.NET

Nothing interesting here, as the data is just manually mapped.


## Tortuga Chain

Chain heavily relies on the use of views. If you wish to populate a child object, then its fields should be represented in the view using a normal join.

In the model, the `Decompose` attribute is applied to a property to indicate that it should be populated from the parent's result set.

```csharp [../Recipes.Tortuga.Chain/Models/Department.cs] Department.Division
```

Decomposed properties do not participate in Insert/Update operations. To handle this, you need to "pull up" the FK using this syntax.


```csharp [../Recipes.Tortuga.Chain/Models/Department.cs] Department.DivisionKey
```

As mentioned above, you need to read from the view (called HR.DepartmentDetail in this case) in order to fetch the data needed to populate the child object. For inserts and updates, you will still refer to the underlying table.

```csharp [../Recipes.Tortuga.Chain/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.GetByKey
```

