using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ScalarValue;

namespace Recipes.Xpo.ScalarValue
{
    [TestClass]
    public class ScalarValueTests : Recipes.ScalarValue.ScalarValueTests
    {
        protected override IScalarValueScenario GetScenario()
        {
            return new ScalarValueScenario();
        }
    }
}
