namespace Recipes.QueryFilter;

[TestCategory("QueryFilter")]
public abstract class QueryFilterTests<TStudent> : TestBase
    where TStudent : class, IStudent, new()
{
    [TestMethod]
    public void VerifyThatSchoolCanNotGetOtherSchoolsData()
    {
        // Arrange.
        var repository = GetScenario();

        // Act.
        var schoolId = 2;
        var students = repository.GetStudents(schoolId);

        // Assert.
        Assert.HasCount(2, students);

        Assert.AreEqual(3, students[0].StudentId);
        Assert.AreEqual(4, students[1].StudentId);

        Assert.AreEqual("n3", students[0].Name);
        Assert.AreEqual("n4", students[1].Name);

        Assert.AreEqual("s3", students[0].Subject);
        Assert.AreEqual("s4", students[1].Subject);

        Assert.AreEqual(2, students[0].SchoolId);
        Assert.AreEqual(2, students[1].SchoolId);
    }

    protected abstract IQueryFilterScenario<TStudent> GetScenario();
}