using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.RowCount;

namespace Recipes.EntityFramework.RowCount
{
    [TestClass]
    public class RowCountTests : RowCountTests<Employee>
    {
        protected override IRowCountScenario<Employee> GetScenario()
        {
            return new RowCountScenario(Setup.DBContextFactory);
        }
    }
}
