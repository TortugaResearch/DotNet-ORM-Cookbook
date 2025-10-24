using System.Data;

namespace Recipes.PopulateDataTable;

/// <summary>
/// This scenario is for populating a DataTable.
/// </summary>
[TestCategory("PopulateDataTable")]
public abstract class PopulateDataTableTests : TestBase

{
    [DataRow(false, false)]
    [DataRow(false, true)]
    [DataRow(true, false)]
    [DataRow(true, true)]
    [TestMethod]
    public void FindByFlags(bool isExempt, bool isEmployee)
    {
        var repository = GetScenario();

        var dt = repository.FindByFlags(isExempt, isEmployee);
        Assert.IsNotNull(dt);
        Assert.AreNotEqual(0, dt.Rows.Count);

        foreach (var row in dt.AsEnumerable())
        {
            Assert.IsNotNull(row["EmployeeClassificationName"]);
            Assert.AreNotEqual(DBNull.Value, row["EmployeeClassificationName"]);

            Assert.AreEqual(isExempt, (bool)row["IsExempt"]);
            Assert.AreEqual(isEmployee, (bool)row["IsEmployee"]);
        }
    }

    /// <summary>
    /// Get all rows from a table.
    /// </summary>
    [TestMethod]
    public void GetAll()
    {
        var repository = GetScenario();

        var dt = repository.GetAll();
        Assert.IsNotNull(dt);
        Assert.AreNotEqual(0, dt.Rows.Count);

        var row1 = dt.AsEnumerable().SingleOrDefault(x => (int)x["EmployeeClassificationKey"] == 1);
        Assert.IsNotNull(row1);
        Assert.AreEqual(1, (int)(row1!["EmployeeClassificationKey"]));
        Assert.AreEqual("Full Time Salary", (string)(row1["EmployeeClassificationName"]));

        var row4 = dt.AsEnumerable().SingleOrDefault(x => (int)x["EmployeeClassificationKey"] == 4);
        Assert.IsNotNull(row4);
        Assert.AreEqual(4, (int)(row4!["EmployeeClassificationKey"]));
        Assert.AreEqual("Contractor", (string)(row4["EmployeeClassificationName"]));
    }

    protected abstract IPopulateDataTableScenario GetScenario();
}