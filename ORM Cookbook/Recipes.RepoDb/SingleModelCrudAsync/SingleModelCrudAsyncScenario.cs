using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.SingleModelCrudAsync;
using RDB = RepoDb;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
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
}
