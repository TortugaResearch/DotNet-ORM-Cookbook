#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

using Recipes.PetaPoco.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.PetaPoco.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenario : ScenarioBase, ISingleModelCrudAsyncScenario<EmployeeClassification>
{
    public SingleModelCrudAsyncScenario(string connectionString) : base(connectionString)
    {
    }

    virtual public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    virtual public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public async Task DeleteByKeyAsync(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    virtual public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    virtual public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    virtual public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }
}