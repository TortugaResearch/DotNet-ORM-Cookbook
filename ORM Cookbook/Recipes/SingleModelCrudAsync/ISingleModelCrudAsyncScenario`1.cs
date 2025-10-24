namespace Recipes.SingleModelCrudAsync;

public interface ISingleModelCrudAsyncScenario<TEmployeeClassification>
   where TEmployeeClassification : class, IEmployeeClassification, new()
{
    Task<int> CreateAsync(TEmployeeClassification classification);

    Task DeleteAsync(TEmployeeClassification classification);

    Task DeleteByKeyAsync(int employeeClassificationKey);

    Task<TEmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default);

    Task<IList<TEmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<TEmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default);

    Task UpdateAsync(TEmployeeClassification classification);
}