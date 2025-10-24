using Recipes.DiscoverTablesAndColumns;
using Tortuga.Chain;

namespace Recipes.Chain.DiscoverTablesAndColumns;

public class DiscoverTablesAndColumnsScenario : IDiscoverTablesAndColumnsScenario
{
    readonly SqlServerDataSource m_DataSource;

    public DiscoverTablesAndColumnsScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public IList<string> ListColumnsInTable(string schemaName, string tableName)
    {
        return m_DataSource.DatabaseMetadata.GetTableOrView(schemaName + "." + tableName)
            .Columns.Select(c => c.SqlName).ToList();
    }

    public IList<string> ListColumnsInView(string schemaName, string viewName)
    {
        return m_DataSource.DatabaseMetadata.GetTableOrView(schemaName + "." + viewName)
            .Columns.Select(c => c.SqlName).ToList();
    }

    public IList<string> ListTables()
    {
        m_DataSource.DatabaseMetadata.PreloadTables(); //Only need to call this once
        return m_DataSource.DatabaseMetadata.GetTablesAndViews().Where(t => t.IsTable)
            .Select(t => t.Name.ToString()).ToList();
    }

    public IList<string> ListViews()
    {
        m_DataSource.DatabaseMetadata.PreloadViews(); //Only need to call this once
        return m_DataSource.DatabaseMetadata.GetTablesAndViews().Where(t => t.IsTable == false)
            .Select(t => t.Name.ToString()).ToList();
    }
}