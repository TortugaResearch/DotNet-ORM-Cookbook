using Dapper;
using Recipes.Dapper.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Dapper.Repositories
{
    public class EmployeeClassificationAsynchronousRepository : IEmployeeClassificationAsynchronousRepository<EmployeeClassification>
    {

        readonly string m_ConnectionString;
        public EmployeeClassificationAsynchronousRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName) 
                        OUTPUT Inserted.EmployeeClassificationKey 
                        VALUES (@EmployeeClassificationName )";
            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                return await con.ExecuteScalarAsync<int>(sql, classification);
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                await con.ExecuteAsync(sql, classification);
            }
        }

        public async Task DeleteAsync(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                await con.ExecuteAsync(sql, new { EmployeeClassificationKey = employeeClassificationKey });
            }
        }

        public async Task<EmployeeClassification> FindByNameAsync(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName 
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();

                return await con.QuerySingleAsync<EmployeeClassification>(sql, new { EmployeeClassificationName = employeeClassificationName });
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            var result = new List<EmployeeClassification>();

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                return (await con.QueryAsync<EmployeeClassification>(sql)).ToList();
            }
        }


        public async Task<EmployeeClassification> GetByKeyAsync(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                return await con.QuerySingleAsync<EmployeeClassification>(sql, new { EmployeeClassificationKey = employeeClassificationKey });
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            var sql = @"UPDATE HR.EmployeeClassification 
                        SET EmployeeClassificationName = @EmployeeClassificationName 
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                await con.ExecuteAsync(sql, classification);
            }
        }
    }
}
