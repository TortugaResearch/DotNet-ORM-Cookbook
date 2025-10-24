namespace Recipes.ScalarValue;

/// <summary>
/// This scenario reads single values from a row.
/// </summary>
[TestCategory("ScalarValue")]
public abstract class ScalarValueTests
{
    [TestMethod]
    [DataRow("HR", 1)]
    [DataRow("VOID", null)]
    public void GetDivisionKey(string divisionName, int? divisionKey)
    {
        var repository = GetScenario();
        Assert.AreEqual(divisionKey, repository.GetDivisionKey(divisionName));
    }

    [TestMethod]
    [DataRow(1, "HR")]
    public void GetDivisionName(int divisionKey, string divisionName)
    {
        var repository = GetScenario();
        Assert.AreEqual(divisionName, repository.GetDivisionName(divisionKey));
    }

    [TestMethod]
    [DataRow(1, "HR")]
    [DataRow(0, null)]
    public void GetDivisionNameOrNull(int divisionKey, string? divisionName)
    {
        var repository = GetScenario();
        Assert.AreEqual(divisionName, repository.GetDivisionNameOrNull(divisionKey));
    }

    [TestMethod]
    [DataRow(1, false)]
    [DataRow(2, false)]
    public void GetLastReviewCycle(int divisionKey, bool nullExpected)
    {
        var repository = GetScenario();
        var result = repository.GetLastReviewCycle(divisionKey);
        if (nullExpected)
            Assert.IsNull(result);
        else
            Assert.AreNotEqual(default(DateTimeOffset), result);
    }

    [TestMethod]
    [DataRow(1, false)]
    [DataRow(2, true)]
    public void GetMaxEmployees(int divisionKey, bool nullExpected)
    {
        var repository = GetScenario();
        var result = repository.GetMaxEmployees(divisionKey);
        if (nullExpected)
            Assert.IsNull(result);
        else
            Assert.AreNotEqual(default(int), result);
    }

    [TestMethod]
    [DataRow(1, false)]
    [DataRow(2, false)]
    public void GetModifiedDate(int divisionKey, bool nullExpected)
    {
        var repository = GetScenario();
        var result = repository.GetModifiedDate(divisionKey);
        //if (nullExpected)
        //    Assert.IsNull(result);
        //else
        Assert.AreNotEqual(default(DateTime), result);
    }

    [TestMethod]
    [DataRow(1, false)]
    [DataRow(2, true)]
    public void GetSalaryBudget(int divisionKey, bool nullExpected)
    {
        var repository = GetScenario();
        var result = repository.GetSalaryBudget(divisionKey);
        if (nullExpected)
            Assert.IsNull(result);
        else
            Assert.AreNotEqual(default(decimal), result);
    }

    [TestMethod]
    [DataRow(1, false)]
    [DataRow(2, true)]
    public void GetStartTime(int divisionKey, bool nullExpected)
    {
        var repository = GetScenario();
        var result = repository.GetStartTime(divisionKey);
        if (nullExpected)
            Assert.IsNull(result);
        else
            Assert.AreNotEqual(default(TimeSpan), result);
    }

    protected abstract IScalarValueScenario GetScenario();
}