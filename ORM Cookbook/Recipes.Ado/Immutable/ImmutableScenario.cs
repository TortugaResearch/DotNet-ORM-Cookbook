using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Immutable;
using System.Collections.Immutable;

namespace Recipes.Ado.Immutable;

public class ImmutableScenario : SqlServerScenarioBase, IImmutableScenario<ReadOnlyEmployeeClassification>
{
    public ImmutableScenario(string connectionString) : base(connectionString)
    { }

    public int Create(ReadOnlyEmployeeClassification classification)
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

    public void Delete(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
            cmd.ExecuteNonQuery();
        }
    }

    public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationName", employeeClassificationName);
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                    return null;

                return new ReadOnlyEmployeeClassification(
                    reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                    reader.GetString(reader.GetOrdinal("EmployeeClassificationName")),
                    reader.GetBoolean(reader.GetOrdinal("IsExempt")),
                    reader.GetBoolean(reader.GetOrdinal("IsEmployee"))
                );
            }
        }
    }

    public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

        var result = new List<ReadOnlyEmployeeClassification>();

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add(new ReadOnlyEmployeeClassification(
                    reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                    reader.GetString(reader.GetOrdinal("EmployeeClassificationName")),
                    reader.GetBoolean(reader.GetOrdinal("IsExempt")),
                    reader.GetBoolean(reader.GetOrdinal("IsEmployee"))
                ));
            }

            return result.ToImmutableArray();
        }
    }

    public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
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

                return new ReadOnlyEmployeeClassification(
                    reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey")),
                    reader.GetString(reader.GetOrdinal("EmployeeClassificationName")),
                    reader.GetBoolean(reader.GetOrdinal("IsExempt")),
                    reader.GetBoolean(reader.GetOrdinal("IsEmployee"))
                );
            }
        }
    }

    public void Update(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName, IsExempt = @IsExempt, IsEmployee = @IsEmployee
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
            cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
            cmd.Parameters.AddWithValue("@IsExempt", classification.IsExempt);
            cmd.Parameters.AddWithValue("@IsEmployee", classification.IsEmployee);
            cmd.ExecuteNonQuery();
        }
    }
}