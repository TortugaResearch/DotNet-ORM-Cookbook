using Dapper;
using Microsoft.Data.SqlClient;
using Recipes.Immutable;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Recipes.Dapper.Immutable
{
    public class ImmutableRepository : IImmutableRepository<ReadOnlyEmployeeClassification>
    {
        readonly string m_ConnectionString;

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

        public ImmutableRepository(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName, IsExempt, IsEmployee)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName, @IsExempt, @IsEmployee )";

            using (var con = OpenConnection())
                return con.ExecuteScalar<int>(sql, classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, new { employeeClassificationKey });
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, classification);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = OpenConnection())
                return con.QuerySingleOrDefault<ReadOnlyEmployeeClassification>(sql, new { employeeClassificationName });
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

            using (var con = OpenConnection())
                return con.Query<ReadOnlyEmployeeClassification>(sql).ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return con.QuerySingle<ReadOnlyEmployeeClassification>(sql, new { employeeClassificationKey });
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName, IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                con.Execute(sql, classification);
        }
    }
}
