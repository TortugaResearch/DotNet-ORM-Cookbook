namespace Recipes.TryCrud;

/// <summary>
/// This scenario performs basic CRUD operations on a simple model without children.
/// </summary>
/// <typeparam name="TModel">A EmployeeClassification model or entity</typeparam>
[TestCategory("TryCrud")]
public abstract class TryCrudTests<TModel> : TestBase
    where TModel : class, IEmployeeClassification, new()
{
    [TestMethod]
    public void DeleteByKeyOrException()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        //first try should pass
        repository.DeleteByKeyOrException(original.EmployeeClassificationKey);

        //second try should fail because it is already deleted
        AssertThrowsException(() => repository.DeleteByKeyOrException(original.EmployeeClassificationKey));
    }

    [TestMethod]
    public void DeleteByKeyWithStatus()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        //first try should pass
        Assert.IsTrue(repository.DeleteByKeyWithStatus(original.EmployeeClassificationKey));

        //second try should fail because it is already deleted
        Assert.IsFalse(repository.DeleteByKeyWithStatus(original.EmployeeClassificationKey));
    }

    [TestMethod]
    public void DeleteOrException()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        //first try should pass
        repository.DeleteOrException(original);

        //second try should fail because it is already deleted
        AssertThrowsException(() => repository.DeleteOrException(original));
    }

    [TestMethod]
    public void DeleteWithStatus()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        //first try should pass
        Assert.IsTrue(repository.DeleteWithStatus(original));

        //second try should fail because it is already deleted
        Assert.IsFalse(repository.DeleteWithStatus(original));
    }

    /// <summary>
    /// Try to read a row that doesn't exist.
    /// </summary>
    [TestMethod]
    public void FindByNameOrException_Fail()
    {
        var repository = GetScenario();

        AssertThrowsException(() => repository.FindByNameOrException("XXX"));
    }

    /// <summary>
    /// Create and read back a row.
    /// </summary>
    [TestMethod]
    public void FindByNameOrException_Pass()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        var result = repository.FindByNameOrException(original.EmployeeClassificationName!);
        AssertMatch(original, result);
    }

    /// <summary>
    /// Try to read a row that doesn't exist.
    /// </summary>
    [TestMethod]
    public void FindByNameOrNull_Fail()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);
        var result = repository.FindByNameOrNull("XXX");
        Assert.IsNull(result);
    }

    /// <summary>
    /// Create and read back a row.
    /// </summary>
    [TestMethod]
    public void FindByNameOrNull_Pass()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        var result = repository.FindByNameOrNull(original.EmployeeClassificationName!);
        AssertMatch(original, result);
    }

    /// <summary>
    /// Try to read a row that doesn't exist.
    /// </summary>
    [TestMethod]
    public void GetByKeyOrException_Fail()
    {
        var repository = GetScenario();

        AssertThrowsException(() => repository.GetByKeyOrException(-1));
    }

    /// <summary>
    /// Create and read back a row.
    /// </summary>
    [TestMethod]
    public void GetByKeyOrException_Pass()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        var result = repository.GetByKeyOrException(original.EmployeeClassificationKey);
        AssertMatch(original, result);
    }

    /// <summary>
    /// Try to read a row that doesn't exist.
    /// </summary>
    [TestMethod]
    public void GetByKeyOrNull_Fail()
    {
        var repository = GetScenario();

        var result = repository.GetByKeyOrNull(-1);
        Assert.IsNull(result);
    }

    /// <summary>
    /// Create and read back a row.
    /// </summary>
    [TestMethod]
    public void GetByKeyOrNull_Pass()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        var result = repository.GetByKeyOrNull(original.EmployeeClassificationKey);
        AssertMatch(original, result);
    }

    [TestMethod]
    public void UpdateOrException_Fail()
    {
        var repository = GetScenario();

        var original = new TModel()
        {
            EmployeeClassificationKey = -1,
            EmployeeClassificationName = "Fake " + DateTime.Now.Ticks
        };

        Assert.IsNull(repository.GetByKeyOrNull(original.EmployeeClassificationKey)); //make sure the row doesn't exist

        AssertThrowsException(() => repository.UpdateOrException(original));
    }

    [TestMethod]
    public void UpdateOrException_Pass()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        var echo = repository.GetByKeyOrException(original.EmployeeClassificationKey);
        AssertMatch(original, echo);

        echo.EmployeeClassificationName = "Updated " + DateTime.Now.Ticks;

        repository.UpdateOrException(echo);
    }

    [TestMethod]
    public void UpdateWithStatus_Fail()
    {
        var repository = GetScenario();

        var original = new TModel()
        {
            EmployeeClassificationKey = -1,
            EmployeeClassificationName = "Fake " + DateTime.Now.Ticks
        };

        Assert.IsNull(repository.GetByKeyOrNull(original.EmployeeClassificationKey)); //make sure the row doesn't exist

        Assert.IsFalse(repository.UpdateWithStatus(original));
    }

    [TestMethod]
    public void UpdateWithStatus_Pass()
    {
        var repository = GetScenario();

        var original = CreateRow(repository);

        var echo = repository.GetByKeyOrException(original.EmployeeClassificationKey);
        AssertMatch(original, echo);

        echo.EmployeeClassificationName = "Updated " + DateTime.Now.Ticks;

        Assert.IsTrue(repository.UpdateWithStatus(echo));
    }

    protected abstract ITryCrudScenario<TModel> GetScenario();

    static void AssertMatch(TModel original, TModel? result)
    {
        Assert.IsNotNull(result);
        Assert.AreEqual(original.EmployeeClassificationKey, result!.EmployeeClassificationKey);
        Assert.AreEqual(original.EmployeeClassificationName, result!.EmployeeClassificationName);
    }

    static TModel CreateRow(ITryCrudScenario<TModel> repository)
    {
        var newRecord = new TModel();
        newRecord.EmployeeClassificationName = "Test " + DateTime.Now.Ticks;
        var newKey = repository.Create(newRecord);
        Assert.IsGreaterThanOrEqualTo(1000, newKey, "keys under 1000 were not generated by the database");
        newRecord.EmployeeClassificationKey = newKey; //not all repositories update the original object
        return newRecord;
    }
}