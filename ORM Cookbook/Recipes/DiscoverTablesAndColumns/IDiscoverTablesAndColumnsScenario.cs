namespace Recipes.DiscoverTablesAndColumns;

public interface IDiscoverTablesAndColumnsScenario
{
    IList<string> ListColumnsInTable(string schemaName, string tableName);

    IList<string> ListColumnsInView(string schemaName, string viewName);

    IList<string> ListTables();

    IList<string> ListViews();
}