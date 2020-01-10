using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EntityFrameworkCore.ModelWithLookup
{
    public class ModelWithLookupComplexRepository : IModelWithLookupComplexRepository<Employee>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public ModelWithLookupComplexRepository(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            if (employee.EmployeeClassificationKeyNavigation == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassificationKeyNavigation)} is null.");

            using (var context = CreateDbContext())
            {
                //Replace EmployeeClassification with one fetched from the same context.
                var localEmployeeClassification = context.EmployeeClassification.Find(employee.EmployeeClassificationKeyNavigation.EmployeeClassificationKey);
                employee.EmployeeClassificationKeyNavigation = localEmployeeClassification;

                context.Employee.Add(employee);
                context.SaveChanges();
                return employee.EmployeeKey;
            }
        }

        public void Delete(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var context = CreateDbContext())
            {
                //Find the row you wish to delete
                var temp = context.Employee.Find(employee.EmployeeKey);
                if (temp != null)
                {
                    context.Employee.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public void DeleteByKey(int employeeKey)
        {
            using (var context = CreateDbContext())
            {
                //Find the row you wish to delete
                var temp = context.Employee.Find(employeeKey);
                if (temp != null)
                {
                    context.Employee.Remove(temp);
                    context.SaveChanges();
                }
            }
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            using (var context = CreateDbContext())
            {
                return context.Employee
                    .Where(ec => ec.LastName == lastName)
                    .Include(e => e.EmployeeClassificationKeyNavigation)
                    .ToList();
            }
        }

        public IList<Employee> GetAll()
        {
            using (var context = CreateDbContext())
            {
                return context.Employee
                    .Include(e => e.EmployeeClassificationKeyNavigation)
                    .ToList();
            }
        }

        public Employee? GetByKey(int employeeKey)
        {
            using (var context = CreateDbContext())
            {
                return context.Employee
                    .Include(e => e.EmployeeClassificationKeyNavigation)
                    .SingleOrDefault(e => e.EmployeeKey == employeeKey);
            }
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                return context.EmployeeClassification.Find(employeeClassificationKey);
            }
        }

        /// <summary>
        /// Updates the specified employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        /// <exception cref="ArgumentNullException">employee</exception>
        public void Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            if (employee.EmployeeClassificationKeyNavigation == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassificationKeyNavigation)} is null.");

            using (var context = CreateDbContext())
            {
                //Get a fresh copy of the row from the database
                var temp = context.Employee.Find(employee.EmployeeKey);

                //Replace EmployeeClassification with one fetched from the same context.
                var localEmployeeClassification = context.EmployeeClassification.Find(employee.EmployeeClassificationKeyNavigation.EmployeeClassificationKey);

                if (temp != null)
                {
                    //Copy the changed fields
                    temp.FirstName = employee.FirstName;
                    temp.MiddleName = employee.MiddleName;
                    temp.LastName = employee.LastName;
                    temp.CellPhone = employee.CellPhone;
                    temp.OfficePhone = employee.OfficePhone;
                    temp.Title = employee.Title;
                    temp.EmployeeClassificationKeyNavigation = localEmployeeClassification;
                    context.SaveChanges();
                }
            }
        }
    }
}
