using Microsoft.Data.SqlClient;
using Recipes.RepoDB.Models;
using Recipes.SingleModelCrudAsync;
using RepoDb;
using RepoDb.Extensions;

using RDB = RepoDb;

namespace Recipes.RepoDB.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenario : BaseRepository<EmployeeClassification, SqlConnection>,
    ISingleModelCrudAsyncScenario<EmployeeClassification>
{
    public SingleModelCrudAsyncScenario(string connectionString)
        : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
    { }

    public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        return await InsertAsync<int>(classification).ConfigureAwait(false);
    }

    public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        await base.DeleteAsync(classification).ConfigureAwait(false);
    }

    public async Task DeleteByKeyAsync(int employeeClassificationKey)
    {
        await DeleteAsync(employeeClassificationKey).ConfigureAwait(false);
    }

    public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
    {
        return (await QueryAsync(e => e.EmployeeClassificationName == employeeClassificationName)
            .ConfigureAwait(false)).FirstOrDefault();
    }

    public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return (await QueryAllAsync().ConfigureAwait(false)).AsList();
    }

    public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
    {
        return (await QueryAsync(employeeClassificationKey).ConfigureAwait(false)).FirstOrDefault();
    }

    public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        await base.UpdateAsync(classification).ConfigureAwait(false);
    }
}