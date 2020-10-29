using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.DiscoverTablesAndColumns;
using Recipes.Dapper.Models;

namespace Recipes.Dapper.DiscoverTablesAndColumns
{
    [TestClass]
    public class DiscoverTablesAndColumnsTests : Recipes.DiscoverTablesAndColumns.DiscoverTablesAndColumnsTests
    {
        protected override IDiscoverTablesAndColumnsScenario GetScenario()
        {
            return new DiscoverTablesAndColumnsScenario(Setup.SqlServerConnectionString);
        }
    }
}
