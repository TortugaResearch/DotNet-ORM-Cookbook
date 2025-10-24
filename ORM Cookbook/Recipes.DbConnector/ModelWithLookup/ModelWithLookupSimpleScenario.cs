using Recipes.DbConnector.Models;
using Recipes.ModelWithLookup;

namespace Recipes.DbConnector.ModelWithLookup;

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

        return DbConnector.Scalar<int>(sql, employee).Execute();
    }

    public void Delete(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @EmployeeKey;";

        DbConnector.NonQuery(sql, employee).Execute();
    }

    public void DeleteByKey(int employeeKey)
    {
        const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @employeeKey;";

        DbConnector.NonQuery(sql, new { employeeKey }).Execute();
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @lastName";

        return DbConnector.ReadToList<EmployeeSimple>(sql, new { lastName }).Execute();
    }

    public IList<EmployeeSimple> GetAll()
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e";

        return DbConnector.ReadToList<EmployeeSimple>(sql).Execute();
    }

    public EmployeeSimple? GetByKey(int employeeKey)
    {
        const string sql = @"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.EmployeeKey = @employeeKey";

        return DbConnector.ReadSingleOrDefault<EmployeeSimple>(sql, new { employeeKey }).Execute();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
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

        DbConnector.NonQuery(sql, employee).Execute();
    }
}