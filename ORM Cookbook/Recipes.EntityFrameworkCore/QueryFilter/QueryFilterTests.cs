using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.EntityFrameworkCore.QueryFilter
{
    [TestClass]
    public class QueryFilterTests : QueryFilterTests<Student>
    {
        protected override IQueryFilterScenario<Student> GetScenario()
        {
            return new QueryFilterScenario(Setup.DBContextWithFilter);
        }
    }
}
