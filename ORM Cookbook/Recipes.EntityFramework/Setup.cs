using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Recipes.EntityFramework
{
    [TestClass]
    public class Setup
    {
#nullable disable
        internal static Func<OrmCookbookContext> DBContextFactory { get; private set; }
        internal static Func<OrmCookbookContext> LazyLoadingDBContextFactory { get; private set; }
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
            var sqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"];

            DBContextFactory = () => new OrmCookbookContext(sqlServerConnectionString, false);

            LazyLoadingDBContextFactory = () => new OrmCookbookContext(sqlServerConnectionString, true);

            try
            {
                (new Setup()).Warmup();
            }
            catch { }
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

        [TestMethod]
        public void CheckIncludes()
        {
            var e = new Employee()
            {
                EmployeeClassificationKey = 2,
                FirstName = "test",
                LastName = "test",
            };
            using (var context = DBContextFactory())
            {
                context.Employee.Add(e);
                context.SaveChanges();
            }
            using (var context = DBContextFactory())
            {
                var cl = context.EmployeeClassification.Where(e => e.EmployeeClassificationKey == 2).Include(e => e.Employee).Single();
                Assert.AreNotEqual(0, cl.Employee.Count);
            }
            using (var context = LazyLoadingDBContextFactory())
            {
                var cl = context.EmployeeClassification.Where(e => e.EmployeeClassificationKey == 2).Single();
                Assert.AreNotEqual(0, cl.Employee.Count);
            }
        }
    }
}
