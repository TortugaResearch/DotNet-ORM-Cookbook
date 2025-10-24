using Recipes.Pagination;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.Pagination;

public class PaginationScenario : IPaginationScenario<Employee>
{
    private IDbConnectionFactory _dbConnectionFactory;

    public PaginationScenario(IDbConnectionFactory dbConnectionFactory)
    {
        this._dbConnectionFactory = dbConnectionFactory;
    }

    public void InsertBatch(IList<Employee> employees)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.InsertAll(employees);
        }
    }

    public IList<Employee> PaginateWithPageSize(string lastName, int page, int pageSize)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var q = db.From<Employee>()
                .Where(e => e.LastName == lastName)
                .OrderBy(e => e.FirstName).ThenBy(e => e.Id)
                .Skip(page * pageSize).Take(pageSize);
            return db.Select<Employee>(q);
        }
    }

    public IList<Employee> PaginateWithSkipPast(string lastName, Employee? skipPast, int take)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            if (skipPast == null)
            {
                return db.Select<Employee>(db.From<Employee>()
                    .Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.Id)
                    .Take(take));
            }

            return db.Select<Employee>(db.From<Employee>(new TableOptions { Alias = "e" })
                .Where(@"
                            (e.LastName = @LastName)
                            AND
                            (
                                (e.FirstName > @FirstName)
                                OR
                                (
                                    e.FirstName = @FirstName
                                    AND e.EmployeeKey > @Id
                                )
                            )"
                )
                .OrderBy(e => e.FirstName).ThenBy(e => e.Id)
                .Take(take), new
                {
                    skipPast.LastName,
                    skipPast.FirstName,
                    skipPast.Id
                });
        }
    }

    public IList<Employee> PaginateWithSkipTake(string lastName, int skip, int take)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var q = db.From<Employee>()
                .Where(e => e.LastName == lastName)
                .OrderBy(e => e.FirstName).ThenBy(e => e.Id)
                .Skip(skip).Take(take);
            return db.Select<Employee>(q);
        }
    }
}