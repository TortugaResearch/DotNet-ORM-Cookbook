using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.Dapper.Models;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Dapper.SingleModelCrudAsync
{
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

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return await con.ExecuteScalarAsync<int>(sql, classification).ConfigureAwait(false);
        }

        public async Task DeleteAsync(EmployeeClassification classification)
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

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return (await con.QueryAsync<EmployeeClassification>(new CommandDefinition(sql, cancellationToken: cancellationToken)).ConfigureAwait(false)).ToList();
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                return await con.QuerySingleAsync<EmployeeClassification>(
                    new CommandDefinition(sql, parameters: new { employeeClassificationKey }, cancellationToken: cancellationToken)).ConfigureAwait(false);
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = await OpenConnectionAsync().ConfigureAwait(false))
                await con.ExecuteAsync(sql, classification).ConfigureAwait(false);
        }

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
    }
}
