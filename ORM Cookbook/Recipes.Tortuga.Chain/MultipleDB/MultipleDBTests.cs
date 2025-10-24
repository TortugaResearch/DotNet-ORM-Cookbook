using Recipes.Chain.Models;
using Recipes.MultipleDB;
using Tortuga.Chain.DataSources;

namespace Recipes.Chain.MultipleDB;

[TestClass]
public class MultipleDBTests : MultipleDBTests<EmployeeClassification>
{
    protected override IMultipleDBScenario<EmployeeClassification> GetScenario(DatabaseType databaseType)
    {
        ICrudDataSource dataSource = databaseType switch
        {
            DatabaseType.SqlServer => Setup.PrimaryDataSource,
            DatabaseType.PostgreSql => Setup.PostgreSqlDataSource,
            _ => throw new NotImplementedException()
        };
        return new MultipleDBScenario(dataSource);
    }
}