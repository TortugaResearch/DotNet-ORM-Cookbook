using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Recipes.EntityFrameworkCore
{
    [TestClass]
    public class Setup
    {
#nullable disable
        internal static Func<OrmCookbookContext> DBContextFactory { get; private set; }
#nullable enable

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var con = configuration.GetSection("ConnectionStrings").GetChildren().Single();
            var options = new DbContextOptionsBuilder<OrmCookbookContext>().UseSqlServer(con.Value).Options;

            DBContextFactory = () => new OrmCookbookContext(options);
        }

        [TestMethod]
        public void Warmup()
        {
            //Touch all of the models to warmup the DBContext.
            using (var context = DBContextFactory())
            {
                context.Department.FirstOrDefault();
                context.DepartmentDetail.FirstOrDefault();
                context.Employee.FirstOrDefault();
                context.EmployeeClassification.FirstOrDefault();
            }
        }
    }
}
