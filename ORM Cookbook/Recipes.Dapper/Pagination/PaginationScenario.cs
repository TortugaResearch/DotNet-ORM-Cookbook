using Dapper;
using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;
using Recipes.Pagination;

namespace Recipes.Dapper.Pagination;

public class PaginationScenario : ScenarioBase, IPaginationScenario<EmployeeSimple>
{
    public PaginationScenario(string connectionString) : base(connectionString)
    { }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var con = OpenConnection())
            con.Insert(employees);
    }

    public IList<EmployeeSimple> PaginateWithPageSize(string lastName, int page, int pageSize)
    {
        const string sql = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE e.LastName = @LastName
ORDER BY e.FirstName,
         e.EmployeeKey OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;";

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, new { lastName, Skip = page * pageSize, Take = pageSize }).ToList();
    }

    public IList<EmployeeSimple> PaginateWithSkipPast(string lastName, EmployeeSimple? skipPast, int take)
    {
        const string sqlA = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE (e.LastName = @LastName)
ORDER BY e.FirstName,
         e.EmployeeKey
OFFSET 0 ROWS FETCH NEXT @Take ROWS ONLY;";

        const string sqlB = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE (e.LastName = @LastName)
      AND
      (
          (e.FirstName > @FirstName)
          OR
          (
              e.FirstName = @FirstName
              AND e.EmployeeKey > @EmployeeKey
          )
      )
ORDER BY e.FirstName,
         e.EmployeeKey
OFFSET 0 ROWS FETCH NEXT @Take ROWS ONLY;";

        string sql;
        object param;
        if (skipPast == null)
        {
            sql = sqlA;
            param = new { lastName, take };
        }
        else
        {
            sql = sqlB;
            param = new { lastName, take, skipPast.FirstName, skipPast.EmployeeKey };
        }

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, param).ToList();
    }

    public IList<EmployeeSimple> PaginateWithSkipTake(string lastName, int skip, int take)
    {
        const string sql = @"SELECT e.EmployeeKey,
       e.FirstName,
       e.MiddleName,
       e.LastName,
       e.Title,
       e.OfficePhone,
       e.CellPhone,
       e.EmployeeClassificationKey
FROM HR.Employee e
WHERE e.LastName = @LastName
ORDER BY e.FirstName,
         e.EmployeeKey OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;";

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, new { lastName, skip, take }).ToList();
    }
}