//using Recipes.EntityFramework.Entities;
//using Recipes.ModelWithLookup;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;

//namespace Recipes.EntityFramework.ModelWithLookup
//{
//    public class ModelWithLookupComplexScenario : IModelWithLookupComplexScenario<Employee>
//    {
//        private Func<OrmCookbookContext> CreateDbContext;

//        public ModelWithLookupComplexScenario(Func<OrmCookbookContext> dBContextFactory)
//        {
//            CreateDbContext = dBContextFactory;
//        }

//        public int Create(Employee employee)
//        {
//            if (employee == null)
//                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
//            if (employee.EmployeeClassification == null)
//                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

//            using (var context = CreateDbContext())
//            {
//                //Prevent updates to the lookup table
//                context.Entry(employee.EmployeeClassification).State = EntityState.Unchanged;

//                context.Employee.Add(employee);
//                context.SaveChanges();
//                return employee.EmployeeKey;
//            }
//        }

//        public void Delete(Employee employee)
//        {
//            if (employee == null)
//                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

//            using (var context = CreateDbContext())
//            {
//                context.Entry(employee).State = EntityState.Deleted;
//                context.SaveChanges();
//            }
//        }

//        public void DeleteByKey(int employeeKey)
//        {
//            using (var context = CreateDbContext())
//            {
//                //Find the row you wish to delete
//                var temp = context.Employee.Find(employeeKey);
//                if (temp != null)
//                {
//                    context.Employee.Remove(temp);
//                    context.SaveChanges();
//                }
//            }
//        }

//        public IList<Employee> FindByLastName(string lastName)
//        {
//            using (var context = CreateDbContext())
//                return context.Employee
//                    .Where(ec => ec.LastName == lastName)
//                    .Include(e => e.EmployeeClassification)
//                    .ToList();
//        }

//        public IList<Employee> GetAll()
//        {
//            using (var context = CreateDbContext())
//                return context.Employee
//                    .Include(e => e.EmployeeClassification)
//                    .ToList();
//        }

//        public Employee? GetByKey(int employeeKey)
//        {
//            using (var context = CreateDbContext())
//                return context.Employee
//                    .Include(e => e.EmployeeClassification)
//                    .SingleOrDefault(e => e.EmployeeKey == employeeKey);
//        }

//        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
//        {
//            using (var context = CreateDbContext())
//                return context.EmployeeClassification.Find(employeeClassificationKey);
//        }

//        /// <summary>
//        /// Updates the specified employee.
//        /// </summary>
//        /// <param name="employee">The employee.</param>
//        /// <exception cref="ArgumentNullException">employee</exception>
//        public void Update(Employee employee)
//        {
//            if (employee == null)
//                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
//            if (employee.EmployeeClassification == null)
//                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

//            using (var context = CreateDbContext())
//            {
//                //Prevent updates to the lookup table
//                context.Entry(employee.EmployeeClassification).State = EntityState.Unchanged;

//                context.Entry(employee).State = EntityState.Modified;
//                context.SaveChanges();
//            }
//        }
//    }
//}
