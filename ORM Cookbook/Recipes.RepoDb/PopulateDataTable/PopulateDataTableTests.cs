using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PopulateDataTable;

namespace Recipes.RepoDB.PopulateDataTable
{
    [TestClass]
    public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableScenario GetScenario()
        {
            return new PopulateDataTableScenario(Setup.ConnectionString);
        }
    }
}
