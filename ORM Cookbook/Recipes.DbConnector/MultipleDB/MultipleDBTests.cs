using Recipes.DbConnector.Models;
using Recipes.MultipleDB;

namespace Recipes.DbConnector.MultipleDB;

[TestClass]
public class MultipleDBTests : MultipleDBTests<EmployeeClassification>
{
    protected override IMultipleDBScenario<EmployeeClassification> GetScenario(DatabaseType databaseType)
    {
        var connectionString = databaseType switch
        {
            DatabaseType.SqlServer => Setup.SqlServerConnectionString,
            DatabaseType.PostgreSql => Setup.PostgreSqlConnectionString,
            _ => throw new NotImplementedException()
        };
        return new MultipleDBScenario(connectionString, databaseType);
    }
}