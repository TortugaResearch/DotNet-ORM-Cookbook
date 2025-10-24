using Recipes.ServiceStack.Entities;
using Recipes.SingleModelCrudAsync;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassification>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public SingleModelCrudAsyncScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return (int)await db.InsertAsync(classification, true).ConfigureAwait(false);
        }
    }

    public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            await db.DeleteAsync(classification).ConfigureAwait(false);
        }
    }

    public async Task DeleteByKeyAsync(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            await db.DeleteByIdAsync<EmployeeClassification>(employeeClassificationKey).ConfigureAwait(false);
        }
    }

    public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(employeeClassificationName))
            throw new ArgumentNullException(nameof(employeeClassificationName), $"{nameof(employeeClassificationName)} is null or whitespace.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return await db.SingleAsync<EmployeeClassification>(
                    r => r.EmployeeClassificationName == employeeClassificationName, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return await db.SelectAsync<EmployeeClassification>(cancellationToken).ConfigureAwait(false);
        }
    }

    public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey,
                CancellationToken cancellationToken = default)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return await db.SingleByIdAsync<EmployeeClassification>(employeeClassificationKey, cancellationToken)
                .ConfigureAwait(false);
        }
    }

    public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            await db.UpdateAsync(classification).ConfigureAwait(false);
        }
    }
}