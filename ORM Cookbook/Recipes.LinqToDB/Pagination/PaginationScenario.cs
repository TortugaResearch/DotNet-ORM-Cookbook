using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.Pagination;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Recipes.LinqToDB.Pagination
{
    public class PaginationScenario : IPaginationScenario<Employee>
    {
        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var db = new OrmCookbook())
            {
                foreach (var employee in employees)
                    db.Insert(employee);
            }
        }

        public IList<Employee> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Skip(page * pageSize).Take(pageSize).ToList();
        }

        [SuppressMessage("Globalization", "CA1307")]
        public IList<Employee> PaginateWithSkipPast(string lastName, Employee? skipPast, int take)
        {
            using (var db = new OrmCookbook())
            {
                if (skipPast == null)
                {
                    return db.Employee.Where(e => e.LastName == lastName)
                        .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                        .Take(take).ToList();
                }
                else
                {
                    return db.Employee
                        .Where(e => (e.LastName == lastName) && (
                            (string.Compare(e.FirstName, skipPast.FirstName) > 0)
                                || (e.FirstName == skipPast.FirstName && e.EmployeeKey > skipPast.EmployeeKey))
                            )
                        .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                        .Take(take).ToList();
                }
            }
        }

        public IList<Employee> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Skip(skip).Take(take).ToList();
        }
    }
}
