using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Sorting;

namespace Recipes.LLBLGenPro.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<EmployeeEntity>
    {
        protected override ISortingScenario<EmployeeEntity> GetScenario()
        {
            return new SortingScenario();
        }
    }
}
