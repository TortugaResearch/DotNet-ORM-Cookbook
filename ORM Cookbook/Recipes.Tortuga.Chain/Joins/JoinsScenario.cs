using Recipes.Chain.Models;
using Recipes.Joins;
using Tortuga.Chain;

namespace Recipes.Chain.Joins;

public class JoinsScenario : IJoinsScenario<EmployeeDetail, EmployeeSimple>
{
    readonly SqlServerDataSource m_DataSource;

    public JoinsScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        return m_DataSource.Insert(employee).ToInt32().Execute();
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone,
e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
FROM HR.Employee e
INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey
WHERE e.EmployeeClassificationKey = @EmployeeClassificationKey";

        return m_DataSource.Sql(sql, new { employeeClassificationKey }).ToCollection<EmployeeDetail>().Execute();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
"e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee " +
"FROM HR.Employee e " +
"INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey " +
"WHERE e.LastName = @LastName";

        return m_DataSource.Sql(sql, new { lastName }).ToCollection<EmployeeDetail>().Execute();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
"e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee " +
"FROM HR.Employee e " +
"INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey " +
"WHERE e.EmployeeKey = @EmployeeKey";

        return m_DataSource.Sql(sql, new { employeeKey }).ToObjectOrNull<EmployeeDetail>().Execute();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        return m_DataSource.From<EmployeeClassification>(new { employeeClassificationKey }).ToObject().Execute();
    }
}