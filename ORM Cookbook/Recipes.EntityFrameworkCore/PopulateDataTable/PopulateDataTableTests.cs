using Recipes.PopulateDataTable;

namespace Recipes.EntityFrameworkCore.PopulateDataTable;

[TestClass]
public class PopulateDataTableTests : Recipes.PopulateDataTable.PopulateDataTableTests
{
    protected override IPopulateDataTableScenario GetScenario()
    {
        return new PopulateDataTableScenario(Setup.DBContextFactory);
    }
}

[TestClass]
public class PopulateDataTableTests2 : Recipes.PopulateDataTable.PopulateDataTableTests
{
    protected override IPopulateDataTableScenario GetScenario()
    {
        return new PopulateDataTableScenario2(Setup.DBContextFactory);
    }
}