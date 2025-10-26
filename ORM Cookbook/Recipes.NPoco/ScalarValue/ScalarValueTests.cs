using Recipes.ScalarValue;

namespace Recipes.NPoco.ScalarValue;

[TestClass]
public class ScalarValueTests : Recipes.ScalarValue.ScalarValueTests
{
    protected override IScalarValueScenario GetScenario()
    {
        return new ScalarValueScenario(Setup.SqlServerConnectionString);
    }
}