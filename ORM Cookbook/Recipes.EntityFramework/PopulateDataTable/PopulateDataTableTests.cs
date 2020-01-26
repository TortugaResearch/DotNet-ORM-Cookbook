using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PopulateDataTable;

namespace Recipes.EntityFramework.PopulateDataTable
{
    [TestClass]
    public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableScenario GetScenario()
        {
            return new PopulateDataTableScenario(Setup.DBContextFactory);
        }
    }

    [TestClass]
    public class PopulateDataTableTests2 : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableScenario GetScenario()
        {
            return new PopulateDataTableScenario2(Setup.DBContextFactory);
        }
    }
}
