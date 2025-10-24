using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.SoftDelete;

namespace Recipes.EntityFrameworkCore.SoftDelete
{
    public class SoftDeleteScenario : ISoftDeleteScenario<Department>
    {
        private Func<OrmCookbookContextWithSoftDelete> CreateDbContext;
        private Func<OrmCookbookContext> CreateBypassDbContext;

        public SoftDeleteScenario(Func<OrmCookbookContextWithSoftDelete> dBContextFactory, Func<OrmCookbookContext> bypassContextFactory)
        {
            CreateDbContext = dBContextFactory;
            CreateBypassDbContext = bypassContextFactory;
        }

        public int CreateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

            using (var context = CreateDbContext())
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return department.DepartmentKey;
            }
        }

        public void DeleteDepartment(Department department)
        {
            using (var context = CreateDbContext())
            {
                context.Entry(department).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Department? GetDepartment(int departmentKey)
        {
            using (var context = CreateDbContext())
                return context.Departments.Find(departmentKey);
        }

        public Department? GetDepartmentIgnoringIsDeleted(int departmentKey)
        {
            using (var context = CreateBypassDbContext())
                return context.Departments.Find(departmentKey);
        }

        public void UndeleteDepartment(int departmentKey)
        {
            using (var context = CreateDbContext())
                context.Database.ExecuteSqlInterpolated($"UPDATE HR.Department SET IsDeleted = 0 WHERE DepartmentKey = {departmentKey}");
        }

        public void UpdateDepartment(Department department)
        {
            if (department == null)
                throw new ArgumentNullException(nameof(department), $"{nameof(department)} is null.");

            using (var context = CreateDbContext())
            {
                context.Entry(department).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}