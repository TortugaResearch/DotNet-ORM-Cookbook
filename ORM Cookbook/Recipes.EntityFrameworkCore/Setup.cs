using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.EntityFrameworkCore.Entities.Conventions;

[assembly: DoNotParallelize]

namespace Recipes.EntityFrameworkCore
{
    [TestClass]
    public class Setup
    {
        internal static Func<OrmCookbookContext> DBContextFactory { get; private set; } = null!;
        internal static Func<int, OrmCookbookContextWithQueryFilter> DBContextWithFilter { get; private set; } = null!;
        internal static Func<User, OrmCookbookContextWithUser> DBContextWithUserFactory { get; private set; } = null!;
        internal static Func<OrmCookbookContextWithSoftDelete> DBContextWithSoftDelete { get; private set; } = null!;
        internal static Func<OrmCookbookContext> LazyLoadingDBContextFactory { get; private set; } = null!;
        internal static string SqlServerConnectionString { get; private set; } = null!;
        internal static string PostgreSqlConnectionString { get; private set; } = null!;
        internal static Func<OrmCookbookContext> PostgreSqlDBContextFactory { get; private set; } = null!;

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
            SqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"]!;
            PostgreSqlConnectionString = configuration.GetSection("ConnectionStrings")["PostgreSqlTestDatabase"]!;

            {
                var options = new DbContextOptionsBuilder<OrmCookbookContext>().UseSqlServer(SqlServerConnectionString).Options;
                DBContextFactory = () => new OrmCookbookContext(options);
                DBContextWithUserFactory = (User u) => new OrmCookbookContextWithUser(options, u);
                DBContextWithFilter = (int schoolId) => new OrmCookbookContextWithQueryFilter(options, schoolId);
                DBContextWithSoftDelete = () => new OrmCookbookContextWithSoftDelete(options);
            }

            {
                var options2 = new DbContextOptionsBuilder<OrmCookbookContext>().UseLazyLoadingProxies().UseSqlServer(SqlServerConnectionString).Options;
                LazyLoadingDBContextFactory = () => new OrmCookbookContext(options2);
            }

            {
                var options3 = new DbContextOptionsBuilder<OrmCookbookContext>().UseNpgsql(PostgreSqlConnectionString).Options;
                PostgreSqlDBContextFactory = () => new OrmCookbookContext(options3, new LowerCaseConverter());
            }

            try
            {
                (new Setup()).Warmup_SqlServer();
            }
            catch { }

#if !EFCore5
        //This relies on SetColumnName, which was broken in EF Core 5.
          try
            {
                (new Setup()).Warmup_PostgreSql();
            }
            catch { }
#endif
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
                context.Employees.Add(e);
                context.SaveChanges();
            }
            using (var context = DBContextFactory())
            {
                var cl = context.EmployeeClassifications.Where(e => e.EmployeeClassificationKey == 2).Include(e => e.Employees).Single();
                Assert.AreNotEqual(0, cl.Employees.Count);
            }
            using (var context = LazyLoadingDBContextFactory())
            {
                var cl = context.EmployeeClassifications.Where(e => e.EmployeeClassificationKey == 2).Single();
                Assert.AreNotEqual(0, cl.Employees.Count);
            }
        }

        [TestMethod]
        public void Warmup_SqlServer()
        {
            //Touch all of the models to warmup the DBContext.
            using (var context = DBContextFactory())
            {
                context.Departments.FirstOrDefault();
                context.DepartmentDetails.FirstOrDefault();
                context.Employees.FirstOrDefault();
                context.EmployeeClassifications.FirstOrDefault();
                context.Students.FirstOrDefault();
            }
        }

#if !EFCore5
        //This relies on SetColumnName, which was broken in EF Core 5.
        [TestMethod]
        public void Warmup_PostgreSql()
        {
            //Touch all of the models to warmup the DBContext.
            using (var context = PostgreSqlDBContextFactory())
            {
                context.Departments.FirstOrDefault();
                context.DepartmentDetails.FirstOrDefault();
                context.Employees.FirstOrDefault();
                context.EmployeeClassifications.FirstOrDefault();
            }
        }
#endif
    }
}