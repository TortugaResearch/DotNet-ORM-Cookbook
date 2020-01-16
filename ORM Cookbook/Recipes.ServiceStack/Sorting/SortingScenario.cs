using Recipes.ServiceStack.Entities;
using Recipes.Sorting;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.ServiceStack.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public SortingScenario(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public int Create(Employee employee)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return (int)db.Insert(employee, true);
            }
        }

        public IList<Employee> SortByLastName()
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Select(db.From<Employee>().OrderBy(x => new { x.LastName })).ToList();
            }
        }

        public IList<Employee> SortByLastNameDescFirstName()
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Select(db.From<Employee>().OrderByDescending(x => new { x.LastName }).ThenBy(x => new { x.FirstName })).ToList();
            }
        }

        public IList<Employee> SortByLastNameFirstName()
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Select(db.From<Employee>().OrderBy(x => new { x.LastName, x.FirstName })).ToList();
            }
        }
    }
}
