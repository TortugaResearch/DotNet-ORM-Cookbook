using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;

namespace Recipes.Dapper.SingleModelCrudAsync;

public class SingleModelCrudAsyncScenarioContrib : SingleModelCrudAsyncScenario
{
    public SingleModelCrudAsyncScenarioContrib(string connectionString) : base(connectionString)
    {
    }

    override public async Task<int> CreateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return await con.InsertAsync(classification).ConfigureAwait(false);
    }

    override public async Task DeleteAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            await con.DeleteAsync(classification).ConfigureAwait(false);
    }

    override public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        //WARNING: Dapper.Contrib does not support CancellationToken
        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return (await con.GetAllAsync<EmployeeClassification>().ConfigureAwait(false)).ToList();
    }

    override public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
    {
        //WARNING: Dapper.Contrib does not support CancellationToken
        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            return await con.GetAsync<EmployeeClassification>(employeeClassificationKey).ConfigureAwait(false);
    }

    override public async Task UpdateAsync(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var con = await OpenConnectionAsync().ConfigureAwait(false))
            await con.UpdateAsync(classification).ConfigureAwait(false);
    }
}