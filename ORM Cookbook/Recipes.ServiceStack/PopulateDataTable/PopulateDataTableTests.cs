using Recipes.PopulateDataTable;

namespace Recipes.ServiceStack.PopulateDataTable;

[TestClass]
public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
{
    protected override IPopulateDataTableScenario GetScenario()
    {
        return new PopulateDataTableScenario(Setup.DbConnectionFactory);
    }
}

[TestClass]
public class PopulateDataTableTests2 : Recipes.PopulateDataTable.PopulateDataTableTests
{
    protected override IPopulateDataTableScenario GetScenario()
    {
        return new PopulateDataTableScenario2(Setup.DbConnectionFactory);
    }
}