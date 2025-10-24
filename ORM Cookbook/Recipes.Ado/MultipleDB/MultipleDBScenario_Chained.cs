using Recipes.Ado.Models;
using Recipes.MultipleDB;
using System.Data.Common;

namespace Recipes.Ado.MultipleDB;

public class MultipleDBScenario_Chained : IMultipleDBScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;
    readonly DatabaseType m_DatabaseType;

    public MultipleDBScenario_Chained(string connectionString, DatabaseType databaseType)
    {
        m_ConnectionString = connectionString;
        m_DatabaseType = databaseType;
    }

    DbConnection OpenConnection()
    {
        DbConnection con = m_DatabaseType switch
        {
            DatabaseType.SqlServer => new Microsoft.Data.SqlClient.SqlConnection(m_ConnectionString),
            DatabaseType.PostgreSql => new Npgsql.NpgsqlConnection(m_ConnectionString),
            _ => throw new NotImplementedException()
        };

        con.Open();
        return con;
    }

    void AddParameter(DbCommand command, string parameterName, object? value)
    {
        var param = command.CreateParameter();
        param.ParameterName = parameterName;
        param.Value = value;
        command.Parameters.Add(param);
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        string sql = m_DatabaseType switch
        {
            DatabaseType.SqlServer =>
                @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )",
            DatabaseType.PostgreSql =>
                @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        VALUES(@EmployeeClassificationName )
                        RETURNING EmployeeClassificationKey",
            _ => throw new NotImplementedException()
        };

        using (var con = OpenConnection())
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;
            AddParameter(cmd, "@EmployeeClassificationName", classification.EmployeeClassificationName);
            return (int)cmd.ExecuteScalar()!;
        }
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            AddParameter(cmd, "@EmployeeClassificationKey", classification.EmployeeClassificationKey);
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            AddParameter(cmd, "@EmployeeClassificationKey", employeeClassificationKey);
            cmd.ExecuteNonQuery();
        }
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

        using (var con = OpenConnection())
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            AddParameter(cmd, "@EmployeeClassificationName", employeeClassificationName);
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
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

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

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            AddParameter(cmd, "@EmployeeClassificationKey", employeeClassificationKey);
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
        using (var cmd = con.CreateCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            AddParameter(cmd, "@EmployeeClassificationKey", classification.EmployeeClassificationKey);
            AddParameter(cmd, "@EmployeeClassificationName", classification.EmployeeClassificationName);
            cmd.ExecuteNonQuery();
        }
    }
}