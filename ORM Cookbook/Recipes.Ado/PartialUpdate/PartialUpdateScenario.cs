using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.PartialUpdate;
using System;

namespace Recipes.Ado.PartialUpdate
{
    public class PartialUpdateScenario : SqlServerScenarioBase, IPartialUpdateScenario<EmployeeClassification>
    {
        public PartialUpdateScenario(string connectionString) : base(connectionString)
        { }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName, IsExempt, IsEmployee)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName, @IsExempt, @IsEmployee )";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
                cmd.Parameters.AddWithValue("@IsExempt", classification.IsExempt);
                cmd.Parameters.AddWithValue("@IsEmployee", classification.IsEmployee);
                return (int)cmd.ExecuteScalar();
            }
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
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
                        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName")),
                        IsExempt = reader.GetBoolean(reader.GetOrdinal("IsExempt")),
                        IsEmployee = reader.GetBoolean(reader.GetOrdinal("IsEmployee"))
                    };
                }
            }
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            const string sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", updateMessage.EmployeeClassificationKey);
                cmd.Parameters.AddWithValue("@EmployeeClassificationName", updateMessage.EmployeeClassificationName);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            const string sql = @"UPDATE HR.EmployeeClassification
                        SET IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", updateMessage.EmployeeClassificationKey);
                cmd.Parameters.AddWithValue("@IsExempt", updateMessage.IsExempt);
                cmd.Parameters.AddWithValue("@IsEmployee", updateMessage.IsEmployee);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            const string sql = @"UPDATE HR.EmployeeClassification
                        SET IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
                cmd.Parameters.AddWithValue("@IsExempt", isExempt);
                cmd.Parameters.AddWithValue("@IsEmployee", isEmployee);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
