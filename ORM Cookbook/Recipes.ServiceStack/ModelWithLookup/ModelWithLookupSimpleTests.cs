using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithLookup;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<Employee>
    {
        protected override IModelWithLookupSimpleScenario<Employee> GetScenario()
        {
            return new ModelWithLookupSimpleScenario(Setup.DbConnectionFactory);
        }
    }
}
