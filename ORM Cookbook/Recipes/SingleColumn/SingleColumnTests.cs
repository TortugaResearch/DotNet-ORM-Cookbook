namespace Recipes.SingleColumn;

/// <summary>
/// This scenario reads single values from a row.
/// </summary>
[TestCategory("SingleColumn")]
public abstract class SingleColumnTests
{
    const int MaxDivisionKey = 100;

    [TestMethod]
    public void GetDivisionKeys()
    {
        var repository = GetScenario();
        var list = repository.GetDivisionKeys(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
        Assert.IsTrue(list.All(x => 0 < x && x < MaxDivisionKey), "Key out of range");
    }

    [TestMethod]
    public void GetDivisionNames()
    {
        var repository = GetScenario();
        var list = repository.GetDivisionNames(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
        Assert.IsTrue(list.All(x => !string.IsNullOrEmpty(x)), "Null or empty name detected");
    }

    [TestMethod]
    public void GetLastReviewCycles()
    {
        var repository = GetScenario();
        var list = repository.GetLastReviewCycles(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
    }

    [TestMethod]
    public void GetMaxEmployees()
    {
        var repository = GetScenario();
        var list = repository.GetMaxEmployees(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
    }

    [TestMethod]
    public void GetModifiedDates()
    {
        var repository = GetScenario();
        var list = repository.GetModifiedDates(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
    }

    [TestMethod]
    public void GetSalaryBudgets()
    {
        var repository = GetScenario();
        var list = repository.GetSalaryBudgets(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
    }

    [TestMethod]
    public void GetStartTimes()
    {
        var repository = GetScenario();
        var list = repository.GetStartTimes(MaxDivisionKey);
        Assert.IsTrue(0 < list.Count && list.Count < MaxDivisionKey, "Count out of range");
    }

    protected abstract ISingleColumnScenario GetScenario();
}