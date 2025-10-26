using Recipes.DiscoverTablesAndColumns;

namespace Recipes.PetaPoco.DiscoverTablesAndColumns;

public class DiscoverTablesAndColumnsScenario : ScenarioBase, IDiscoverTablesAndColumnsScenario
{
    public DiscoverTablesAndColumnsScenario(string connectionString) : base(connectionString)
    { }

    public IList<string> ListColumnsInTable(string schemaName, string tableName)
    {
        throw new NotImplementedException();
    }

    public IList<string> ListColumnsInView(string schemaName, string viewName)
    {
        throw new NotImplementedException();
    }

    public IList<string> ListTables()
    {
        throw new NotImplementedException();
    }

    public IList<string> ListViews()
    {
        throw new NotImplementedException();
    }
}