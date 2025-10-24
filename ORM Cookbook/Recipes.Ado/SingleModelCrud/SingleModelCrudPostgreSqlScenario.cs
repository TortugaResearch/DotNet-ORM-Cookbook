using Npgsql;
using Recipes.Ado.Models;
using Recipes.SingleModelCrud;

namespace Recipes.Ado.SingleModelCrud;

public class SingleModelCrudPostgreSqlScenario : PostgreSqlScenarioBase, ISingleModelCrudScenario<EmployeeClassification>
{
    public SingleModelCrudPostgreSqlScenario(string connectionString) : base(connectionString)
    { }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        VALUES(@EmployeeClassificationName )
                        RETURNING EmployeeClassificationKey";

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
            return (int)cmd.ExecuteScalar()!;
        }
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
            cmd.ExecuteNonQuery();
        }
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
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

    public IList<EmployeeClassification> GetAll()
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

        var result = new List<EmployeeClassification>();

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
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

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
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

    public void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = new NpgsqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", classification.EmployeeClassificationKey);
            cmd.Parameters.AddWithValue("@EmployeeClassificationName", classification.EmployeeClassificationName);
            cmd.ExecuteNonQuery();
        }
    }
}