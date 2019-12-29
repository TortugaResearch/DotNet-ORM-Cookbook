# Use Case: Asynchronous Repositories

This use case demonstrates the use of asynchronous CRUD operations. Asynchronous database calls are generally preferable, as they allow for more throughput in server applications and prevent UI blocking in GUI applications.

## Prototype Repository

The prototype repository based on our “Single Model Repositories” use case, with a slight modification to the signatures. 

```csharp
public interface IEmployeeClassificationAsynchronousRepository
{
	Task<EmployeeClassification> GetByKeyAsync(int employeeClassificationKey);

	Task<EmployeeClassification> FindByNameAsync(string employeeClassificationName);

	Task<IList<EmployeeClassification>> GetAllAsync();

	Task<int> CreateAsync(EmployeeClassificationclassification);
	Task UpdateAsync(EmployeeClassificationclassification);
	Task DeleteAsync(EmployeeClassificationclassification);
	Task DeleteAsync(int employeeClassificationKey);
} 
```

No changes are needed for the model in any of these examples.

## ADO.NET

To make an ADO.NET repository asynchronous, simply add `await` and `Async` in the appropriate places. 

@snippet cs [../Recipes.Ado/Repositories/EmployeeClassificationAsynchronousRepository.cs] EmployeeClassificationAsynchronousRepository

## Dapper

To make a Dapper repository asynchronous, simply add `await` and `Async` in the appropriate places. 

@snippet cs [../Recipes.Dapper/Repositories/EmployeeClassificationAsynchronousRepository.cs] EmployeeClassificationAsynchronousRepository

## Tortuga Chain

In Chain, calls to `.Execute()` are replaced with `.ExecuteAsync()`.

@snippet cs [../Recipes.Tortuga.Chain/Repositories/EmployeeClassificationAsynchronousRepository.cs] EmployeeClassificationAsynchronousRepository

## Entity Framework

To make an Entity Framework repository asynchronous, you need to import the `System.Data.Entity` namespace. This creates the async version of the LINQ extension methods needed. 

@snippet cs [../Recipes.EntityFramework/Repositories/EmployeeClassificationAsynchronousRepository.cs] EmployeeClassificationAsynchronousRepository

## NHibernate

NHibernate does not support asynchronous calls. To ensure UI responsiveness, use `Task.Run` calls to create awaitable tasks that run on a background thread. (Do not use `Task.Run` in a server scenario.)



