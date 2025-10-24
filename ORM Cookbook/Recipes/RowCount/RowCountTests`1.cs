namespace Recipes.RowCount;

/// <summary>
/// This scenario gets the row counts from a table
/// </summary>
/// <typeparam name="TEmployeeSimple">An Employee model or entity</typeparam>
[TestCategory("RowCount")]
public abstract class RowCountTests<TEmployeeSimple> : TestBase
where TEmployeeSimple : class, IEmployeeSimple, new()
{
    const int RowCount = 25;

    [TestMethod]
    public void EmployeeCount()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);
        var count = repository.EmployeeCount();
        Assert.AreNotEqual(0, count);
    }

    [TestMethod]
    public void EmployeeCountFiltered()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);
        var count = repository.EmployeeCount(batchKey);
        Assert.AreEqual(25, count);
    }

    protected abstract IRowCountScenario<TEmployeeSimple> GetScenario();

    static IList<TEmployeeSimple> BuildEmployees(int count, string batchKey)
    {
        var result = new List<TEmployeeSimple>();
        for (var i = 0; i < count; i++)
        {
            result.Add(new TEmployeeSimple
            {
                FirstName = "Test " + (i % 3),
                MiddleName = "A" + i,
                LastName = batchKey,
                EmployeeClassificationKey = (i % 7) + 1
            });
        }
        return result;
    }
}