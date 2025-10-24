using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Recipes.DiscoverTablesAndColumns;
using Recipes.EntityFrameworkCore.Entities;
using System.Data;
using System.Data.Common;

namespace Recipes.EntityFrameworkCore.DiscoverTablesAndColumns;

public class DiscoverTablesAndColumnsScenario : IDiscoverTablesAndColumnsScenario
{
    private readonly Func<OrmCookbookContext> CreateDbContext;

    public DiscoverTablesAndColumnsScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public IList<string> ListColumnsInTable(string schemaName, string tableName)
    {
        using OrmCookbookContext context = CreateDbContext();
        using DbCommand commnd = context.Database.GetDbConnection().CreateCommand();
        const string sql =
            @"SELECT c.name AS ColumnName
                FROM sys.columns c
                INNER JOIN sys.tables t ON c.object_id = t.object_id
                INNER JOIN sys.schemas s ON t.schema_id = s.schema_id
                WHERE s.name = @SchemaName AND t.name = @TableName";
        commnd.CommandText = sql;
        commnd.Parameters.Add(new SqlParameter { ParameterName = "SchemaName", DbType = DbType.String, Value = schemaName });
        commnd.Parameters.Add(new SqlParameter { ParameterName = "TableName", DbType = DbType.String, Value = tableName });
        commnd.Connection!.Open();
        DbDataReader reader = commnd.ExecuteReader(CommandBehavior.CloseConnection);
        var columnNames = new List<string>();
        while (reader.Read())
        {
            int columnNameOrdinal = reader.GetOrdinal("ColumnName");
            string columnName = reader.GetString(columnNameOrdinal);
            columnNames.Add(columnName);
        }
        return columnNames;
    }

    public IList<string> ListColumnsInView(string schemaName, string viewName)
    {
        using OrmCookbookContext context = CreateDbContext();
        using DbCommand commnd = context.Database.GetDbConnection().CreateCommand();
        const string sql =
            @"SELECT c.name AS ColumnName
                FROM sys.columns c
                INNER JOIN sys.views v ON c.object_id = v.object_id
                INNER JOIN sys.schemas s ON v.schema_id = s.schema_id
                WHERE s.name = @SchemaName AND v.name = @ViewName";
        commnd.CommandText = sql;
        commnd.Parameters.Add(new SqlParameter { ParameterName = "SchemaName", DbType = DbType.String, Value = schemaName });
        commnd.Parameters.Add(new SqlParameter { ParameterName = "ViewName", DbType = DbType.String, Value = viewName });
        commnd.Connection!.Open();
        DbDataReader reader = commnd.ExecuteReader(CommandBehavior.CloseConnection);
        var columnNames = new List<string>();
        while (reader.Read())
        {
            int columnNameOrdinal = reader.GetOrdinal("ColumnName");
            string columnName = reader.GetString(columnNameOrdinal);
            columnNames.Add(columnName);
        }
        return columnNames;
    }

    public IList<string> ListTables()
    {
        using OrmCookbookContext context = CreateDbContext();
        using DbCommand commnd = context.Database.GetDbConnection().CreateCommand();
        const string sql =
            @"SELECT s.name + '.' + t.name AS TableName
                FROM sys.tables t
                INNER JOIN sys.schemas s ON t.schema_id = s.schema_id";
        commnd.CommandText = sql;
        commnd.Connection!.Open();
        DbDataReader reader = commnd.ExecuteReader(CommandBehavior.CloseConnection);
        var tableNames = new List<string>();
        while (reader.Read())
        {
            int tableNameOrdinal = reader.GetOrdinal("TableName");
            string tableName = reader.GetString(tableNameOrdinal);
            tableNames.Add(tableName);
        }
        return tableNames;
    }

    public IList<string> ListViews()
    {
        using OrmCookbookContext context = CreateDbContext();
        using DbCommand commnd = context.Database.GetDbConnection().CreateCommand();
        const string sql =
            @"SELECT s.name + '.' + v.name AS ViewName
                FROM sys.views v
                INNER JOIN sys.schemas s ON v.schema_id = s.schema_id";
        commnd.CommandText = sql;
        commnd.Connection!.Open();
        DbDataReader reader = commnd.ExecuteReader(CommandBehavior.CloseConnection);
        var tableNames = new List<string>();
        while (reader.Read())
        {
            int tableNameOrdinal = reader.GetOrdinal("ViewName");
            string tableName = reader.GetString(tableNameOrdinal);
            tableNames.Add(tableName);
        }
        return tableNames;
    }
}