using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleColumn;

namespace Recipes.RepoDb.SingleColumn
{
    [TestClass]
    public class SingleColumnTests : Recipes.SingleColumn.SingleColumnTests
    {
        protected override ISingleColumnScenario GetScenario()
        {
            return new SingleColumnScenario(Setup.ConnectionString);
        }
    }
}