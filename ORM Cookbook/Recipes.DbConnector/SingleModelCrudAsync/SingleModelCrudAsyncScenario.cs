using Recipes.DbConnector.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.DbConnector.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenario : ScenarioBase, ISingleModelCrudAsyncScenario<EmployeeClassification>
{
    public SingleModelCrudAsyncScenario(string connectionString) : base(connectionString)
    {
    }

    public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

        return await DbConnector.Scalar<int>(sql, classification)
                    .ExecuteAsync()
                    .ConfigureAwait(false);
    }

    public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        await DbConnector.NonQuery(sql, classification)
                         .ExecuteAsync()
                         .ConfigureAwait(false);
    }

    public async Task DeleteByKeyAsync(int employeeClassificationKey)
    {
        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        await DbConnector.NonQuery(sql, new { employeeClassificationKey })
                         .ExecuteAsync()
                         .ConfigureAwait(false);
    }

    public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

        return await DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationName })
                                .ExecuteAsync(token: cancellationToken)
                                .ConfigureAwait(false);
    }

    public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

        return await DbConnector.ReadToList<EmployeeClassification>(sql)
                    .ExecuteAsync(token: cancellationToken)
                    .ConfigureAwait(false);
    }

    public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return await DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey })
                                .ExecuteAsync(token: cancellationToken)
                                .ConfigureAwait(false);
    }

    public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        await DbConnector.NonQuery(sql, classification)
                         .ExecuteAsync()
                         .ConfigureAwait(false);
    }
}