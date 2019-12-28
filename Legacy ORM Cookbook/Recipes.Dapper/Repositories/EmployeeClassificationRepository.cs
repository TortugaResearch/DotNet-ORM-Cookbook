using Dapper;
using Recipes.Dapper.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.Dapper.Repositories
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
                        VALUES (@EmployeeClassificationName )";
            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                return con.ExecuteScalar<int>(sql, classification);
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

                return con.QuerySingle<EmployeeClassification>(sql, new { EmployeeClassificationName = employeeClassificationName });
            }
        }

        public void Delete(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                con.Execute(sql, new { EmployeeClassificationKey = employeeClassificationKey });
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                con.Execute(sql, classification);
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            var result = new List<EmployeeClassification>();

            using (var con = new SqlConnection(m_ConnectionString))
            {
                con.Open();
                return con.Query<EmployeeClassification>(sql).ToList();
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
                return con.QuerySingle<EmployeeClassification>(sql, new { EmployeeClassificationKey = employeeClassificationKey });
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
                con.Execute(sql, classification);
            }
        }
    }
}
