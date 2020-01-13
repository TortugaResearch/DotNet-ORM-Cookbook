using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.PartialUpdate;
using System;

namespace Recipes.Dapper.PartialUpdate
{
    public class PartialUpdateRepository : IPartialUpdateRepository<EmployeeClassification>
    {
        readonly string m_ConnectionString;

        public PartialUpdateRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName, IsExempt, IsEmployee)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName, @IsExempt, @IsEmployee )";

            using (var con = OpenConnection())
                return con.ExecuteScalar<int>(sql, classification);
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return con.QuerySingle<EmployeeClassification>(sql, new { employeeClassificationKey });
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, updateMessage);
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, updateMessage);
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            var sql = @"UPDATE HR.EmployeeClassification
                        SET IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, new { employeeClassificationKey, isExempt, isEmployee });
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
