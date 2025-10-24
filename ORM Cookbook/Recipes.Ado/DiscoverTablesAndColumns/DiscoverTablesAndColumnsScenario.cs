using Microsoft.Data.SqlClient;
using Recipes.DiscoverTablesAndColumns;

namespace Recipes.Ado.DiscoverTablesAndColumns;

public class DiscoverTablesAndColumnsScenario : SqlServerScenarioBase, IDiscoverTablesAndColumnsScenario
{
    public DiscoverTablesAndColumnsScenario(string connectionString) : base(connectionString)
    { }

    public IList<string> ListColumnsInTable(string schemaName, string tableName)
    {
        const string sql =
            @"SELECT c.name FROM sys.columns c
                    INNER JOIN sys.tables t ON c.object_id = t.object_id
                    INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                    WHERE s.name = @SchemaName AND t.name = @TableName";

        var result = new List<string>();
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            cmd.Parameters.AddWithValue("@TableName", tableName);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(reader.GetString(0));
            }
        }
        return result;
    }

    public IList<string> ListColumnsInView(string schemaName, string viewName)
    {
        const string sql =
            @"SELECT c.name FROM sys.columns c
                    INNER JOIN sys.views v ON c.object_id = v.object_id
                    INNER JOIN sys.schemas s ON v.schema_id = s.schema_id
                    WHERE s.name = @SchemaName AND v.name = @ViewName";

        var result = new List<string>();
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@SchemaName", schemaName);
            cmd.Parameters.AddWithValue("@ViewName", viewName);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(reader.GetString(0));
            }
        }
        return result;
    }

    public IList<string> ListTables()
    {
        const string sql =
            "SELECT s.name + '.' + t.name FROM sys.tables t INNER JOIN sys.schemas s ON t.schema_id = s.schema_id";

        var result = new List<string>();
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(reader.GetString(0));
            }
        }
        return result;
    }

    public IList<string> ListViews()
    {
        const string sql =
            "SELECT s.name + '.' + v.name  FROM sys.views v INNER JOIN sys.schemas s ON v.schema_id = s.schema_id";

        var result = new List<string>();
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(reader.GetString(0));
            }
        }
        return result;
    }
}