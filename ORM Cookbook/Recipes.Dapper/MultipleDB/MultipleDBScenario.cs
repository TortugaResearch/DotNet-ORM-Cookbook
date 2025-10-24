using Dapper;
using Recipes.Dapper.Models;
using Recipes.MultipleDB;
using System.Data.Common;

namespace Recipes.Dapper.MultipleDB;

public class MultipleDBScenario : IMultipleDBScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;
    readonly DatabaseType m_DatabaseType;

    public MultipleDBScenario(string connectionString, DatabaseType databaseType)
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
            return con.ExecuteScalar<int>(sql, classification);
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
            con.Execute(sql, new { classification.EmployeeClassificationKey });
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
            con.Execute(sql, new { EmployeeClassificationKey = employeeClassificationKey });
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

        using (var con = OpenConnection())
            return con.QuerySingle<EmployeeClassification>(sql, new { EmployeeClassificationName = employeeClassificationName });
    }

    public IList<EmployeeClassification> GetAll()
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

        var result = new List<EmployeeClassification>();

        using (var con = OpenConnection())
            return con.Query<EmployeeClassification>(sql).ToList();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
        {
            return con.QuerySingleOrDefault<EmployeeClassification>(sql, new { EmployeeClassificationKey = employeeClassificationKey });
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
            con.Execute(sql, classification);
    }
}