using Recipes.RepoDB.Models;
using Recipes.SingleModelCrudAsync;
using RepoDb.Enumerations;
using RepoDb.Extensions;

namespace Recipes.RepoDB.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;

    public SingleModelCrudAsyncScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return await repository.InsertAsync<int>(classification).ConfigureAwait(false);
    }

    public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        await repository.DeleteAsync(classification).ConfigureAwait(false);
    }

    public async Task DeleteByKeyAsync(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        await repository.DeleteAsync(employeeClassificationKey).ConfigureAwait(false);
    }

    public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return (await repository.QueryAsync(e => e.EmployeeClassificationName == employeeClassificationName)
            .ConfigureAwait(false)).FirstOrDefault();
    }

    public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return (await repository.QueryAllAsync().ConfigureAwait(false)).AsList();
    }

    public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return (await repository.QueryAsync(employeeClassificationKey).ConfigureAwait(false)).FirstOrDefault();
    }

    public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        await repository.UpdateAsync(classification).ConfigureAwait(false);
    }
}