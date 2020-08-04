using DevExpress.Xpo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.AuditColumns;
using Recipes.Xpo.Entities;
using System;

namespace Recipes.Xpo.AuditColumns
{
    public class AuditColumnsScenario : IAuditColumnsScenario<Department>
    {
        public AuditColumnsScenario() { }

        public int CreateDepartment(Department department, User user)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
            if (user == null)
                throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");

            SecuritySystem.CurrentUser = user;
            // Run AfterConstruction() to update the current 'CreatedDate' and 'CreatedByEmployeeKey', 
            // because, normally, we must create a new object here.
            department.AfterConstruction();
            department.Save();

            return department.DepartmentKey;
        }

        public Department GetDepartment(int departmentKey, User user)
        {
            SecuritySystem.CurrentUser = user;
            return Session.DefaultSession.GetObjectByKey<Department>(departmentKey);
        }

        public void UpdateDepartment(Department department, User user)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
            if (user == null)
                throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null.");
            SecuritySystem.CurrentUser = user;
            department.Save();
            Assert.Inconclusive("XPO Objects are true persistent objects so this test cannot pass.");
        }
    }
}
