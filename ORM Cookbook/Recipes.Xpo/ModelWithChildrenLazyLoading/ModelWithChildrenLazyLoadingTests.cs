using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildrenLazyLoading;
using Recipes.Xpo.Entities;

namespace Recipes.Xpo.ModelWithChildrenLazyLoading
{
    [TestClass]
    public class ModelWithChildrenLazyLoadingTests : ModelWithChildrenLazyLoadingTests<ProductLine, Product>
    {
        protected override IModelWithChildrenLazyLoadingScenario<ProductLine, Product> GetScenario()
        {
            return new ModelWithChildrenLazyLoadingScenario();
        }
    }
}
