using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Diagnostics.CodeAnalysis;

[assembly: DoNotParallelize]

namespace Recipes.Ado;

[TestClass]
public class Setup
{
    internal static string SqlServerConnectionString { get; private set; } = null!;
    internal static string PostgreSqlConnectionString { get; private set; } = null!;

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
    }

    [AssemblyInitialize]
    [SuppressMessage("Usage", "CA1801")]
    public static void AssemblyInit(TestContext context)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();

        SqlServerConnectionString = configuration.GetSection("ConnectionStrings")["SqlServerTestDatabase"]!;
        PostgreSqlConnectionString = configuration.GetSection("ConnectionStrings")["PostgreSqlTestDatabase"]!;

        try
        {
            (new Setup()).WarmupSqlServer();
        }
        catch { }
        try
        {
            (new Setup()).WarmupPostgreSql();
        }
        catch { }
    }

    [TestMethod]
    public void WarmupSqlServer()
    {
        //Make sure we can connect to the database. This will also pool a connection for future use.
        using (var con = new SqlConnection(SqlServerConnectionString))
        using (var cmd = new SqlCommand("SELECT 1", con))
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    [TestMethod]
    public void WarmupPostgreSql()
    {
        //Make sure we can connect to the database. This will also pool a connection for future use.
        using (var con = new NpgsqlConnection(PostgreSqlConnectionString))
        using (var cmd = new NpgsqlCommand("SELECT 1", con))
        {
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}