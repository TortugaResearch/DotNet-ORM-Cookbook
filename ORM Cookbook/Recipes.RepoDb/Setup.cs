﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDB = RepoDb;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.RepoDB
{
    [TestClass]
    public class Setup
    {
#nullable disable
        internal static string ConnectionString { get; private set; }
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

            ConnectionString = sqlServerConnectionString;

            try
            {
                (new Setup()).Warmup();
            }
            catch { }
        }

        [TestMethod]
        public void Warmup()
        {
            RDB.SqlServerBootstrap.Initialize();

            //Make sure we can connect to the database. This will also pool a connection for future use.
            using (var con = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand("SELECT 1", con))
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
