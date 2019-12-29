using Recipes.SingleModelCrudAsync;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : ISingleModelCrudAsyncRepository<EmployeeClassification>
    {
        readonly string m_ConnectionString;

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        async Task<SqlConnection> OpenConnectionAsync()
        {
            var con = new SqlConnection(m_ConnectionString);
            await con.OpenAsync().ConfigureAwait(false);
            return con;
        }

        public SingleModelCrudAsyncRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return await con.InsertAsync<EmployeeClassification, int>(classification).ConfigureAwait(false);
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                await con.DeleteAsync<EmployeeClassification>(employeeClassificationKey).ConfigureAwait(false);
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                await con.DeleteAsync(classification).ConfigureAwait(false);
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return (await con.QueryAsync<EmployeeClassification>(new { EmployeeClassificationName = employeeClassificationName }).ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return (await con.QueryAllAsync<EmployeeClassification>().ConfigureAwait(false)).ToList();
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return (await con.QueryAsync<EmployeeClassification>(employeeClassificationKey).ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                await con.UpdateAsync(classification).ConfigureAwait(false);
        }
    }
}
