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
        internal static Func<OrmCookbookContext> DBContextFactory { get; private set; } = null!;
        internal static Func<User, OrmCookbookContextWithUser> DBContextWithUserFactory { get; private set; } = null!;
        internal static Func<OrmCookbookContextWithSoftDelete> DBContextWithSoftDelete { get; private set; } = null!;
        internal static Func<OrmCookbookContext> LazyLoadingDBContextFactory { get; private set; } = null!;
        internal static string SqlServerConnectionString { get; private set; } = null!;

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
            SqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"];

            var options = new DbContextOptionsBuilder<OrmCookbookContext>().UseSqlServer(SqlServerConnectionString).Options;
            DBContextFactory = () => new OrmCookbookContext(options);
            DBContextWithUserFactory = (User u) => new OrmCookbookContextWithUser(options, u);
            DBContextWithSoftDelete = () => new OrmCookbookContextWithSoftDelete(options);

            var options2 = new DbContextOptionsBuilder<OrmCookbookContext>().UseLazyLoadingProxies().UseSqlServer(SqlServerConnectionString).Options;
            LazyLoadingDBContextFactory = () => new OrmCookbookContext(options2);

            try
            {
                (new Setup()).Warmup();
            }
            catch { }
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
