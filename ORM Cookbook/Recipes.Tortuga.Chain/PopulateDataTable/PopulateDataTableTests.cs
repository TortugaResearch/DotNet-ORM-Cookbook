using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PopulateDataTable;

namespace Recipes.Chain.PopulateDataTable
{
    [TestClass]
    public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableRepository GetRepository()
        {
            return new PopulateDataTableRepository(Setup.PrimaryDataSource);
        }
    }
}
