using Recipes.RepoDb.Entities;
using Recipes.SingleModelCrudAsync;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : BaseRepository<EmployeeClassificationSingleModelCrudAsync, SqlConnection>,
        ISingleModelCrudAsyncRepository<EmployeeClassificationSingleModelCrudAsync>
    {
        public SingleModelCrudAsyncRepository(string connectionString)
            : base(connectionString)
        { }

        public async Task<int> CreateAsync(EmployeeClassificationSingleModelCrudAsync classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return await InsertAsync<int>(classification).ConfigureAwait(false);
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            await DeleteAsync(employeeClassificationKey).ConfigureAwait(false);
        }

        public async Task DeleteAsync(EmployeeClassificationSingleModelCrudAsync classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            await base.DeleteAsync(classification).ConfigureAwait(false);
        }

        public async Task<EmployeeClassificationSingleModelCrudAsync?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            return (await QueryAsync(e => e.EmployeeClassificationName == employeeClassificationName)
                .ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task<IList<EmployeeClassificationSingleModelCrudAsync>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return (await QueryAllAsync().ConfigureAwait(false)).AsList();
        }

        public async Task<EmployeeClassificationSingleModelCrudAsync?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            return (await QueryAsync(employeeClassificationKey).ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task UpdateAsync(EmployeeClassificationSingleModelCrudAsync classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            await base.UpdateAsync(classification).ConfigureAwait(false);
        }
    }
}
