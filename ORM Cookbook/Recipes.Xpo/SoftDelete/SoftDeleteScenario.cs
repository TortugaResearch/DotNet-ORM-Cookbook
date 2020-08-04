using Recipes.Xpo.Entities;
using Recipes.SoftDelete;
using System;
using DevExpress.Xpo;

namespace Recipes.Xpo.SoftDelete
{
    public class SoftDeleteScenario : ISoftDeleteScenario<Department>
    {

        public int CreateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

            department.Save();
            return department.DepartmentKey;
        }

        public void DeleteDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");
            department.IsDeleted1 = true;
            department.Save();
        }

        public Department? GetDepartment(int departmentKey)
        {
            var department = Session.DefaultSession.GetObjectByKey<Department>(departmentKey);
            if (department.IsDeleted1)
            {
                return null;
            }
            return department;
        }

        public Department? GetDepartmentIgnoringIsDeleted(int departmentKey)
        {
            return Session.DefaultSession.GetObjectByKey<Department>(departmentKey);
        }

        public void UndeleteDepartment(int departmentKey)
        {
            using (var uow = new UnitOfWork())
            {
                Session.DefaultSession.GetObjectByKey<Department>(departmentKey).IsDeleted1 = false;
                uow.CommitChanges();
            }
        }

        public void UpdateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

            department.Save();
        }
    }
}
