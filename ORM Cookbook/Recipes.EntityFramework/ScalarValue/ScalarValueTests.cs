using Recipes.ScalarValue;

namespace Recipes.EntityFramework.ScalarValue;

[TestClass]
public class ScalarValueTests : Recipes.ScalarValue.ScalarValueTests
{
    protected override IScalarValueScenario GetScenario()
    {
        return new ScalarValueScenario(Setup.DBContextFactory);
    }
}