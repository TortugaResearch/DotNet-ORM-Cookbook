using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack
{
    [TestClass]
    public class Setup
    {
        static Lazy<IDbConnectionFactory> DbConnectionFactoryFactory = new Lazy<IDbConnectionFactory>(() =>
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
            var con = configuration.GetSection("ConnectionStrings").GetChildren().Single();
            return new OrmLiteConnectionFactory(con.Value, SqlServerDialect.Provider);
        });

        internal static IDbConnectionFactory DbConnectionFactory => DbConnectionFactoryFactory.Value;

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            try
            {
                new Setup().Warmup();
            }
            catch
            {
            }
        }

        [TestMethod]
        public void Warmup()
        {
            long i = 0;

            //Touch all of the models to validate entity mappings
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                i = db.Count<Department>();
                i += db.Count<Division>();
                i += db.Count<Employee>();
                i += db.Count<EmployeeClassification>();
            }

            Assert.AreNotEqual(0, i);
        }

        [TestMethod]
        public void CheckIncludes()
        {
            var e = new Employee
            {
                EmployeeClassificationId = 2,
                FirstName = "test",
                LastName = "test"
            };
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                using (var tx = db.OpenTransaction())
                {
                    db.Save(e);
                    Assert.AreNotEqual(0, e.Id);
                    tx.Rollback();
                }
            }
        }
    }
}