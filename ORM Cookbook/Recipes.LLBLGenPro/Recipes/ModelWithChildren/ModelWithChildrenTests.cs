using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithChildren;

namespace Recipes.LLBLGenPro.ModelWithChildren
{
    [TestClass]
    public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLineEntity, ProductEntity>
    {
        protected override IModelWithChildrenScenario<ProductLineEntity, ProductEntity> GetScenario()
        {
            return new ModelWithChildrenScenario();
        }
    }
}
