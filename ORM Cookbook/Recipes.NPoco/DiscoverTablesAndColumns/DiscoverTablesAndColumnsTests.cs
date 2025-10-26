using Recipes.DiscoverTablesAndColumns;

namespace Recipes.NPoco.DiscoverTablesAndColumns;

[TestClass]
public class DiscoverTablesAndColumnsTests : Recipes.DiscoverTablesAndColumns.DiscoverTablesAndColumnsTests
{
    protected override IDiscoverTablesAndColumnsScenario GetScenario()
    {
        return new DiscoverTablesAndColumnsScenario(Setup.SqlServerConnectionString);
    }
}