using Recipes.Ado.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Recipes.Ado.Repositories
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
                        VALUES(@EmployeeClassificationName )";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                    return (int)await cmd.ExecuteScalarAsync();
                }
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                    await cmd.ExecuteNonQueryAsync();
                }
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

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationName", employeeClassificationName);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!await reader.ReadAsync())
                            return null;

                        return new EmployeeClassification()
                        {
                            EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                            EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                        };
                    }
                }
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            var result = new List<EmployeeClassification>();

            using (var con = new SqlConnection(m_ConnectionString))
            {
                await con.OpenAsync();

                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new EmployeeClassification()
                            {
                                EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                                EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                            });
                        }
                        return result;
                    }
                }
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

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!await reader.ReadAsync())
                            return null;

                        return new EmployeeClassification()
                        {
                            EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                            EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"))
                        };
                    }
                }
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
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                    cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
