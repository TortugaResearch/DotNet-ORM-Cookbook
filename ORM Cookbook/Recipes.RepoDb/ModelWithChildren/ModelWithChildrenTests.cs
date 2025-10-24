using Recipes.ModelWithChildren;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.ConnectionString);
    }
}