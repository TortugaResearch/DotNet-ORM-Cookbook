﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Entities;
using Recipes.TryCrud;

namespace Recipes.RepoDb.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudScenario<EmployeeClassification> GetScenario()
        {
            return new TryCrudScenario(Setup.ConnectionString);
        }
    }
}
