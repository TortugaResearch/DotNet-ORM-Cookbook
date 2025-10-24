using Dapper;
using Recipes.Dapper.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Dapper.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenario : ScenarioBase, ISingleModelCrudAsyncScenario<EmployeeClassification>
{
    public SingleModelCrudAsyncScenario(string connectionString) : base(connectionString)
    {
    }

    virtual public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return await con.ExecuteScalarAsync<int>(sql, classification).ConfigureAwait(false);
    }

    virtual public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            await con.ExecuteAsync(sql, classification).ConfigureAwait(false);
    }

    public async Task DeleteByKeyAsync(int employeeClassificationKey)
    {
        var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            await con.ExecuteAsync(sql, new { employeeClassificationKey }).ConfigureAwait(false);
    }

    public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return await con.QuerySingleAsync<EmployeeClassification>(
                new CommandDefinition(sql, parameters: new { employeeClassificationName }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    virtual public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return (await con.QueryAsync<EmployeeClassification>(new CommandDefinition(sql, cancellationToken: cancellationToken)).ConfigureAwait(false)).ToList();
    }

    virtual public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return await con.QuerySingleAsync<EmployeeClassification>(
                new CommandDefinition(sql, parameters: new { employeeClassificationKey }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    virtual public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            await con.ExecuteAsync(sql, classification).ConfigureAwait(false);
    }
}