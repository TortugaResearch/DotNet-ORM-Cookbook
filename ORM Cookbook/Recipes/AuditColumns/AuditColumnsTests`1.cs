using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace Recipes.AuditColumns
{
    /// <summary>
    /// This scenario reads from stored procedures
    /// </summary>
    [TestCategory("AuditColumns")]
    public abstract class AuditColumnsTests<TDepartment>
       where TDepartment : class, IDepartment, new()
    {
        [TestMethod]
        public void CreateAndUpdate()
        {
            var repository = GetScenario();

            var user1 = new User() { UserKey = 1 };
            var user2 = new User() { UserKey = 2 };

            var newRecord = new TDepartment
            {
                DepartmentName = "Department " + DateTime.Now.Ticks.ToString(),
                DivisionKey = 1
            };

            var departmentKey = repository.CreateDepartment(newRecord, user1);

            var version1 = repository.GetDepartment(departmentKey, user1);
            Assert.AreEqual(newRecord.DepartmentName, version1.DepartmentName);
            Assert.IsNotNull(version1.ModifiedDate);
            Assert.IsNotNull(version1.CreatedDate);
            Assert.AreEqual(user1.UserKey, version1.CreatedByEmployeeKey);
            Assert.AreEqual(user1.UserKey, version1.ModifiedByEmployeeKey);

			// Wait 1 second as we're comparing datetime values which might be identical on fast
			// machines
			Thread.Sleep(500);
			
            //Get a clean object so we don't mess up the comparisons between version1 and version2
            var updater1 = repository.GetDepartment(departmentKey, user1);
            updater1.DepartmentName = "Updated " + DateTime.Now.Ticks.ToString();
            repository.UpdateDepartment(updater1, user2);

            var version2 = repository.GetDepartment(departmentKey, user1);
            Assert.AreEqual(updater1.DepartmentName, version2.DepartmentName);
            Assert.IsTrue(version1.ModifiedDate < version2.ModifiedDate);
            Assert.AreEqual(version1.CreatedDate, version2.CreatedDate);
            Assert.AreEqual(version1.CreatedByEmployeeKey, version2.CreatedByEmployeeKey);
            Assert.AreEqual(user2.UserKey, version2.ModifiedByEmployeeKey);
        }

        protected abstract IAuditColumnsScenario<TDepartment> GetScenario();
    }
}
