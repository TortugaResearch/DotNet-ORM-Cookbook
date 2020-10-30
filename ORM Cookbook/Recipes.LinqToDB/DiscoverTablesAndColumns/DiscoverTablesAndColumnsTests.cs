using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.DiscoverTablesAndColumns;

namespace Recipes.LinqToDB.DiscoverTablesAndColumns
{
    [TestClass]
    public class DiscoverTablesAndColumnsTests : Recipes.DiscoverTablesAndColumns.DiscoverTablesAndColumnsTests
    {
        protected override IDiscoverTablesAndColumnsScenario GetScenario()
        {
            return new DiscoverTablesAndColumnsScenario();
        }
    }
}
