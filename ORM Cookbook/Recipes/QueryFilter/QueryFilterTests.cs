using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Recipes.QueryFilter
{
    [TestCategory("QueryFilter")]
    public abstract class QueryFilterTests<TStudent> : TestBase
        where TStudent : class, IStudent, new()
    {
        [TestMethod]
        public void VerifyThatSchoolCanNotGetOtherSchoolsData()
        {
            // Arrange.
            var repository = GetScenario();
            var originals = BuildStudents();
            repository.InsertBatch(originals);

            // Act.
            var schoolId = 2;
            var students = repository.GetStudents(schoolId);

            // Assert.
            Assert.AreEqual(2, students.Count);

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

        static IList<TStudent> BuildStudents()
        {
            var result = new List<TStudent>
            {
                new TStudent { StudentId = 1, Name = "n1", Subject = "s1", SchoolId = 1 },
                new TStudent { StudentId = 2, Name = "n2", Subject = "s2", SchoolId = 1 },
                new TStudent { StudentId = 3, Name = "n3", Subject = "s3", SchoolId = 2 },
                new TStudent { StudentId = 4, Name = "n4", Subject = "s4", SchoolId = 2 }
            };
            return result;
        }
    }
}
