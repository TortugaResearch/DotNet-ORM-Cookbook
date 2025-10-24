using LinqToDB.Configuration;
using LinqToDB.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

[assembly: DoNotParallelize]

namespace Recipes.LinqToDB
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public ConnectionStringSettings(string connectionString, string name, string providerName)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException($"{nameof(connectionString)} is null or empty.", nameof(connectionString));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"{nameof(name)} is null or empty.", nameof(name));

            if (string.IsNullOrEmpty(providerName))
                throw new ArgumentException($"{nameof(providerName)} is null or empty.", nameof(providerName));

            ConnectionString = connectionString;
            Name = name;
            ProviderName = providerName;
        }

        public string ConnectionString { get; }
        public bool IsGlobal => false;
        public string Name { get; }
        public string ProviderName { get; }
    }

    public class MySettings : ILinqToDBSettings
    {
        public List<IConnectionStringSettings> ConnectionStrings { get; } =
        new List<IConnectionStringSettings>();

        IEnumerable<IConnectionStringSettings> ILinqToDBSettings.ConnectionStrings => ConnectionStrings;
        public List<IDataProviderSettings> DataProviders { get; } = new List<IDataProviderSettings>();
        IEnumerable<IDataProviderSettings> ILinqToDBSettings.DataProviders => DataProviders;

        public string DefaultConfiguration => "SqlServer";
        public string DefaultDataProvider => "SqlServer";
    }

    [TestClass]
    public class Setup
    {
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

            var settings = new MySettings();
            settings.ConnectionStrings.Add(new ConnectionStringSettings(sqlServerConnectionString, "OrmCookbook", "SqlServer"));
            DataConnection.DefaultSettings = settings;
        }

        [TestMethod]
        public void Warmup()
        {
            //Make sure we can connect to the database. This will also pool a connection for future use.
            using (var db = new OrmCookbook())
            {
#pragma warning disable CA1806 // Do not ignore method results
                db.EmployeeClassification.ToList();
#pragma warning restore CA1806 // Do not ignore method results
            }
        }
    }
}
