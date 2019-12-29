using Recipes.Ado.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Recipes.Ado
{
    internal class DepartmentWithChildRepository : IDepartmentWithChildRepository<Department, Division>
    {
        readonly string m_ConnectionString;

        public DepartmentWithChildRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(Department department)
        {
            var sql = @"INSERT INTO HR.Department (DepartmentName, DivisionKey) 
                        OUTPUT Inserted.DepartmentKey 
                        VALUES(@DepartmentName, @DivisionKey )";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@DivisionKey", department.Division.DivisionKey);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Delete(int departmentKey)
        {
            var sql = @"DELETE HR.Department WHERE DepartmentKey = @DepartmentKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentKey", departmentKey);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(Department department)
        {
            var sql = @"DELETE HR.Department WHERE DepartmentKey = @DepartmentKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentKey", department.DepartmentKey);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IList<Department> GetAll()
        {
            var sql = @"SELECT	d.DepartmentKey, d.DepartmentName, d.DivisionKey, d.DivisionName FROM HR.DepartmentDetail d;";

            var result = new List<Department>();

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Department()
                            {
                                DepartmentKey = reader.GetInt32(reader.GetOrdinal("DepartmentKey")),
                                DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
                                Division = new Division()
                                {
                                    DivisionKey = reader.GetInt32(reader.GetOrdinal("DivisionKey")),
                                    DivisionName = reader.GetString(reader.GetOrdinal("DivisionName")),
                                }
                            });
                        }
                        return result;
                    }
                }
            }
        }

        public IList<Division> GetAllDivisions()
        {
            var sql = @"SELECT	d.DivisionKey, d.DivisionName FROM HR.Division d;";

            var result = new List<Division>();

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Division()
                            {
                                DivisionKey = reader.GetInt32(reader.GetOrdinal("DivisionKey")),
                                DivisionName = reader.GetString(reader.GetOrdinal("DivisionName"))
                            });
                        }
                        return result;
                    }
                }
            }
        }

        public Department GetByKey(int departmentKey)
        {
            var sql = @"SELECT d.DepartmentKey, d.DepartmentName, d.DivisionKey, d.DivisionName
                        FROM HR.DepartmentDetail d
                        WHERE d.DepartmentKey = @DepartmentKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentKey", departmentKey);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                            return null;

                        return new Department()
                        {
                            DepartmentKey = reader.GetInt32(reader.GetOrdinal("DepartmentKey")),
                            DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName")),
                            Division = new Division()
                            {
                                DivisionKey = reader.GetInt32(reader.GetOrdinal("DivisionKey")),
                                DivisionName = reader.GetString(reader.GetOrdinal("DivisionName")),
                            }
                        };
                    }
                }
            }
        }

        public void Update(Department department)
        {
            var sql = @"UPDATE HR.Department 
                        SET DepartmentName = @DepartmentName, DivisionKey = @DivisionKey
                        WHERE DepartmentKey = @DepartmentKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@DepartmentKey", department.DepartmentKey);
                    cmd.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                    cmd.Parameters.AddWithValue("@DivisionKey", department.Division.DivisionKey);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

