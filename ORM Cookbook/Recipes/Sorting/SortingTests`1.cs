namespace Recipes.Sorting;

/// <summary>
/// This scenario performs basic CRUD operations on a model containing a foreign key represented by an integer.
/// </summary>
/// <typeparam name="TEmployeeSimple">An Employee model or entity</typeparam>
[TestCategory("Sorting")]
public abstract class SortingTests<TEmployeeSimple> : TestBase
where TEmployeeSimple : class, IEmployeeSimple, new()
{
    const int RowCount = 10;

    [TestMethod]
    public void SortByFirstName()
    {
        var repository = GetScenario();

        //Ensure some records exist
        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var results = repository.SortByFirstName(batchKey);
        for (var i = 1; i < results.Count; i++)
        {
            Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].FirstName, results[i].FirstName, StringComparison.OrdinalIgnoreCase));
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

        var results = repository.SortByMiddleNameDescFirstName(batchKey);
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

        var results = repository.SortByMiddleNameFirstName(batchKey);
        for (var i = 1; i < results.Count; i++)
        {
            Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].MiddleName, results[i].MiddleName, StringComparison.OrdinalIgnoreCase));
            if (string.Equals(results[i - 1].MiddleName, results[i].MiddleName, StringComparison.OrdinalIgnoreCase))
            {
                Assert.IsLessThanOrEqualTo(0, string.Compare(results[i - 1].FirstName, results[i].FirstName, StringComparison.OrdinalIgnoreCase));
            }
        }
    }

    protected abstract ISortingScenario<TEmployeeSimple> GetScenario();

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