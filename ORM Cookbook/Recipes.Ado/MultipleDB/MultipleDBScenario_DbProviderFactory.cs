using Recipes.Ado.Models;
using Recipes.MultipleDB;
using System.Data.Common;

namespace Recipes.Ado.MultipleDB;

public class MultipleDBScenario_DbProviderFactory : IMultipleDBScenario<EmployeeClassification>
{
    readonly DbProviderFactory m_ProviderFactory;
    readonly string m_ConnectionString;
    readonly DatabaseType m_DatabaseType;

    public MultipleDBScenario_DbProviderFactory(string connectionString, DatabaseType databaseType)
    {
        m_ConnectionString = connectionString;
        m_DatabaseType = databaseType;

        m_ProviderFactory = databaseType switch
        {
            DatabaseType.SqlServer => Microsoft.Data.SqlClient.SqlClientFactory.Instance,
            DatabaseType.PostgreSql => Npgsql.NpgsqlFactory.Instance,
            _ => throw new NotImplementedException()
        };
    }

    DbConnection OpenConnection()
    {
        var con = m_ProviderFactory.CreateConnection()!;
        con.ConnectionString = m_ConnectionString;
        con.Open();
        return con;
    }

    DbParameter CreateParameter(string parameterName, object? value)
    {
        var param = m_ProviderFactory.CreateParameter()!;
        param.ParameterName = parameterName;
        param.Value = value;
        return param;
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
        using (var cmd = m_ProviderFactory.CreateCommand()!)
        {
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationName", classification.EmployeeClassificationName));
            return (int)cmd.ExecuteScalar()!;
        }
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = m_ProviderFactory.CreateCommand()!)
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationKey", classification.EmployeeClassificationKey));
            cmd.ExecuteNonQuery();
        }
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        using (var cmd = m_ProviderFactory.CreateCommand()!)
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationKey", employeeClassificationKey));
            cmd.ExecuteNonQuery();
        }
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

        using (var con = OpenConnection())
        using (var cmd = m_ProviderFactory.CreateCommand()!)
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationName", employeeClassificationName));
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
        using (var cmd = m_ProviderFactory.CreateCommand()!)
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
        using (var cmd = m_ProviderFactory.CreateCommand()!)
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationKey", employeeClassificationKey));
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
        using (var cmd = m_ProviderFactory.CreateCommand()!)
        {
            cmd.Connection = con;
            cmd.CommandText = sql;

            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationKey", classification.EmployeeClassificationKey));
            cmd.Parameters.Add(CreateParameter("@EmployeeClassificationName", classification.EmployeeClassificationName));
            cmd.ExecuteNonQuery();
        }
    }
}