using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PopulateDataTable;

namespace Recipes.EntityFrameworkCore.PopulateDataTable
{
    [TestClass]
    public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableRepository GetRepository()
        {
            return new PopulateDataTableRepository(Setup.DBContextFactory);
        }
    }

    [TestClass]
    public class PopulateDataTableTests2 : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableRepository GetRepository()
        {
            return new PopulateDataTableRepository2(Setup.DBContextFactory);
        }
    }
}
