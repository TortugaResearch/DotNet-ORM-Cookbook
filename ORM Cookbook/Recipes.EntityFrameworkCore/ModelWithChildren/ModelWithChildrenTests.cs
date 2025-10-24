using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithChildren;

namespace Recipes.EntityFrameworkCore.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.DBContextFactory);
    }
}