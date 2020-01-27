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

        public void InsertBatch(IList<Employee> employees)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
                db.InsertAll(employees);
        }

        public IList<Employee> SortByFirstName(string lastName)
        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Select(db.From<Employee>().Where(x => x.LastName == lastName)
                    .OrderBy(x => new { x.FirstName })).ToList();
            }
        }

        public IList<Employee> SortByMiddleNameDescFirstName(string lastName)

        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Select(db.From<Employee>().Where(x => x.LastName == lastName)
                    .OrderByDescending(x => new { x.MiddleName }).ThenBy(x => new { x.FirstName })).ToList();
            }
        }

        public IList<Employee> SortByMiddleNameFirstName(string lastName)

        {
            using (var db = _dbConnectionFactory.OpenDbConnection())
            {
                return db.Select(db.From<Employee>().Where(x => x.LastName == lastName)
                    .OrderBy(x => new { x.MiddleName, x.FirstName })).ToList();
            }
        }
    }
}
