using System.Diagnostics.CodeAnalysis;

namespace Recipes.BulkInsert;

/// <summary>
/// This scenario works with collections of objects.
/// </summary>
[TestCategory("BulkInsert")]
public abstract class BulkInsertTests<TEmployeeSimple> : TestBase
   where TEmployeeSimple : class, IEmployeeSimple, new()
{
    [TestMethod]
    [SuppressMessage("Reliability", "CA2000")]
    public void BulkInsert_DataTable_1_000()
    {
        const int RowCount = 1_000;
        var repostory = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        var dt = Utilities.CopyToDataTable(originals);
        repostory.BulkInsert(dt);

        var actual = repostory.CountByLastName(batchKey);
        Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
    }

    [TestMethod]
    [SuppressMessage("Reliability", "CA2000")]
    public void BulkInsert_DataTable_10_000()
    {
        const int RowCount = 10_000;
        var repostory = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        var dt = Utilities.CopyToDataTable(originals);
        repostory.BulkInsert(dt);

        var actual = repostory.CountByLastName(batchKey);
        Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
    }

    [TestMethod]
    [SuppressMessage("Reliability", "CA2000")]
    public void BulkInsert_DataTable_100_000()
    {
        const int RowCount = 100_000;
        var repostory = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        var dt = Utilities.CopyToDataTable(originals);
        repostory.BulkInsert(dt);

        var actual = repostory.CountByLastName(batchKey);
        Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
    }

    [TestMethod]
    public void BulkInsert_Objects_1_000()
    {
        const int RowCount = 1_000;
        var repostory = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repostory.BulkInsert(originals);

        var actual = repostory.CountByLastName(batchKey);
        Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
    }

    [TestMethod]
    public void BulkInsert_Objects_10_000()
    {
        const int RowCount = 10_000;
        var repostory = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repostory.BulkInsert(originals);

        var actual = repostory.CountByLastName(batchKey);
        Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
    }

    [TestMethod]
    public void BulkInsert_Objects_100_000()
    {
        const int RowCount = 100_000;
        var repostory = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repostory.BulkInsert(originals);

        var actual = repostory.CountByLastName(batchKey);
        Assert.AreEqual(RowCount, actual, "Incorrect number of rows created");
    }

    protected abstract IBulkInsertScenario<TEmployeeSimple> GetScenario();

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