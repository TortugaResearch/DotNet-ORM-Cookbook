using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Diagnostics.CodeAnalysis;

using NHibernateCfg = NHibernate.Cfg;

[assembly: DoNotParallelize]

namespace Recipes.NHibernate
{
    [TestClass]
    public class Setup
    {
#nullable disable
        internal static ISessionFactory SessionFactory { get; private set; }
#nullable enable

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            ConfigureSessionFactory();
        }

        [TestMethod]
        public void Warmup()
        {
            //Make sure we can connect to the database. This will also pool a connection for future use.
            using (var session = SessionFactory.OpenSession())
            {
                Assert.IsTrue(session.IsOpen);
            }
        }

        private static void ConfigureSessionFactory()
        {
            var jsonConfiguration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();
            var sqlServerConnectionString = jsonConfiguration.GetSection("ConnectionStrings")["SqlServerTestDatabase"];

            var configuration = new Configuration();
            configuration.Configure();

            configuration.SetProperty(NHibernateCfg.Environment.ConnectionString, sqlServerConnectionString);

            configuration.AddAssembly(typeof(Setup).Assembly);
            SessionFactory = configuration.BuildSessionFactory();

            try
            {
                (new Setup()).Warmup();
            }
            catch { }
        }
    }
}
