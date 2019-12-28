# Use Case: Model with Single Child

In this use case, the Department model consits of a Deparment object with a single child object of type Division. For the purpose of this use case, the repository cannot create new Division records when saving the Department.

The model is defined with these two interfaces:

@snippet cs [../Recipes.Core/Models/IDepartment1.cs] IDepartment{TDivision}

@snippet cs [../Recipes.Core/Models/IDivision.cs] IDivision


## ADO.NET

Nothing interesting here, as the data is just manually mapped.

## Tortuga Chain

Chain heavily relies on the use of views. If you wish to populate a child object, then its fields should be represented in the view using a normal join.

In the model, the `Decompose` attribute is applied to a property to indicate that it should be populated from the parent's result set.

@snippet cs [../Recipes.Tortuga.Chain/Models/Department.cs] Department.Division

Decomposed properties do not participate in Insert/Update operations. To handle this, you need to "pull up" the FK using this syntax.

@snippet cs [../Recipes.Tortuga.Chain/Models/Department.cs] Department.DivisionKey

As mentioned above, you need to read from the view (called HR.DepartmentDetail in this case) in order to fetch the data needed to populate the child object. For inserts and updates, you will still refer to the underlying table.

@snippet cs [../Recipes.Tortuga.Chain/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.GetByKey

## Dapper

Like Chain, Dapper can decompose result sets into parent-child models. This is called "Multi Mapping". It requires a function to indicate how the parent and child are related, plus a parameter to indicate which column is the foreign Key.

@snippet cs [../Recipes.EntityFramework/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.GetAll

Unlike the other ORMs, Dapper has a hard limit of no more than 6 child objects. When using more than one child object, pass a comma separated list to the `splitOn` parameter.

## Entity Framework

The model used in Entity Framework expects the Division property to be vitual. If it isn't, then lazy loading will not be enabled.

@snippet cs [../Recipes.EntityFramework/Models/Department.cs] Department.Division

A limitation of EF is that for every child object you expose, you also need to expose the matching foreign Key.

@snippet cs [../Recipes.EntityFramework/Models/Department.cs] Department.DivisionKey

When you save the record, EF's context handling becomes a problem. You need to set the "Entry State" for the division object so that EF knows that it came from a different context. Otherwise EF will try to insert a new row for Division, which will result in a runtime error.

@snippet cs [../Recipes.EntityFramework/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.Create

When performing an update, you don't need to touch the Entry State. Instead you need to update the DivsionKey on the Department object to match the DivsionKey on the Division object. Since that is an implementation detail, we are doing it inside the repository itself.

@snippet cs [../Recipes.EntityFramework/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.Update

With reads, the `Include` clause is necessary. Without if one of two things will happen:

* If Division is virtual, lazy loading will be tiggered. Since the context will already be closed by the time that happens, an exception will be thrown.
* If Division is not virtual, the property will be null. This will most likely lead to a `NullReferenceException`, as logically this should always have a value.

@snippet cs [../Recipes.EntityFramework/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.GetAll
```

@snippet cs [../Recipes.EntityFramework/Repositories/DepartmentWithChildRepository.cs] DepartmentWithChildRepository.GetByKey
```

@alert important
The `Find` shortcut is not compatible with the `Include` clause, so you have to write the statement longform.
@end

