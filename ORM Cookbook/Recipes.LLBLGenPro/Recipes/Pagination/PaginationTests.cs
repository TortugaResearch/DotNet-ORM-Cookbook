using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Pagination;

namespace Recipes.LLBLGenPro.Pagination
{
    [TestClass]
    public class PaginationTests : PaginationTests<EmployeeEntity>
    {
        protected override IPaginationScenario<EmployeeEntity> GetScenario()
        {
            return new PaginationScenario();
        }
    }
}
