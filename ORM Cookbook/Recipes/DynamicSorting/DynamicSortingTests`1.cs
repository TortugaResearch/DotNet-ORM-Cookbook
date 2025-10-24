using System.Diagnostics;

namespace Recipes.DynamicSorting;

/// <summary>
/// This scenario performs basic CRUD operations on a model containing a foreign key represented by an integer.
/// </summary>
/// <typeparam name="TEmployeeSimple">An Employee model or entity</typeparam>
[TestCategory("DynamicSorting")]
public abstract class DynamicSortingTests<TEmployeeSimple> : TestBase
where TEmployeeSimple : class, IEmployeeSimple, new()
{
    const int RowCount = 10;

    [TestMethod]
    [DataRow("ProductName")]
    [DataRow("; --")]
    [DataRow("FirstName]; --")]
    [DataRow("Count(*)")]
    [DataRow("AND 1 = 1")]
    public void SortByNonExistentColumn(string columnName)
    {
        var repository = GetScenario();

        //Ensure some records exist
        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        string? failureMessage = null;

        try
        {
            var results = repository.SortBy(batchKey, columnName, false);
            failureMessage = "An exception was expected for the non-existent sort column.";
        }
        catch (Exception ex) when (ex.GetType().Name == "SqlException")
        {
            failureMessage = "A SqlException was caught, suggesting that it tried to execute the query with a non-existent sort column.";
            Debug.Write("Exception details: " + ex.ToString());
        }
        catch (Exception ex)
        {
            Debug.Write("Exception details: " + ex.ToString());
        }

        if (failureMessage != null)
            Assert.Fail(failureMessage);
    }

    [TestMethod]
    public void SortByFirstName()
    {
        var repository = GetScenario();

        //Ensure some records exist
        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var results = repository.SortBy(batchKey, "FirstName", false);
        for (var i = 1; i < results.Count; i++)
        {
            Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].FirstName, results[i].FirstName, StringComparison.OrdinalIgnoreCase));
        }
    }

    [TestMethod]
    public void SortByFirstNameDescending()
    {
        var repository = GetScenario();

        //Ensure some records exist
        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var results = repository.SortBy(batchKey, "FirstName", true);
        for (var i = 1; i < results.Count; i++)
        {
            Assert.IsGreaterThanOrEqualTo(0, string.Compare(results[i - 1].FirstName, results[i].FirstName, StringComparison.OrdinalIgnoreCase));
        }
    }

    [TestMethod]
    public void SortByMiddleNameDescFirstName()
    {
        var repository = GetScenario();

        //Ensure some records exist
        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var results = repository.SortBy(batchKey, "MiddleName", true, "FirstName", false);
        for (var i = 1; i < results.Count; i++)
        {
            Assert.IsGreaterThanOrEqualTo(0, string.Compare(results[i - 1].MiddleName, results[i].MiddleName, StringComparison.OrdinalIgnoreCase));
            if (string.Equals(results[i - 1].MiddleName, results[i].MiddleName, StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].FirstName, results[i].FirstName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }

    [TestMethod]
    public void SortByMiddleNameFirstName()
    {
        var repository = GetScenario();

        //Ensure some records exist
        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var results = repository.SortBy(batchKey, "MiddleName", false, "FirstName", false);
        for (var i = 1; i < results.Count; i++)
        {
            Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].MiddleName, results[i].MiddleName, StringComparison.OrdinalIgnoreCase));
            if (string.Equals(results[i - 1].MiddleName, results[i].MiddleName, StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].FirstName, results[i].FirstName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }

    protected abstract IDynamicSortingScenario<TEmployeeSimple> GetScenario();

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