using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.RowCount;

namespace Recipes.LinqToDB.RowCount
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
