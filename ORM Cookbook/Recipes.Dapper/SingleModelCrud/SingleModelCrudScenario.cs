using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.Dapper.Models;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Dapper.SingleModelCrud
{
    public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
    {
        readonly string m_ConnectionString;

        public SingleModelCrudScenario(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            using (var con = OpenConnection())
                return con.ExecuteScalar<int>(sql, classification);
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, new { employeeClassificationKey });
        }

        public EmployeeClassification? FindByName(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = OpenConnection())
                return con.QuerySingle<EmployeeClassification>(sql, new { employeeClassificationName });
        }

        public IList<EmployeeClassification> GetAll()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            using (var con = OpenConnection())
                return con.Query<EmployeeClassification>(sql).ToList();
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return con.QuerySingle<EmployeeClassification>(sql, new { employeeClassificationKey });
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, classification);
        }

        /// <summary>
        /// Opens a database connection.
        /// </summary>
        /// <remarks>Caller must dispose the connection.</remarks>
        SqlConnection OpenConnection()
        {
            var con = new SqlConnection(m_ConnectionString);
            con.Open();
            return con;
        }
    }
}
