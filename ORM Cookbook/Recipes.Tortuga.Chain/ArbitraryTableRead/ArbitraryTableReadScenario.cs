using Recipes.ArbitraryTableRead;
using System.Data;
using Tortuga.Chain;

namespace Recipes.Chain.ArbitraryTableRead;

public class ArbitraryTableReadScenario : IArbitraryTableReadScenario<DataTable>
{
    readonly SqlServerDataSource m_DataSource;

    public ArbitraryTableReadScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public DataTable GetAll(string schemaName, string tableName)
    {
        return m_DataSource.From(schemaName + "." + tableName).ToDataTable().Execute();
    }
}

public class ArbitraryTableReadScenario2 : IArbitraryTableReadScenario<IReadOnlyList<IReadOnlyDictionary<string, object?>>>
{
    readonly SqlServerDataSource m_DataSource;

    public ArbitraryTableReadScenario2(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    //This version returns a lightweight object known as a "Table". It is an alternative to .NET's DataTable.
    public IReadOnlyList<IReadOnlyDictionary<string, object?>> GetAll(string schemaName, string tableName)
    {
        return m_DataSource.From(schemaName + "." + tableName).ToTable().Execute().Rows;
    }
}