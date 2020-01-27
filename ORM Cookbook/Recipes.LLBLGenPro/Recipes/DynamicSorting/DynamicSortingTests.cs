using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.DynamicSorting;

namespace Recipes.LLBLGenPro.DynamicSorting
{
    [TestClass]
    public class DynamicSortingTests : DynamicSortingTests<EmployeeEntity>
    {
        protected override IDynamicSortingScenario<EmployeeEntity> GetScenario()
        {
            return new DynamicSortingScenario();
        }
    }
}
