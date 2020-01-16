using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildren;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
    {
        protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
        {
            return new ModelWithChildrenScenario(Setup.DBContextFactory);
        }
    }
}
