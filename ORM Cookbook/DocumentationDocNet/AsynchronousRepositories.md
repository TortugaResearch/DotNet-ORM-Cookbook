# Asynchronous Scenarios

This scenario demonstrates the use of asynchronous CRUD operations. Asynchronous database calls are generally preferable, as they allow for more throughput in server applications and prevent UI blocking in GUI applications.

## Scenario Prototype

The prototype repository based on our “Single Model” scenario, with a slight modification to the signatures. 

```csharp
public interface IEmployeeClassificationAsynchronousScenario
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

@snippet cs [../Recipes.Ado/Repositories/EmployeeClassificationAsynchronousScenario.cs] EmployeeClassificationAsynchronousScenario

## Dapper

To make a Dapper repository asynchronous, simply add `await` and `Async` in the appropriate places. 

@snippet cs [../Recipes.Dapper/Repositories/EmployeeClassificationAsynchronousScenario.cs] EmployeeClassificationAsynchronousScenario

## Tortuga Chain

In Chain, calls to `.Execute()` are replaced with `.ExecuteAsync()`.

@snippet cs [../Recipes.Tortuga.Chain/Repositories/EmployeeClassificationAsynchronousScenario.cs] EmployeeClassificationAsynchronousScenario

## Entity Framework

To make an Entity Framework repository asynchronous, you need to import the `System.Data.Entity` namespace. This creates the async version of the LINQ extension methods needed. 

@snippet cs [../Recipes.EntityFramework/Repositories/EmployeeClassificationAsynchronousScenario.cs] EmployeeClassificationAsynchronousScenario

## RepoDb

To make a RepoDb repository asynchronous, simply add `await` and `Async` in the appropriate places.

@snippet cs [../Recipes.RepoDb/Repositories/EmployeeClassificationAsynchronousScenario.cs] EmployeeClassificationAsynchronousScenario

## NHibernate

NHibernate does not support asynchronous calls. To ensure UI responsiveness, use `Task.Run` calls to create awaitable tasks that run on a background thread. (Do not use `Task.Run` in a server scenario.)



