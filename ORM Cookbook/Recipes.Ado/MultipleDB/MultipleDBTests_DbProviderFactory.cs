using Recipes.Ado.Models;
using Recipes.MultipleDB;

namespace Recipes.Ado.MultipleDB;

[TestClass]
public class MultipleDBTests_DbProviderFactory : MultipleDBTests<EmployeeClassification>
{
    protected override IMultipleDBScenario<EmployeeClassification> GetScenario(DatabaseType databaseType)
    {
        var connectionString = databaseType switch
        {
            DatabaseType.SqlServer => Setup.SqlServerConnectionString,
            DatabaseType.PostgreSql => Setup.PostgreSqlConnectionString,
            _ => throw new NotImplementedException()
        };
        return new MultipleDBScenario_DbProviderFactory(connectionString, databaseType);
    }
}