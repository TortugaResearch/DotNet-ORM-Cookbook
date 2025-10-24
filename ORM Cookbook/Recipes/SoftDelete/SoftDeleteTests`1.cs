namespace Recipes.SoftDelete;

/// <summary>
/// This scenario reads from stored procedures
/// </summary>
[TestCategory("SoftDelete")]
public abstract class SoftDeleteTests<TDepartment>
   where TDepartment : class, IDepartment, new()
{
    [TestMethod]
    public void CreateAndDelete()
    {
        var repository = GetScenario();

        var newRecord = new TDepartment
        {
            DepartmentName = "Department " + DateTime.Now.Ticks.ToString(),
            DivisionKey = 1
        };

        var departmentKey = repository.CreateDepartment(newRecord);

        var version1 = repository.GetDepartment(departmentKey);
        Assert.IsNotNull(version1);
        Assert.AreEqual(newRecord.DepartmentName, version1!.DepartmentName);
        Assert.IsFalse(version1.IsDeleted);

        //Prove that it was soft-deleted
        repository.DeleteDepartment(version1);
        var version2 = repository.GetDepartment(departmentKey);
        Assert.IsNull(version2);

        //Prove that it wasn't hard-deleted
        var version2B = repository.GetDepartmentIgnoringIsDeleted(departmentKey);
        Assert.IsNotNull(version2B);
        Assert.AreEqual(newRecord.DepartmentName, version2B!.DepartmentName);
        Assert.IsTrue(version2B.IsDeleted);
    }

    [TestMethod]
    public void DeleteAndUndelete()
    {
        var repository = GetScenario();

        var newRecord = new TDepartment
        {
            DepartmentName = "Department " + DateTime.Now.Ticks.ToString(),
            DivisionKey = 1
        };

        var departmentKey = repository.CreateDepartment(newRecord);

        var version1 = repository.GetDepartment(departmentKey);
        Assert.IsNotNull(version1);
        Assert.AreEqual(newRecord.DepartmentName, version1!.DepartmentName);
        Assert.IsFalse(version1.IsDeleted);

        //Prove that it was soft-deleted
        repository.DeleteDepartment(version1);
        var version2 = repository.GetDepartment(departmentKey);
        Assert.IsNull(version2);

        //Prove that it wasn't hard-deleted
        var version2B = repository.GetDepartmentIgnoringIsDeleted(departmentKey);
        Assert.IsNotNull(version2B);
        Assert.AreEqual(newRecord.DepartmentName, version2B!.DepartmentName);
        Assert.IsTrue(version2B.IsDeleted);

        repository.UndeleteDepartment(departmentKey);
        var version3 = repository.GetDepartment(departmentKey);
        Assert.IsNotNull(version3);
        Assert.AreEqual(newRecord.DepartmentName, version3!.DepartmentName);
        Assert.IsFalse(version3.IsDeleted);
    }

    [TestMethod]
    public void DeleteAndManuallyUndelete()
    {
        var repository = GetScenario();

        var newRecord = new TDepartment
        {
            DepartmentName = "Department " + DateTime.Now.Ticks.ToString(),
            DivisionKey = 1
        };

        var departmentKey = repository.CreateDepartment(newRecord);

        var version1 = repository.GetDepartment(departmentKey);
        Assert.IsNotNull(version1);
        Assert.AreEqual(newRecord.DepartmentName, version1!.DepartmentName);
        Assert.IsFalse(version1.IsDeleted);

        //Prove that it was soft-deleted
        repository.DeleteDepartment(version1);
        var version2 = repository.GetDepartment(departmentKey);
        Assert.IsNull(version2);

        //Prove that it wasn't hard-deleted
        var version2B = repository.GetDepartmentIgnoringIsDeleted(departmentKey);
        Assert.IsNotNull(version2B);
        Assert.AreEqual(newRecord.DepartmentName, version2B!.DepartmentName);
        Assert.IsTrue(version2B.IsDeleted);

        //Manually undelete
        version1.IsDeleted = false;
        repository.UpdateDepartment(version1);
        var version3 = repository.GetDepartment(departmentKey);
        Assert.IsNotNull(version3);
        Assert.AreEqual(newRecord.DepartmentName, version3!.DepartmentName);
        Assert.IsFalse(version3.IsDeleted);
    }

    protected abstract ISoftDeleteScenario<TDepartment> GetScenario();
}