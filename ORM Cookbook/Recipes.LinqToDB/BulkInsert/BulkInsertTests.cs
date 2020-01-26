using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.BulkInsert;
using Recipes.LinqToDB.Entities;

namespace Recipes.LinqToDB.BulkInsert
{
    [TestClass]
    public class BulkInsertTests : BulkInsertTests<Employee>
    {
        protected override IBulkInsertScenario<Employee> GetScenario()
        {
            return new BulkInsertScenario();
        }
    }
}
