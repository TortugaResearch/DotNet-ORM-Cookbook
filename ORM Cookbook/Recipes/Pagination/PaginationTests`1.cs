namespace Recipes.Pagination;

/// <summary>
/// This scenario performs pagination using both skip/take and page/page size.
/// </summary>
/// <typeparam name="TEmployeeSimple">An Employee model or entity</typeparam>
[TestCategory("Pagination")]
public abstract class PaginationTests<TEmployeeSimple> : TestBase
where TEmployeeSimple : class, IEmployeeSimple, new()
{
    const int RowCount = 25;

    [TestMethod]
    public void PaginateWithPageSize_Overrun()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var count = 0;
        var page = 0;
        const int pageSize = 10;
        IList<TEmployeeSimple> lastSet;

        do
        {
            lastSet = repository.PaginateWithPageSize(batchKey, page, pageSize);
            count += lastSet.Count;
            page += 1;
        } while (lastSet.Count > 0);

        Assert.AreEqual(25, count);
        Assert.AreEqual(4, page); //one page of over-run
    }

    [TestMethod]
    public void PaginateWithPageSize_RowCount()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var expectedCount = 25; //pretend you asked the database for this number
        var count = 0;
        var page = 0;
        const int pageSize = 10;
        IList<TEmployeeSimple> lastSet;

        do
        {
            lastSet = repository.PaginateWithPageSize(batchKey, page, pageSize);
            count += lastSet.Count;
            page += 1;
        } while (count < expectedCount);

        Assert.AreEqual(25, count);
        Assert.AreEqual(3, page); //no over-run
    }

    [TestMethod]
    public void PaginateWithSkipPast_Overrun()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var count = 0;
        var page = 0;
        const int take = 10;
        IList<TEmployeeSimple>? lastSet = null;

        do
        {
            var skipPast = lastSet?.Last();
            lastSet = repository.PaginateWithSkipPast(batchKey, skipPast, take);
            count += lastSet.Count;
            page += 1;
        } while (lastSet.Count > 0);

        Assert.AreEqual(25, count);
        Assert.AreEqual(4, page); //one page of over-run
    }

    [TestMethod]
    public void PaginateWithSkipPast_RowCount()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var expectedCount = 25; //pretend you asked the database for this number
        var count = 0;
        var page = 0;
        const int take = 10;
        IList<TEmployeeSimple>? lastSet = null;

        do
        {
            var skipPast = lastSet?.Last();
            lastSet = repository.PaginateWithSkipPast(batchKey, skipPast, take);
            count += lastSet.Count;
            page += 1;
        } while (count < expectedCount);

        Assert.AreEqual(25, count);
        Assert.AreEqual(3, page); //no over-run
    }

    [TestMethod]
    public void PaginateWithSkipTake_Overrun()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var count = 0;
        var page = 0;
        const int pageSize = 10;
        IList<TEmployeeSimple> lastSet;

        do
        {
            lastSet = repository.PaginateWithSkipTake(batchKey, page * pageSize, pageSize);
            count += lastSet.Count;
            page += 1;
        } while (lastSet.Count > 0);

        Assert.AreEqual(25, count);
        Assert.AreEqual(4, page); //one page of over-run
    }

    [TestMethod]
    public void PaginateWithSkipTake_RowCount()
    {
        var repository = GetScenario();

        var batchKey = Guid.NewGuid().ToString();
        var originals = BuildEmployees(RowCount, batchKey);
        repository.InsertBatch(originals);

        var expectedCount = 25; //pretend you asked the database for this number
        var count = 0;
        var page = 0;
        const int pageSize = 10;
        IList<TEmployeeSimple> lastSet;

        do
        {
            lastSet = repository.PaginateWithSkipTake(batchKey, page * pageSize, pageSize);
            count += lastSet.Count;
            page += 1;
        } while (count < expectedCount);

        Assert.AreEqual(25, count);
        Assert.AreEqual(3, page); //no over-run
    }

    protected abstract IPaginationScenario<TEmployeeSimple> GetScenario();

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