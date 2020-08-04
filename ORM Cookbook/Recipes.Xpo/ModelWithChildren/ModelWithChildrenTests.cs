using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.ModelWithChildren;

namespace Recipes.Xpo.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
    {
        protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
        {
            return new ModelWithChildrenScenario();
        }
    }
}
