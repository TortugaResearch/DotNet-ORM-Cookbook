using Recipes.NPoco.Models;
using Recipes.ModelWithChildren;

namespace Recipes.NPoco.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.SqlServerConnectionString);
    }
}