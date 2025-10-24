using DbConnector.Core;
using Microsoft.Data.SqlClient;
using Npgsql;
using Recipes.DbConnector.Models;
using Recipes.MultipleDB;

namespace Recipes.DbConnector.MultipleDB;

public class MultipleDBScenario : IMultipleDBScenario<EmployeeClassification>
{
    IDbConnector DbConnector { get; }
    readonly DatabaseType m_DatabaseType;

    public MultipleDBScenario(string connectionString, DatabaseType databaseType)
    {
        if (databaseType == DatabaseType.SqlServer)
        {
            DbConnector = new DbConnector<SqlConnection>(connectionString);
        }
        else
        {
            DbConnector = new DbConnector<NpgsqlConnection>(connectionString);
        }

        //DbConnector.ConnectionType could also be used...
        m_DatabaseType = databaseType;
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

        return DbConnector.Scalar<int>(sql, classification).Execute();
    }

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, classification).Execute();
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        const string sql = @"DELETE FROM HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        DbConnector.NonQuery(sql, new { employeeClassificationKey }).Execute();
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationName }).Execute();
    }

    public IList<EmployeeClassification> GetAll()
    {
        const string sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

        return DbConnector.ReadToList<EmployeeClassification>(sql).Execute();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }

    public void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        const string sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

        DbConnector.NonQuery(sql, classification).Execute();
    }
}