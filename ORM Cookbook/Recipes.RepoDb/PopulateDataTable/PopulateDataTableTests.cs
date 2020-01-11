using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PopulateDataTable;

namespace Recipes.RepoDb.PopulateDataTable
{
    [TestClass]
    public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
    {
        protected override IPopulateDataTableRepository GetRepository()
        {
            return new PopulateDataTableRepository(Setup.ConnectionString);
        }
    }
}
