using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Recipes.DiscoverTablesAndColumns;

/// <summary>
/// This scenario reads from stored procedures
/// </summary>
[TestCategory("DiscoverTablesAndColumns")]
public abstract class DiscoverTablesAndColumnsTests
{
    [TestMethod]
    public void ListColumnsInTable()
    {
        var repository = GetScenario();
        var columnList = repository.ListColumnsInTable("Production", "ProductLine");
        Assert.Contains("ProductLineKey", columnList);
        Assert.Contains("ProductLineName", columnList);
        Assert.HasCount(2, columnList);
    }

    [TestMethod]
    public void ListColumnsInView()
    {
        var repository = GetScenario();
        var columnList = repository.ListColumnsInView("HR", "DepartmentDetail");
        Assert.Contains("DepartmentKey", columnList);
        Assert.Contains("DepartmentName", columnList);
        Assert.Contains("DivisionKey", columnList);
        Assert.Contains("DivisionName", columnList);
        Assert.HasCount(4, columnList);
    }

    [TestMethod]
    public void ListTables()
    {
        var repository = GetScenario();
        var tableList = repository.ListTables();

        //Normalize with no escaping to make writing the test easier.
        var cleanTableList = tableList.Select(n => n.Replace("[", "]"));

        //Check a few of the tables. No need to list them all.
        Assert.IsTrue(cleanTableList.Contains("Production.ProductLine"));
        Assert.IsTrue(cleanTableList.Contains("HR.Department"));

        //Special case 'dbo' because some ORMs may omit the schema
        Assert.IsTrue(cleanTableList.Contains("dbo.SampleTable") || cleanTableList.Contains("SampleTable"));

        //Make sure there are no views
        Assert.IsFalse(cleanTableList.Contains("HR.DepartmentDetail"));
    }

    [TestMethod]
    public void ListViews()
    {
        var repository = GetScenario();
        var viewList = repository.ListViews();

        //Normalize with no escaping to make writing the test easier.
        var cleanTableList = viewList.Select(n => n.Replace("[", "]"));

        //Check a few of the views. No need to list them all.
        Assert.IsTrue(cleanTableList.Contains("HR.DepartmentDetail"));
        Assert.IsTrue(cleanTableList.Contains("HR.EmployeeDetail"));

        //Make sure there are no tables
        Assert.IsFalse(cleanTableList.Contains("HR.Department"));
    }

    protected abstract IDiscoverTablesAndColumnsScenario GetScenario();
}
