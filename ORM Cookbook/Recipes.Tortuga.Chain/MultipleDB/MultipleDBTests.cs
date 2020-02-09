using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using Recipes.MultipleDB;
using System;
using Tortuga.Chain;

namespace Recipes.Chain.MultipleDB
{
    [TestClass]
    public class MultipleDBTests : MultipleDBTests<EmployeeClassification>
    {
        protected override IMultipleDBScenario<EmployeeClassification> GetScenario(DatabaseType databaseType)
        {
            IClass1DataSource dataSource = databaseType switch
            {
                DatabaseType.SqlServer => Setup.PrimaryDataSource,
                DatabaseType.PostgreSql => Setup.PostgreSqlDataSource,
                _ => throw new NotImplementedException()
            };
            return new MultipleDBScenario(dataSource);
        }
    }
}