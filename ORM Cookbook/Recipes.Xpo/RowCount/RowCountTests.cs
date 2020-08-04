using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.RowCount;

namespace Recipes.Xpo.RowCount
{
    [TestClass]
    public class RowCountTests : RowCountTests<Employee>
    {
        protected override IRowCountScenario<Employee> GetScenario()
        {
            return new RowCountScenario();
        }
    }
}
