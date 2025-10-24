using DbConnector.Core;
using Recipes.DbConnector.Models;
using Recipes.ModelWithLookup;

namespace Recipes.DbConnector.ModelWithLookup;

public class ModelWithLookupComplexScenario : ScenarioBase, IModelWithLookupComplexScenario<EmployeeComplex>
{
    public ModelWithLookupComplexScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
        if (employee.EmployeeClassification == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

        const string sql = @"INSERT INTO HR.Employee
            (FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
            OUTPUT Inserted.EmployeeKey
            VALUES
            (@FirstName, @MiddleName, @LastName, @Title, @OfficePhone, @CellPhone, @EmployeeClassificationKey);";

        return DbConnector.Scalar<int>(sql,
            new
            {
                employee.FirstName,
                employee.MiddleName,
                employee.LastName,
                employee.Title,
                employee.OfficePhone,
                employee.CellPhone,
                employee.EmployeeClassificationKey
            }).Execute();
    }

    public void Delete(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @EmployeeKey;";

        DbConnector.NonQuery(sql, new { employee.EmployeeKey }).Execute();
    }

    public void DeleteByKey(int employeeKey)
    {
        const string sql = @"DELETE HR.Employee WHERE EmployeeKey = @employeeKey;";

        DbConnector.NonQuery(sql, new { employeeKey }).Execute();
    }

    public IList<EmployeeComplex> FindByLastName(string lastName)
    {
        const string sql = @"SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.LastName = @LastName";

        var settings = new ColumnMapSetting().WithSplitOnFor<EmployeeClassification>(e => e.EmployeeClassificationKey);

        return DbConnector.ReadToList<EmployeeComplex>(settings, sql, new { LastName = lastName }).Execute();
    }

    public IList<EmployeeComplex> GetAll()
    {
        const string sql = @"SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed";

        //Configure Split map settings
        var settings = new ColumnMapSetting().WithSplitOnFor<EmployeeClassification>(e => e.EmployeeClassificationKey);

        return DbConnector.ReadToList<EmployeeComplex>(settings, sql).Execute();
    }

    public EmployeeComplex? GetByKey(int employeeKey)
    {
        const string sql = @"SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.EmployeeKey = @EmployeeKey";

        //Configure Split map settings
        var settings = new ColumnMapSetting().WithSplitOnFor<EmployeeClassification>(e => e.EmployeeClassificationKey);

        return DbConnector.ReadSingleOrDefault<EmployeeComplex>(settings, sql, new { EmployeeKey = employeeKey }).Execute();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
    }

    public void Update(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
        if (employee.EmployeeClassification == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

        const string sql = @"UPDATE HR.Employee
            SET FirstName = @FirstName,
                MiddleName = @MiddleName,
                LastName = @LastName,
                Title = @Title,
                OfficePhone = @OfficePhone,
                CellPhone = @CellPhone,
                EmployeeClassificationKey = @EmployeeClassificationKey
            WHERE EmployeeKey = @EmployeeKey;";

        DbConnector.NonQuery(sql,
            new
            {
                employee.EmployeeKey,
                employee.FirstName,
                employee.MiddleName,
                employee.LastName,
                employee.Title,
                employee.OfficePhone,
                employee.CellPhone,
                employee.EmployeeClassificationKey
            }).Execute();
    }
}