using Recipes.Xpo.Entities;
using Recipes.Pagination;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.Pagination
{
    public class PaginationScenario : IPaginationScenario<Employee>
    {
        public void InsertBatch(IList<Employee> employees)
        {
            Session.DefaultSession.Save(employees);
        }

        public IList<Employee> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            return Session.DefaultSession.Query<Employee>().Where(e => e.LastName == lastName)
                .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                .Skip(page * pageSize).Take(pageSize).ToList();
        }

        [SuppressMessage("Globalization", "CA1307")]
        public IList<Employee> PaginateWithSkipPast(string lastName, Employee? skipPast, int take)
        {
            if (skipPast == null)
            {
                return Session.DefaultSession.Query<Employee>().Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Take(take).ToList();
            } else
            {
                return Session.DefaultSession.Query<Employee>()
                    .Where(e => (e.LastName == lastName) && (
                        (string.Compare(e.FirstName, skipPast.FirstName) > 0)
                            || (e.FirstName == skipPast.FirstName && e.EmployeeKey > skipPast.EmployeeKey))
                        )
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Take(take).ToList();
            }
        }

        public IList<Employee> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            return Session.DefaultSession.Query<Employee>().Where(e => e.LastName == lastName)
                .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                .Skip(skip).Take(take).ToList();
        }
    }
}
