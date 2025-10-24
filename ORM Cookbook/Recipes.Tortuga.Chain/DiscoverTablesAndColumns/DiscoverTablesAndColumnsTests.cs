using Recipes.DiscoverTablesAndColumns;

namespace Recipes.Chain.DiscoverTablesAndColumns;

[TestClass]
public class DiscoverTablesAndColumnsTests : Recipes.DiscoverTablesAndColumns.DiscoverTablesAndColumnsTests
{
    protected override IDiscoverTablesAndColumnsScenario GetScenario()
    {
        return new DiscoverTablesAndColumnsScenario(Setup.PrimaryDataSource);
    }
}