using Dapper;
using Recipes.DiscoverTablesAndColumns;

namespace Recipes.Dapper.DiscoverTablesAndColumns;

public class DiscoverTablesAndColumnsScenario : ScenarioBase, IDiscoverTablesAndColumnsScenario
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

        using (var con = OpenConnection())
            return con.Query<string>(sql, new { schemaName, tableName }).ToList();
    }

    public IList<string> ListColumnsInView(string schemaName, string viewName)
    {
        const string sql =
            @"SELECT c.name FROM sys.columns c
                    INNER JOIN sys.views v ON c.object_id = v.object_id
                    INNER JOIN sys.schemas s ON v.schema_id = s.schema_id
                    WHERE s.name = @SchemaName AND v.name = @ViewName";

        using (var con = OpenConnection())
            return con.Query<string>(sql, new { schemaName, viewName }).ToList();
    }

    public IList<string> ListTables()
    {
        const string sql =
            "SELECT s.name + '.' + t.name FROM sys.tables t INNER JOIN sys.schemas s ON t.schema_id = s.schema_id";

        using (var con = OpenConnection())
            return con.Query<string>(sql).ToList();
    }

    public IList<string> ListViews()
    {
        const string sql =
            "SELECT s.name + '.' + v.name  FROM sys.views v INNER JOIN sys.schemas s ON v.schema_id = s.schema_id";

        using (var con = OpenConnection())
            return con.Query<string>(sql).ToList();
    }
}