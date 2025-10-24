using Recipes.DiscoverTablesAndColumns;

namespace Recipes.Dapper.DiscoverTablesAndColumns;

[TestClass]
public class DiscoverTablesAndColumnsTests : Recipes.DiscoverTablesAndColumns.DiscoverTablesAndColumnsTests
{
    protected override IDiscoverTablesAndColumnsScenario GetScenario()
    {
        return new DiscoverTablesAndColumnsScenario(Setup.SqlServerConnectionString);
    }
}