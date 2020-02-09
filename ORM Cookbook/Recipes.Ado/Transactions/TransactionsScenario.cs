using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Transactions;
using System;
using System.Data;

namespace Recipes.Ado.Transactions
{
    public class TransactionsScenario : SqlServerScenarioBase, ITransactionsScenario<EmployeeClassification>
    {
        public TransactionsScenario(string connectionString) : base(connectionString)
        { }

        public int Create(EmployeeClassification classification, bool shouldRollBack)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                var result = (int)cmd.ExecuteScalar();

                if (shouldRollBack)
                    trans.Rollback();
                else
                    trans.Commit();

                return result;
            }
        }

        public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction(isolationLevel))
            using (var cmd = new SqlCommand(sql, con, trans))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                var result = (int)cmd.ExecuteScalar();

                if (shouldRollBack)
                    trans.Rollback();
                else
                    trans.Commit();

                return result;
            }
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
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
}
