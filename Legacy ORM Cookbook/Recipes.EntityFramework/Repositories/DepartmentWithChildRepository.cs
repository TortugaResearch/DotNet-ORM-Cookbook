using Recipes.EF.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Recipes.EF.Repositories
{
    internal class DepartmentWithChildRepository : IDepartmentWithChildRepository<Department, Division>
    {
        public int Create(Department department)
        {
            using (var context = new OrmCookbook())
            {
                context.Departments.Add(department);
                context.Entry(department.Division).State = EntityState.Unchanged;
                context.SaveChanges();
                return department.DepartmentKey;
            }
        }

        public void Delete(int departmentKey)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.Departments.Find(departmentKey);
                if (temp != null)
                {
                    context.Departments.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Department department)
        {
            using (var context = new OrmCookbook())
            {
                var temp = context.Departments.Find(department.DepartmentKey);
                if (temp != null)
                {
                    context.Departments.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public IList<Department> GetAll()
        {
            using (var context = new OrmCookbook())
            {
                return context.Departments.Include(d => d.Division).ToList();
            }
        }

        public IList<Division> GetAllDivisions()
        {
            using (var context = new OrmCookbook())
            {
                return context.Divisions.ToList();
            }
        }

        public Department GetByKey(int departmentKey)
        {
            using (var context = new OrmCookbook())
            {
                return context.Departments.Include(d => d.Division).Where(d => d.DepartmentKey == departmentKey).SingleOrDefault();
            }
        }

        public void Update(Department department)
        {
            department.DivisionKey = department.Division.DivisionKey;

            using (var context = new OrmCookbook())
            {
                context.Entry(department).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

