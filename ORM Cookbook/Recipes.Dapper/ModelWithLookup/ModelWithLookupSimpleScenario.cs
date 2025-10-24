using Dapper;
using Recipes.Dapper.Models;
using Recipes.ModelWithLookup;

namespace Recipes.Dapper.ModelWithLookup;

public class ModelWithLookupSimpleScenario : ScenarioBase, IModelWithLookupSimpleScenario<EmployeeSimple>
{
    public ModelWithLookupSimpleScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        const string sql = @"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey
VALUES
(@FirstName, @MiddleName, @LastName, @Title, @OfficePhone, @CellPhone, @EmployeeClassificationKey);";

        using (var con = OpenConnection())
            return (int)con.ExecuteScalar(sql, employee)!;
    }

    public void Delete(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @EmployeeKey;";

        using (var con = OpenConnection())
            con.Execute(sql, employee);
    }

    public void DeleteByKey(int employeeKey)
    {
        const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @EmployeeKey;";

        using (var con = OpenConnection())
            con.Execute(sql, new { employeeKey });
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone,        e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName";

        var result = new List<EmployeeSimple>();

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
    }

    public IList<EmployeeSimple> GetAll()
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone,        e.EmployeeClassificationKey FROM HR.Employee e";

        var result = new List<EmployeeSimple>();

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql).ToList();
    }

    public EmployeeSimple? GetByKey(int employeeKey)
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone,        e.EmployeeClassificationKey FROM HR.Employee e WHERE e.EmployeeKey = @EmployeeKey";

        using (var con = OpenConnection())
            return con.QuerySingleOrDefault<EmployeeSimple>(sql, new { employeeKey });
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

        using (var con = OpenConnection())
            return con.QuerySingle<EmployeeClassification>(sql, new { EmployeeClassificationKey = employeeClassificationKey });
    }

    public void Update(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        const string sql = @"UPDATE HR.Employee
SET FirstName = @FirstName,
    MiddleName = @MiddleName,
    LastName = @LastName,
    Title = @Title,
    OfficePhone = @OfficePhone,
    CellPhone = @CellPhone,
    EmployeeClassificationKey = @EmployeeClassificationKey
WHERE EmployeeKey = @EmployeeKey;";

        using (var con = OpenConnection())
            con.Execute(sql, employee);
    }
}