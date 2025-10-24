using Recipes.DbConnector.Models;
using Recipes.ModelWithChildren;

namespace Recipes.DbConnector.ModelWithChildren;

[TestClass]
public class ModelWithChildrenTests : ModelWithChildrenTests<ProductLine, Product>
{
    protected override IModelWithChildrenScenario<ProductLine, Product> GetScenario()
    {
        return new ModelWithChildrenScenario(Setup.SqlServerConnectionString);
    }
}