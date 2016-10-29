using Recipes.Ado.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Recipes.Ado.Repositories
{
    public class EmployeeClassificationRepository : IEmployeeClassificationRepository<EmployeeClassification>
    {

        readonly string m_ConnectionString;
        public EmployeeClassificationRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(EmployeeClassification classification)
        {
            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName) 
                        OUTPUT Inserted.EmployeeClassificationKey 
                        VALUES(@EmployeeClassificationName )";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName 
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationName", employeeClassificationName);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
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

        public IList<EmployeeClassification> GetAll()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            var result = new List<EmployeeClassification>();

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
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

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
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
        public void Update(EmployeeClassification classification)
        {
            var sql = @"UPDATE HR.EmployeeClassification 
                        SET EmployeeClassificationName = @EmployeeClassificationName 
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
                    cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
