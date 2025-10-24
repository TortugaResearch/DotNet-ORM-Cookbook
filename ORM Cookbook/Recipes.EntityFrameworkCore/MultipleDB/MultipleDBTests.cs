#if !EFCore5
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.MultipleDB;
using System;

//This relies on SetColumnName, which was broken in EF Core 5.

namespace Recipes.EntityFrameworkCore.MultipleDB
{
    [TestClass]
    public class MultipleDBTests : MultipleDBTests<EmployeeClassification>
    {
        protected override IMultipleDBScenario<EmployeeClassification> GetScenario(DatabaseType databaseType)
        {
            var contextFactory = databaseType switch
            {
                DatabaseType.SqlServer => Setup.DBContextFactory,
                DatabaseType.PostgreSql => Setup.PostgreSqlDBContextFactory,
                _ => throw new NotImplementedException()
            };

            return new MultipleDBScenario(contextFactory);
        }
    }
}
#endif